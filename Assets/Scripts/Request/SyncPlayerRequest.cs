using System;
using System.Collections;
using System.Collections.Generic;
using ConnectBridge;
using ConnectBridge.Util;
using ExitGames.Client.Photon;
using LitJson;
using UnityEngine;

public class SyncPlayerRequest : Request {
    private void Awake() {
        OpCode = OperationCode.SyncPlayer;
    }

    public override void DefaultRequest() {
        PhotonEngine.Peer.OpCustom((byte) OpCode, null, true);
    }

    public override void OnOperationResponse(OperationResponse resp) {
        string usernameListJson = (string) DictUtil.GetValue(resp.Parameters, (byte) ParameterCode.UsernameList);
        List<string> usernameList = JsonMapper.ToObject<List<string>>(usernameListJson);
        foreach (string name in usernameList) {
            Debug.Log(name);
        }
    }
}