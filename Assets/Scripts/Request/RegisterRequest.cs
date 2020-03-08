using System.Collections.Generic;
using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

public class RegisterRequest : RequestBase {
    [HideInInspector] public string Username;
    [HideInInspector] public string Password;
    private RegisterPanel _registerPanel;

    private void Awake() {
        OpCode = OperationCode.Register;
        _registerPanel = GetComponent<RegisterPanel>();
    }

    public override void DefaultRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte) ParameterCode.Username, Username);
        data.Add((byte) ParameterCode.Password, Password);
        PhotonEngine.Peer.OpCustom((byte) OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse resp) {
        ReturnCode returnCode = (ReturnCode) resp.ReturnCode;
        _registerPanel.OnRegisterResponse(returnCode);
    }
}