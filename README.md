# Universal SDK for Unity

The Universal SDK for Unity provides a modern way of implementing InApp Purchase and Social Login APIs. The features included in this SDK will help you develop a Unity game with an engaging and personalized user experience.

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

### Dependency

#### Android

```groovy
implementation 'com.google.firebase:firebase-messaging:22.0.0'
implementation 'android.arch.work:work-runtime:1.0.1'
implementation 'com.android.billingclient:billing:3.0.3'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
implementation 'com.facebook.android:facebook-login:8.2.0'
implementation 'com.google.androidbrowserhelper:androidbrowserhelper:2.3.0'
```

#### iOS

```ruby
'GoogleSignIn', '~> 5.0'
'FBSDKLoginKit', '~> 9.0'
```

## Setting up your project

The Universal SDK for Unity provides an interface for using Universal SDK on either iOS or Android platform. To use Universal SDK in Unity Editor and export it to a platform, your development environment needs a few things.

### Unity requirements

+ Unity 2017.4 or later, with iOS and Android modules installed
+ A valid subscription for Unity Personal, Unity Plus, or Unity Pro

### Installation on iOS

To integrate Universal SDK for Unity on iOS, you need:

+ iOS 10.0 or higher as the deployment target
+ Xcode 10 or higher

On iOS, Universal SDK for Unity works as a wrapper for the Universal SDK for iOS Objc. You must use a manual to add the Universal SDK for iOS Objc to your project on iOS.

### Installation on Android

You must have the Android SDK installed, because Unity will use it to build your project to the Android platform. If you have previously [configured Unity for Android development (opens new window)](https://docs.unity3d.com/Manual/android-sdksetup.html), you already have the Android SDK.

> ### Unity 2019.4 or prev

[To support target api 30](https://stackoverflow.com/questions/62969917/how-to-fix-unexpected-element-queries-found-in-manifest-error), please refer to baseProjectTemplate.gradle setting :

```groovy
allprojects {
    buildscript {
        ...
        }

        dependencies {            
            classpath 'com.android.tools.build:gradle:3.4.3'
            classpath "org.jetbrains.kotlin:kotlin-gradle-plugin:1.3.11"
            classpath 'com.google.gms:google-services:4.3.0'
            **BUILD_SCRIPT_DEPS**
        }
    }
}
```

## Setup Social Login

Please refer to the setting method for each social login:

### Android

> #### Google Login

1. [Firebase Console](https://console.firebase.google.com) **Register Android App.**
   
   Register upload key certificate (SHA-1 of Keystore used when building APK)
   
   Select on [Firebase Console](https://console.firebase.google.com)  **Project Settings > General > Support email Setting**.

![support email](https://user-images.githubusercontent.com/20632507/136521132-a91808b7-d0cb-4b1b-814f-74eb03334db5.png)

2. When you register your Firebase app and register your certificate thumbprint, an API key is automatically generated.

![aos-google-step1](https://user-images.githubusercontent.com/20632507/145372069-76981a90-a1af-4686-8798-b73a52641aa0.png)

3. Access the [Google API Console](https://console.developers.google.com/apis/credentials). Copy the Client ID **(Web Client ID).**

![aos-google-step2](https://user-images.githubusercontent.com/20632507/145372120-0f2047d9-ce5b-42eb-9624-a5401c2a9ad2.png)

> #### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) >  Copy the App ID.

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

3. Copy the converted google-services.xml file to `Assets/Plugins/Android/res/values`.

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

When you log in, a pushtoken is issued through LoginResult.

### ErrorCode

| Error                      | Code | Desc                         |
| -------------------------- | ---- | ---------------------------- |
| CANCEL                     | 1100 | User Cancel                  |
| AUTHENTICATION_AGENT_ERROR | 1101 | Unknown authentication error |
| PURCHASE_ERROR             | 1102 | Unknown payment error        |

## Support

Please visit this repository's [Github issue tracker](https://github.com/jameschun7/universal-sdk-unity/issues) for feature requests and bug reports related specifically to the SDK.

For other any questions, send us an email to chc3484@gmail.com
