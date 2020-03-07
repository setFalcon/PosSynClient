using ConnectBridge;
using ConnectBridge.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour {
    private Button _loginButton;
    private Button _registerButton;
    private InputField _usernameInputField;
    private InputField _passwordInputField;
    private LoginRequest _loginRequest;
    private GameObject _hintMessage;
    private GameObject _registerPanel;

    private void Awake() {
        _loginButton = GameObject.Find("Canvas/LoginPanel/LoginButton").GetComponent<Button>();
        _registerButton = GameObject.Find("Canvas/LoginPanel/RegisterButton").GetComponent<Button>();
        _usernameInputField = GameObject.Find("Canvas/LoginPanel/UsernameInputField").GetComponent<InputField>();
        _passwordInputField = GameObject.Find("Canvas/LoginPanel/PasswordInputField").GetComponent<InputField>();
        _loginRequest = GetComponent<LoginRequest>();
        _hintMessage = GameObject.Find("Canvas/LoginPanel/HintMessage");
        _hintMessage.SetActive(false);
        _registerPanel = GameObject.Find("Canvas/RegisterPanel");
    }

    private void Start() {
        _loginButton.onClick.AddListener(OnLoginButtonClick);
        _registerButton.onClick.AddListener(OnRegisterButtonClick);
    }

    private void OnLoginButtonClick() {
        _loginRequest.Username = _usernameInputField.text;
        _loginRequest.Password = MD5Util.GetMD5(_passwordInputField.text);
        _loginRequest.DefaultRequest();
    }

    private void OnRegisterButtonClick() {
        _registerPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnLoginResponse(ReturnCode returnCode) {
        if (returnCode == ReturnCode.LoginSuccess) {
            _hintMessage.SetActive(false);
            gameObject.SetActive(false);
            SceneManager.LoadScene("Game");

        }
        else if(returnCode == ReturnCode.LoginFailed){
            _hintMessage.SetActive(true);
        }
    }
}