using System;
using UnityEngine;

public class PhotonEngine : MonoBehaviour {
    private static PhotonEngine Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}