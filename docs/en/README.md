
# Setting up your project

The Universal SDK for Unity provides an interface for using Universal SDK on either iOS or Android platform. To use Universal SDK in Unity Editor and export it to a platform, your development environment needs a few things.

## Unity requirements

+ Unity 2017.4 or later, with iOS and Android modules installed
+ A valid subscription for Unity Personal, Unity Plus, or Unity Pro

## Installation on iOS

To integrate Universal SDK for Unity on iOS, you need:

+ iOS 10.0 or higher as the deployment target
+ Xcode 10 or higher

On iOS, Universal SDK for Unity works as a wrapper for the Universal SDK for iOS. You must manually add framework to your project on iOS.(`UniversalSDKSwift.framework` is located in the `Plugins` folder)

## Installation on Android

You must have the Android SDK installed, because Unity will use it to build your project to the Android platform. If you have previously [configured Unity for Android development (opens new window)](https://docs.unity3d.com/Manual/android-sdksetup.html), you already have the Android SDK.

## Setting up gradle

[To support target api 30](https://stackoverflow.com/questions/62969917/how-to-fix-unexpected-element-queries-found-in-manifest-error), please refer to baseProjectTemplate.gradle setting :

```groovy
//Unity 2019.4 or prev
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
//Unity 2020.3 or higher
allprojects {
    buildscript {
        ...
        }

        dependencies {            
            classpath 'com.android.tools.build:gradle:4.0.1'
            classpath "org.jetbrains.kotlin:kotlin-gradle-plugin:1.3.11"
            **BUILD_SCRIPT_DEPS**
        }
    }
}
```

mainTemplate.gradle :

```groovy
dependencies {
    implementation fileTree(dir: 'libs', include: ['*.jar'])

    implementation 'io.github.jameschun7:universalsdk:1.1.5' //added

    implementation 'com.google.code.gson:gson:2.8.5' //added
    implementation "org.jetbrains.kotlin:kotlin-stdlib-jdk7:1.3.11" //added

**DEPS**}
```

### Resolver usage
For [resolver](https://github.com/googlesamples/unity-jar-resolver) users, please refer to UniversalSDKDependencies.xml

## Plugins Settting

You should set it like this to avoid plugin conflicts.
Move the Plugins Folder from `Assets/UniversalSDK/Plugins` to `Assets/Plugins`.

![](https://github.com/jameschun7/universal-sdk-unity-demo/blob/main/img/plugins-move.png?raw=true)

# Setup Social Login

Please refer to the setting method for each social login:

## Android

### Google Login

1. [Firebase Console](https://console.firebase.google.com) **Register Android App.**
   
   Register upload key certificate (SHA-1 of Keystore used when building APK)
   
   Select on [Firebase Console](https://console.firebase.google.com)  **Project Settings > General > Support email Setting**.

![support email](https://user-images.githubusercontent.com/20632507/136521132-a91808b7-d0cb-4b1b-814f-74eb03334db5.png)

2. When you register your Firebase app and register your certificate thumbprint, an API key is automatically generated.

![aos-google-step1](https://user-images.githubusercontent.com/20632507/145372069-76981a90-a1af-4686-8798-b73a52641aa0.png)

3. Access the [Google API Console](https://console.developers.google.com/apis/credentials). Copy the Client ID **(Web Client ID).**

![aos-google-step2](https://user-images.githubusercontent.com/20632507/145372120-0f2047d9-ce5b-42eb-9624-a5401c2a9ad2.png)

### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) >  Copy the App ID.

### Apple Login

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

### Apply social id to project

Please edit your Assets/Plugins/Android/launcherTemplate.gradle
Activate the checkbox to create a file.

![check-gradle](https://user-images.githubusercontent.com/20632507/159444201-e56789e8-4ae7-4262-8a0b-325bdab590f6.png)

Insert the line resValue. If you are not sure, please refer to the [Demo](https://github.com/coolishbee/universal-sdk-unity-demo).

launcherTemplate.gradle :

```groovy
dependencies {
    implementation project(':unityLibrary')
    implementation 'androidx.multidex:multidex:2.0.1' //added
    ...
    }
android {
    ...
    defaultConfig {
        ...
        multiDexEnabled true //added

        resValue("string", "facebook_app_id", "com.your.app.id.here")
        resValue("string", "google_web_client_id", "com.your.client.id.here")
        resValue("string", "apple_client_id", "com.your.service.id.here")
        resValue("string", "redirect_url", "your.return.url.here")
    }
    ...
```

## iOS

### Google Login

1. Register your iOS app in the Firebase console

2. Access the [Google API Console](https://console.developers.google.com/apis/credentials).

![ios-google-step2](https://user-images.githubusercontent.com/20632507/145372659-db92570f-0762-4151-bbcf-0f38f197127d.png)

3. Copy the client ID (google_web_client_id) and iOS URL scheme (REVERSED Client ID).

![ios-google-step3](https://user-images.githubusercontent.com/20632507/140313293-0b460dbb-abe9-418c-b247-04d2ed16a919.png)

### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) >  Copy the App ID.

### Apple Login

1. Apple Developer Console > Identifiers > Edit your App ID Configuration > Sign In with Apple Check.
2. Universal iOS SDK > Apple Login Enable Check.

### Settings in Tools > UniversalSDK > Edit Settings

* If you select the project and OAuth 2.0 items in the [Google API Console](https://console.developers.google.com/apis/credentials), you can check the web client ID and iOS URL schema of the existing project. (Please check the iOS platform)
* Enter a value for Facebook App ID.
* If you enable Apple Login, even the Capability setting is automatically set when building Unity.

![ios-sdk-editor](https://user-images.githubusercontent.com/20632507/143774011-c959f885-5ce2-407d-9283-7a3472b728ea.png)



# Integrating Universal SDK with your Unity game

## Add UniversalSDK prefab to your scene

After importing the package, in your **Project** panel, you'll find a **UniversalSDK** prefab under `Assets/UniversalSDK/`. Drag it to the **Hierarchy** panel of the scene to which you want to add Universal Login:

![add prefab](https://user-images.githubusercontent.com/20632507/136521043-f4f8d88d-0c7f-4df6-a30c-e741076debe2.png)

## Update player settings

Before you continue to implement use Universal SDK APIs in your game, follow the steps below to make sure your project player setting is correct.

### Settings for Android export

1. Select **File > Build Settings**.
2. Click **Player Settings**.
3. Select Platform > **Other Settings**.
4. Set **Minimum API Level** to at least **API level 19**.
5. Set **Target API Level** to **API Level 29 and 30.**
6. Under **Publishing Settings**, enable **Custom Gradle Template**. (Move the .gradle files from 'Assets/UniversalSDK/Plugins/Android' to 'Assets/Plugins/Android'.)

### Settings for iOS export

1. Select **File > Build Settings**.
2. Click **Player Settings**.
3. Select Platform > **Other Settings**.
4. Set **Target minimum iOS Version** to at least `10.0`.

## Implement login with Social

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

## Logout

During social login, only Android Google supports `Logout`. For other social logins, please log out through each social setting.

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

## ErrorCode

| Error                      | Code | Desc                         |
| -------------------------- | ---- | ---------------------------- |
| CANCEL                     | 1100 | User Cancel                  |
| AUTHENTICATION_AGENT_ERROR | 1101 | Unknown authentication error |
| PURCHASE_ERROR             | 1102 | Unknown payment error        |

# Support

Please visit this repository's [Github issue tracker](https://github.com/jameschun7/universal-sdk-unity/issues) for feature requests and bug reports related specifically to the SDK.

For other any questions, send us an email to chc3484@gmail.com
