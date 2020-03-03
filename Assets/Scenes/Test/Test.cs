using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SendRequest();
        }
    }

    private void SendRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();//传递的字典
        data.Add(1,100);
        data.Add(2,"Hello World");
        PhotonEngine.Peer.OpCustom(1, data, true);
    }
}