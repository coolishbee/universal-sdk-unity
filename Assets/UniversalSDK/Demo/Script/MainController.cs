using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using Universal.UniversalSDK;

public class MainController : MonoBehaviour
{
#if UNITY_ANDROID
    string productID_1 = "boxer_unity1000";
    string productID_2 = "boxer_unity2000";
#elif UNITY_IOS    
    string productID_1 = "com.unity.inapp1200";
    string productID_2 = "com.unity.inapp2500";
#endif

    public Image userImage;
    public Text displayNameText;
    public Text uniqueIdText;    
    public Text emailText;

    public Text rawJsonText;
    
    string helpUrl = "https://support.google.com/?hl=ko";

    void Start()
    {
        LoginResult result = UserInfoManager.Instance.loginResult;
        StartCoroutine(UpdateProfile(result.UserProfile));
        UpdateRawSection(result);


#if UNITY_ANDROID
        var scopes = new string[] { "boxer_unity1000", "boxer_unity2000" };
#elif UNITY_IOS
        var scopes = new string[] { "com.unity.inapp1200", "com.unity.inapp2500" };        
#endif
        UniversalSDK.Ins.InitBilling(scopes, res =>
        {
            res.Match(
                value =>
                {
                },
                error =>
                {
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
                    SceneManager.LoadSceneAsync("Login");
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }
    public void OnClickInPurchase1200()
    {
        UniversalSDK.Ins.InAppPurchase(productID_1, result =>
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
    public void OnClickInPurchase2500()
    {
        UniversalSDK.Ins.InAppPurchase(productID_2, result =>
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

    IEnumerator UpdateProfile(UserProfile profile)
    {
        if (profile.PhotoURL != null)
        {
            var www = UnityWebRequestTexture.GetTexture(profile.PhotoURL);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
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
        displayNameText.text = profile.DisplayName;
        uniqueIdText.text = profile.UserID;
        emailText.text = profile.Email;
    }
}
