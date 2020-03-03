using System;
using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonEngine : MonoBehaviour, IPhotonPeerListener {
    private static PhotonEngine Instance;
    private static PhotonPeer peer;

    public static PhotonPeer Peer => peer;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        peer.Connect("127.0.0.1:5055", "PosSynServer"); //连接服务器
    }

    private void Update() {
        peer?.Service(); //保证与服务器的连接
    }

    private void OnDestroy() {
        if (peer != null && peer.PeerState == PeerStateValue.Disconnected) { //判断连接状态
            peer.Disconnect(); //断开连接
        }
    }

    public void DebugReturn(DebugLevel level, string message) { }

    //返回至客户端的响应
    public void OnOperationResponse(OperationResponse operationResponse) {
        switch (operationResponse.OperationCode) {
            case 1:
                Debug.Log("收到服务端的响应");
                break;
            default: break;
        }
    }

    //连接状态发生改变
    public void OnStatusChanged(StatusCode statusCode) {
        Debug.Log(statusCode);
    }

    //服务器向客户端发送事件
    public void OnEvent(EventData eventData) { }
}