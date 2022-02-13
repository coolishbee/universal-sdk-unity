# Universal SDK for Unity

Universal SDK 는 인앱 구매 및 소셜 로그인 API를 구현하는 현대적인 방법을 제공합니다. 이 SDK 에 포함된 기능을 통해 사용자 환경에 맞는 유니티 게임을 개발할 수 있습니다.

## Overview

### Features

#### Android

- Google Login
- Facebook Login
- Apple Login
- Google Play Billing Library v3
- Firebase Cloud Messaging (FCM)
- AndroidX Support
- Chrome Custom Tabs

#### iOS

- Google Login
- Facebook Login
- Apple Login
- Apple In-App Purchase StoreKit
- Apple Push Notification service (APNs)
- Capability Support
- Safari View Controller

## Setting up your project

Universal SDK 는 iOS 또는 안드로이드 플랫폼에서 Universal SDK 를 사용할 수 있는 인터페이스를 제공합니다. Unity Editor 에서 Universal SDK 를 사용하고 이를 플랫폼으로 내보내기 위해서는 몇 가지 개발 환경이 필요합니다.

### Unity requirements

+ iOS 및 Android 모듈이 설치된 Unity 2017.4 이상
+ Unity Personal, Unity Plus 또는 Unity Pro의 유효한 구독

### Installation on iOS

Unity iOS 환경에서 Universal SDK를 연동하기 위한 필요 조건:

+ iOS 10.0 or higher as the deployment target
+ Xcode 10 or higher

iOS에서 Universal SDK 는 UniversalSDK.framework 의 래퍼 역할을 합니다. iOS의 프로젝트에 Universal SDK 를 추가하려면 UniversalSDK.framework 을 수동으로 추가해야 합니다.

### Installation on Android

유니티에서 안드로이드 빌드를 위해서는 Android SDK 설치을 해야 합니다. 만약 이전에 유니티 안드로이드 개발을 위한 설정을 했다면 이미 Android SDK 가 설치되어 있습니다.

> ### Unity 2019.4 or prev

[Target api 30을 지원](https://stackoverflow.com/questions/62969917/how-to-fix-unexpected-element-queries-found-in-manifest-error)하려면 baseProjectTemplate.gradle 참조하여 설정하십시오 :

```groovy
allprojects {
    buildscript {
        ...
        }

        dependencies {            
            classpath 'com.android.tools.build:gradle:3.4.3'
            classpath "org.jetbrains.kotlin:kotlin-gradle-plugin:1.3.11"
            **BUILD_SCRIPT_DEPS**
        }
    }
}
```

## Setup Social Login

소셜 로그인별 설정 방법을 참조하십시오:

### Android

> #### Google Login

1. [Firebase Console](https://console.firebase.google.com)에서 **안드로이드 앱을 생성합니다.**
   
   업로드키 인증서 등록하기 (SHA-1 of Keystore used when building APK)
   
   [Firebase Console](https://console.firebase.google.com)에서  **프로젝트 설정 > 일반 > 지원 이메일 설정**.

![support email](https://user-images.githubusercontent.com/20632507/136521132-a91808b7-d0cb-4b1b-814f-74eb03334db5.png)

2. 아래와 같이 인증서 지문을 등록하면 Google API Console 에 API 키가 자동생성 됩니다.

![aos-google-step1](https://user-images.githubusercontent.com/20632507/145372069-76981a90-a1af-4686-8798-b73a52641aa0.png)

3. [Google API Console](https://console.developers.google.com/apis/credentials) 에 접속. Client ID 복사 **(Web Client ID).**

![aos-google-step2](https://user-images.githubusercontent.com/20632507/145372120-0f2047d9-ce5b-42eb-9624-a5401c2a9ad2.png)

> #### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) > App ID 복사.

> #### Apple Login

1. Go to the Identifiers menu and click the "+" button.

![apple-login1](https://user-images.githubusercontent.com/20632507/140308507-7158e7f0-884a-46c0-bf04-2df2b785978f.png)

2. We will register a Services ID to receive information about users who have signed in with Apple.

![apple-login2](https://user-images.githubusercontent.com/20632507/140308587-75e719f4-b1d2-4f1f-b632-f474ffe7bc0e.png)

3. Description is the space where the game name will be exposed when Apple Login. (can be modified) 
   
   Please write the Identifier to include the domain name. (However, please write it differently from AppID.)

![apple-login3](https://user-images.githubusercontent.com/20632507/140308628-4556783e-1b72-4727-9f64-ab7742f81bfb.png)

4. If the Services ID is registered, click the registered Services ID in the Identifiers menu list to go to the setting page.

![apple-login4](https://user-images.githubusercontent.com/20632507/140308696-e4e9f4fc-acc7-43fc-a055-749ea7229b32.png)

5. click the "+" button next to the Website URLs.
   * Primary App ID: Select an App ID to connect
   * Domains and Subdomains : Please enter the domain of the redirect url.
   * Return URLs : Please Enter the URL to receive redirect from Apple server. **(You must redirect after receiving it as a post.)**

![apple-login5](https://user-images.githubusercontent.com/20632507/140308771-a0c81456-6e29-4916-b41e-0ed64f3897c5.png)

> #### Set launcherTemplate.gradle

```groovy
dependencies {
    ...
    }
android {
    ...
    defaultConfig {
        ...
        resValue("string", "facebook_app_id", "com.your.app.id.here")
        resValue("string", "google_web_client_id", "com.your.client.id.here")
        resValue("string", "apple_client_id", "com.your.service.id.here")
        resValue("string", "redirect_url", "your.return.url.here")
    }
    ...
```

### iOS

> #### Google Login

1. Register your iOS app in the Firebase console

2. Access the [Google API Console](https://console.developers.google.com/apis/credentials).

![ios-google-step2](https://user-images.githubusercontent.com/20632507/145372659-db92570f-0762-4151-bbcf-0f38f197127d.png)

3. Copy the client ID (google_web_client_id) and iOS URL scheme (REVERSED Client ID).

![ios-google-step3](https://user-images.githubusercontent.com/20632507/140313293-0b460dbb-abe9-418c-b247-04d2ed16a919.png)

> #### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) >  Copy the App ID.

> #### Apple Login

1. Apple Developer Console > Identifiers > Edit your App ID Configuration > Sign In with Apple Check.
2. Universal iOS SDK > Apple Login Enable Check.

> #### Settings in Tools > UniversalSDK > Edit Settings

* If you select the project and OAuth 2.0 items in the [Google API Console](https://console.developers.google.com/apis/credentials), you can check the web client ID and iOS URL schema of the existing project. (Please check the iOS platform)
* Enter a value for Facebook App ID.
* If you enable Apple Login, even the Capability setting is automatically set when building Unity.

![ios-sdk-editor](https://user-images.githubusercontent.com/20632507/143774011-c959f885-5ce2-407d-9283-7a3472b728ea.png)

## Setup IAP

Please refer to the setting method for each store:

> ### Google Store

Please register your in-app product in [Google Play Developer Console](https://play.google.com/apps/publish). **(However, only consumables are supported)**

> ### Apple

Please register your in-app product in [Apple Developer Center](https://developer.apple.com/account). **(However, only consumables are supported)**

## Setup Push

### FCM

1. Select on [Firebase Console](https://console.firebase.google.com)  **Project Settings > General > Download the google-services.json**.

2. Convert the google-services.json file to xml format. File conversion is supported by [Convert google-services.json to values XML](https://dandar3.github.io/android/google-services-json-to-xml.html).

3. Copy the converted google-services.xml file to `Assets/Plugins/Android/FirebaseApp.androidlib/res/values`. (If you are using firebase unity sdk, you can skip it.)

### APNS

Apple Developer Center > Keys > Create Key(+) > Register a New Key > Generate Key ID.

![apns-1](https://user-images.githubusercontent.com/20632507/140489272-7bd168e1-f3f8-4ed4-a9ee-178deb7f4bb4.png)

### How to use the TEST TOOL

* [PushNotifications Tool](https://github.com/onmyway133/PushNotifications)

## Integrating Universal SDK with your Unity game

### Add UniversalSDK prefab to your scene

After importing the package, in your **Project** panel, you'll find a **UniversalSDK** prefab under `Assets/UniversalSDK/`. Drag it to the **Hierarchy** panel of the scene to which you want to add Universal Login:

![add prefab](https://user-images.githubusercontent.com/20632507/136521043-f4f8d88d-0c7f-4df6-a30c-e741076debe2.png)

### Update player settings

Before you continue to implement use Universal SDK APIs in your game, follow the steps below to make sure your project player setting is correct.

> #### Settings for Android export

1. Select **File > Build Settings**.
2. Click **Player Settings**.
3. Select Platform > **Other Settings**.
4. Set **Minimum API Level** to at least **API level 19**.
5. Set **Target API Level** to **API Level 29 and 30.**
6. Under **Publishing Settings**, enable **Custom Gradle Template**. (Move the .gradle files from 'Assets/UniversalSDK/Plugins/Android' to 'Assets/Plugins/Android'.)

> #### Settings for iOS export

1. Select **File > Build Settings**.
2. Click **Player Settings**.
3. Select Platform > **Other Settings**.
4. Set **Target minimum iOS Version** to at least `10.0`.

### Implement login with Social

Now, you can implement login with Social in the scene where the UniversalSDK (GameObject) exists. For example:

```csharp
using Universal.UniversalSDK;

public class LoginController : MonoBehaviour {
    public void OnClickExampleLogin()
    {        
        UniversalSDK.Ins.Login(LoginType.GOOGLE,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateLoginResult(value);
                    },
                    error =>
                    {
                        messageText.text = error.Message;
                    });
            });
    }
}
```

Universal SDK for Unity supports only iOS and Android for now. It will always return an error if you run it in Unity Editor play mode. To test it, you need to export your scene to either an iOS or Android device.

If you are using CocoaPods as your dependency manager, after building the game to an Xcode project, open the `Unity-iPhone.xcworkspace` file instead of the original `Unity-iPhone.xcodeproj`.

### Logout

During social login, only Google supports `Logout`. For other social logins, please log out through each social setting.

```c#
UniversalSDK.Ins.Logout(result =>
{
    result.Match(
        value =>
        {
            //value.Code
            //value.Message
        },
        error =>
        {
            //error.Code
            //error.Message
        });
});
```

### Purchase

#### InitBilling

After initializing the payment module, a list of in-app products available for purchase is delivered.

```c#
var scopes = new string[] { "com.unity.inapp1200", "com.unity.inapp2500" };
UniversalSDK.Ins.InitBilling(scopes, result =>
{
    result.Match(
        value =>
        {          
            for (int i = 0; i < value.Products.Length; i++)
            {
                UpdateRawSection(value.Products[i]);
            }                              
        },
        error =>
        {
            titleText.text = error.Code.ToString();
            messageText.text = error.Message;
            popup_panel.SetActive(true);
        });
});
```

#### Restore Purchase

Payment information list is delivered after processing for unconsumed payments. (Callable only after payment initialization)

```c#
UniversalSDK.Ins.RestorePurchases(result =>
{
    result.Match(
        value =>
        {
            if(value.PurchaseDatas != null)
            {
                foreach (PurchaseData data in value.PurchaseDatas)
                {
                    UpdateRawSection(data);
                }
            }
            else
            {
                Debug.Log("PurchaseDatas is NULL");
            }                    
        },
        error =>
        {
            UpdateRawSection(error);
        });
});
```

#### In-app product payment

Google and Apple payments are possible with one of the functions below.

```c#
UniversalSDK.Ins.InAppPurchase("product_id", result =>
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
```

#### Each Store Error Message

* [Google Store](https://developer.android.com/reference/com/android/billingclient/api/BillingClient.BillingResponseCode?hl=ko)
* [Apple Store](https://developer.apple.com/documentation/storekit/skerror#topics)

### Push

When you log in, a pushtoken is generated through LoginResult.

### ErrorCode

| Error                      | Code | Desc                         |
| -------------------------- | ---- | ---------------------------- |
| CANCEL                     | 1100 | User Cancel                  |
| AUTHENTICATION_AGENT_ERROR | 1101 | Unknown authentication error |
| PURCHASE_ERROR             | 1102 | Unknown payment error        |

## Support

Please visit this repository's [Github issue tracker](https://github.com/jameschun7/universal-sdk-unity/issues) for feature requests and bug reports related specifically to the SDK.

For other any questions, send us an email to chc3484@gmail.com
