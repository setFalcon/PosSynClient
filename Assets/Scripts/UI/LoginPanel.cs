using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {
    private Button loginButton;
    private Button registerButton;
    public GameObject registerPanel;

    private void Awake() {
        loginButton = GameObject.Find("Canvas/LoginPanel/LoginButton").GetComponent<Button>();
        registerButton = GameObject.Find("Canvas/LoginPanel/RegisterButton").GetComponent<Button>();
    }

    private void Start() {
        loginButton.onClick.AddListener(OnLoginButtonClick);
        registerButton.onClick.AddListener(OnRegisterButtonClick);
    }

    private void OnLoginButtonClick() {
        
    }

    private void OnRegisterButtonClick() {
        registerPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}