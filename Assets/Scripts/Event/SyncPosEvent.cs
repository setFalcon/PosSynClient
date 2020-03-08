using System;
using System.Collections.Generic;
using ConnectBridge;
using ConnectBridge.Util;
using ExitGames.Client.Photon;
using LitJson;
using UnityEngine;

public class SyncPosEvent : EventBase {

    private Player _player;
    
    private void Awake() {
        _player = GetComponent<Player>();
        eventCode = EventCode.SyncPosition;
    }

    public override void OnEvent(EventData eventData) {
        string playerDataList = (string) DictUtil.GetValue(eventData.Parameters, (byte) ParameterCode.PlayerDataList);
        List<PlayerPositionData> posData = JsonMapper.ToObject<List<PlayerPositionData>>(playerDataList);
        _player.OnSyncPositionEvent(posData);
    }
}