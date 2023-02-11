using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Universal.UniversalSDK;

public class MainController : MonoBehaviour
{
    public Image userImage;
    public Text displayNameText;
    public Text uniqueIdText;    
    public Text emailText;

    public Text rawJsonText;
    
    string helpUrl = "https://support.google.com/?hl=ko";

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
                        StartCoroutine(UpdateProfile(value));
                        UpdateRawSection(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
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
                        StartCoroutine(UpdateProfile(value));
                        UpdateRawSection(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
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
                        StartCoroutine(UpdateProfile(value));
                        UpdateRawSection(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }

    public void OnClickLogout()
    {
        UniversalSDK.Ins.Logout(result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }    

    public void OnClickOpenCustomTabView()
    {
        UniversalSDK.Ins.OpenCustomTabView(helpUrl, result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void UpdateRawSection(object obj)
    {
        if (obj == null)
        {
            rawJsonText.text = "null";
            return;
        }
        var text = JsonUtility.ToJson(obj);
        if (text == null)
        {
            rawJsonText.text = "Invalid Object";
            return;
        }
        rawJsonText.text = text + "\n\n" + rawJsonText.text;
        var scrollContentTransform = (RectTransform)rawJsonText.gameObject.transform.parent;
        scrollContentTransform.localPosition = Vector3.zero;
    }

    IEnumerator UpdateProfile(LoginResult result)
    {
        if (result.ImageURL != null)
        {
            var www = UnityWebRequestTexture.GetTexture(result.ImageURL);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                var texture = DownloadHandlerTexture.GetContent(www);
                userImage.color = Color.white;
                userImage.sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0, 0));
            }
        }
        else
        {
            yield return null;
        }        
        displayNameText.text = result.Name;
        uniqueIdText.text = result.UserID;
        emailText.text = result.Email;
    }
}
