using System;
using System.Collections;
using System.Collections.Generic;
using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

public class SyncPlayerRequest : Request
{
   private void Awake() {
      OpCode = OperationCode.SyncPlayer;
   }

   public override void DefaultRequest() {
      PhotonEngine.Peer.OpCustom((byte) OpCode, null, true);
   }

   public override void OnOperationResponse(OperationResponse resp) {
   }
}
