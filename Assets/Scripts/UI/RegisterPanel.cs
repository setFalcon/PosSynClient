using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour {
    private Button _backButton;
    private Button _registerButton;
    private InputField _usernameInputField;
    private InputField _passwordInputField;
    private GameObject _hintMessage;
    private GameObject _loginPanel;
    private RegisterRequest _registerRequest;

    private void Awake() {
        _backButton = GameObject.Find("Canvas/RegisterPanel/BackButton").GetComponent<Button>();
        _registerButton = GameObject.Find("Canvas/RegisterPanel/RegisterButton").GetComponent<Button>();
        _usernameInputField = GameObject.Find("Canvas/RegisterPanel/UsernameInputField").GetComponent<InputField>();
        _passwordInputField = GameObject.Find("Canvas/RegisterPanel/PasswordInputField").GetComponent<InputField>();
        _hintMessage = GameObject.Find("Canvas/RegisterPanel/HintMessage");
        _hintMessage.SetActive(false);
        _loginPanel = GameObject.Find("Canvas/LoginPanel");
        _registerRequest = GetComponent<RegisterRequest>();
    }

    private void Start() {
        _backButton.onClick.AddListener(OnBackButtonClick);
        _registerButton.onClick.AddListener(OnRegisterButtonClick);
        gameObject.SetActive(false);
    }

    private void OnBackButtonClick() {
        _loginPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnRegisterButtonClick() {
        _registerRequest.Username = _usernameInputField.text;
        _registerRequest.Password = _passwordInputField.text;
        _registerRequest.DefaultRequest();
    }
}