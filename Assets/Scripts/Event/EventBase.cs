using ConnectBridge;
using ExitGames.Client.Photon;
using UnityEngine;

namespace Event {
    public abstract class EventBase {
        [HideInInspector] public EventCode eventCode; //事件码
        public abstract void OnEvent(EventData eventData); //响应

        private void Start() {
            PhotonEngine.Instance.AddEvent(this);
        }

        private void OnDestroy() {
            PhotonEngine.Instance.RemoveEvent(this);
        }
    }
}