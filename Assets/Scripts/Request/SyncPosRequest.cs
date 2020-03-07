using System;
using System.Collections;
using System.Collections.Generic;
using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

public class SyncPosRequest : Request {
    [HideInInspector] public Vector3 position;

    private void Awake() {
        OpCode = OperationCode.SyncPos;
    }

    public override void DefaultRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte) ParameterCode.Position, new Vector3Data {
            x = position.x, y = position.y, z = position.z
        });
        PhotonEngine.Peer.OpCustom((byte) OperationCode.SyncPos, data, true);
    }

    public override void OnOperationResponse(OperationResponse resp) {
        throw new NotImplementedException();
    }
}