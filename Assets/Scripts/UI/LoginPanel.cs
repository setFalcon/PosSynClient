using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {
    private Button _loginButton;
    private Button _registerButton;
    private InputField _usernameInputField;
    private InputField _passwordInputField;
    private LoginRequest _loginRequest;
    public GameObject registerPanel;

    private void Awake() {
        _loginButton = GameObject.Find("Canvas/LoginPanel/LoginButton").GetComponent<Button>();
        _registerButton = GameObject.Find("Canvas/LoginPanel/RegisterButton").GetComponent<Button>();
        _usernameInputField = GameObject.Find("Canvas/LoginPanel/UsernameInputField").GetComponent<InputField>();
        _passwordInputField = GameObject.Find("Canvas/LoginPanel/PasswordInputField").GetComponent<InputField>();
        _loginRequest = GetComponent<LoginRequest>();
    }

    private void Start() {
        _loginButton.onClick.AddListener(OnLoginButtonClick);
        _registerButton.onClick.AddListener(OnRegisterButtonClick);
    }

    private void OnLoginButtonClick() {
        _loginRequest.Username = _usernameInputField.text;
        _loginRequest.Password = _passwordInputField.text;
        _loginRequest.DefaultRequest();
    }

    private void OnRegisterButtonClick() {
        registerPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}