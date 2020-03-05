using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour {
    private Button backButton;
    private Button registerButton;
    public GameObject loginPanel;

    private void Awake() {
        backButton = GameObject.Find("Canvas/RegisterPanel/BackButton").GetComponent<Button>();
        registerButton = GameObject.Find("Canvas/RegisterPanel/RegisterButton").GetComponent<Button>();
    }

    private void Start() {
        backButton.onClick.AddListener(OnBackButtonClick);
        registerButton.onClick.AddListener(OnRegisterButtonClick);
    }

    private void OnBackButtonClick() {
        loginPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnRegisterButtonClick() { }
}