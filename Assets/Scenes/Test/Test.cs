using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    void Update() {
        if (Input.GetMouseButton(0)) {
            SendRequest();
        }
    }

    private void SendRequest() {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        PhotonEngine.Peer.OpCustom(1, data, true);
    }
}