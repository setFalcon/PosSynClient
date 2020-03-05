using ConnectBridge;
using UnityEngine;

public abstract class Request : MonoBehaviour {
    private OperationCode OpCode; //操作码
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse();
}