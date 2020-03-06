using System.Collections.Generic;
using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

public class LoginRequest : Request {
    [HideInInspector] public string Username;
    [HideInInspector] public string Password;

    private void Awake() {
        OpCode = OperationCode.Login;
    }

    public override void DefaultRequest() { //发起请求的代码
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte) ParameterCode.Username, Username);
        data.Add((byte) ParameterCode.Password, Password);
        PhotonEngine.Peer.OpCustom((byte) OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse resp) { //处理响应的代码
    }
}