using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Universal.UniversalSDK;

public class LoginController : MonoBehaviour
{
    public Text titleText;
    public Text messageText;
    public GameObject popup_panel;

    void Start()
    {
    }

    public void OnClickGoogleLogin()
    {
        UniversalSDK.Ins.Login(LoginType.GOOGLE,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Instance.loginResult = value;
                        SceneManager.LoadSceneAsync("Main");
                    },
                    error =>
                    {
                        titleText.text = error.Code.ToString();
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }
    public void OnClickFacebookLogin()
    {
        UniversalSDK.Ins.Login(LoginType.FACEBOOK,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Instance.loginResult = value;
                        SceneManager.LoadSceneAsync("Main");
                    },
                    error =>
                    {
                        titleText.text = error.Code.ToString();
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }    
    public void OnClickAppleLogin()
    {
        UniversalSDK.Ins.Login(LoginType.APPLE,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Instance.loginResult = value;
                        SceneManager.LoadSceneAsync("Main");
                    },
                    error =>
                    {
                        titleText.text = error.Code.ToString();
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickClosePopup()
    {
        popup_panel.SetActive(false);
    }
    
}
