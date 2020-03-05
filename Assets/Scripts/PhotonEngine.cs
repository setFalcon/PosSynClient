using System;
using System.Collections.Generic;
using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonEngine : MonoBehaviour, IPhotonPeerListener {
    public static PhotonEngine Instance;
    private static PhotonPeer peer;

    public static PhotonPeer Peer => peer;

    private Dictionary<OperationCode, Request> requestDict = new Dictionary<OperationCode, Request>(); //请求字典

    public void AddRequest(Request req) { //向字典中添加请求
        requestDict.Add(req.OpCode, req);
    }

    public void RemoveRequest(Request req) { //移除字典中的请求
        requestDict.Remove(req.OpCode);
    }

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
        OperationCode opCode = (OperationCode) operationResponse.OperationCode;
        Request req;
        requestDict.TryGetValue(opCode, out req);
        if (req != null) {
            req.OnOperationResponse(operationResponse);
        }
        else {
            Debug.Log("没有找到对应的响应 处理对象");
        }
    }

    //连接状态发生改变
    public void OnStatusChanged(StatusCode statusCode) {
        Debug.Log(statusCode);
    }

    //服务器向客户端发送事件
    public void OnEvent(EventData eventData) {
        switch (eventData.Code) {
            case 1:
                Dictionary<byte, object> eventdata = eventData.Parameters;
                object stringValue;
                eventdata.TryGetValue(1, out stringValue);
                Debug.Log("服务端事件回复 : " + stringValue);
                break;
            default: break;
        }
    }
}