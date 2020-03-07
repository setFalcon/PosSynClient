using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isLocalPlayer = true;
    [HideInInspector] public string username;
    private SyncPosRequest _syncPosRequest;
    private SyncPlayerRequest _syncPlayerRequest;
    private Vector3 lastPosition = Vector3.zero;
    private float moveOffset = 0.1f;

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

    private void Update() {
        if (isLocalPlayer) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(Time.deltaTime * 4f * new Vector3(h, 0, v));
        }
    }
}