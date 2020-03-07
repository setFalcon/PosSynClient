using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isLocalPlayer = true;

    private void Start() {
        if (isLocalPlayer) {
            GetComponent<Renderer>().sharedMaterial.color = Color.green;
        }
    }

    private void Update() {
        if (isLocalPlayer) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(Time.deltaTime * 4f * new Vector3(h, 0, v));
        }
    }
}