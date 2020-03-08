using System;
using System.Collections;
using System.Collections.Generic;
using ConnectBridge;
using ConnectBridge.Util;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isLocalPlayer = true;
    [HideInInspector] public string username;
    private SyncPosRequest _syncPosRequest;
    private SyncPlayerRequest _syncPlayerRequest;
    private Vector3 lastPosition = Vector3.zero;
    private float moveOffset = 0f;
    public GameObject playerPrefab;

    private Dictionary<string, GameObject> playerDict = new Dictionary<string, GameObject>();

    private void Awake() {
        username = PhotonEngine.Username;
    }

    private void Start() {
        if (isLocalPlayer) {
            GetComponent<Renderer>().material.color = Color.green;
            _syncPosRequest = GetComponent<SyncPosRequest>();
            _syncPlayerRequest = GetComponent<SyncPlayerRequest>();
            _syncPlayerRequest.DefaultRequest();
            InvokeRepeating(nameof(SyncPosition), 3f, 0.05f);
        }
    }


    void SyncPosition() {
        if (Vector3.Distance(transform.position, lastPosition) > moveOffset) {
            _syncPosRequest.position = transform.position;
            _syncPosRequest.DefaultRequest();
            lastPosition = transform.position;
        }
    }

    //创建其他客户端player
    public void OnSyncPlayerResponse(List<string> usernameList) {
        foreach (string u in usernameList) {
            OnNewPlayerEvent(u);
        }
    }

    public void OnNewPlayerEvent(string u) {
        GameObject otherplayer = Instantiate(playerPrefab);
        otherplayer.GetComponent<Player>().isLocalPlayer = false;
        otherplayer.GetComponent<Player>().username = u;
        playerDict.Add(u, otherplayer);
    }

    public void OnSyncPositionEvent(List<PlayerPositionData> posData) {
        foreach (PlayerPositionData data in posData) {
            if (!username.Equals(data.Username)) {
                GameObject player = DictUtil.GetValue(playerDict, data.Username);
                player.transform.position = new Vector3((float) data.Pos.X, (float) data.Pos.Y, (float) data.Pos.Z);
            }
        }
    }

    private void Update() {
        if (isLocalPlayer) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(Time.deltaTime * 4f * new Vector3(h, 0, v));
        }
    }
}