
# Setting up your project

Universal SDK 는 iOS 또는 안드로이드 플랫폼에서 Universal SDK 를 사용할 수 있는 인터페이스를 제공합니다. Unity Editor 에서 Universal SDK 를 사용하고 이를 플랫폼으로 내보내기 위해서는 몇 가지 개발 환경이 필요합니다.

## Unity requirements

+ iOS 및 Android 모듈이 설치된 Unity 2017.4 이상
+ Unity Personal, Unity Plus 또는 Unity Pro의 유효한 구독

## Installation on iOS

Unity iOS 환경에서 Universal SDK를 연동하기 위한 필요 조건:

+ iOS 10.0 or higher as the deployment target
+ Xcode 10 or higher

iOS에서 Universal SDK 는 UniversalSDK.framework 의 래퍼 역할을 합니다. iOS의 프로젝트에 Universal SDK 를 추가하려면 UniversalSDK.framework 을 수동으로 추가해야 합니다.

## Installation on Android

유니티에서 안드로이드 빌드를 위해서는 Android SDK 설치을 해야 합니다. 만약 이전에 유니티 안드로이드 개발을 위한 설정을 했다면 이미 Android SDK 가 설치되어 있습니다.

## Setting up gradle

[Target api 30을 지원](https://stackoverflow.com/questions/62969917/how-to-fix-unexpected-element-queries-found-in-manifest-error)하려면 baseProjectTemplate.gradle 참조하여 설정하십시오 :

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
[resolver](https://github.com/googlesamples/unity-jar-resolver) 을 사용하신다면 UniversalSDKDependencies.xml 을 참조하십시오

## Plugins Settting

`Assets/UniversalSDK/Plugins` 에서 `Assets/Plugins` 로 플러그인 폴더경로를 이동시켜주세요.

![](https://github.com/jameschun7/universal-sdk-unity-demo/blob/main/img/plugins-move.png?raw=true)

# Setup Social Login

소셜 로그인별 설정 방법을 참조하십시오:

## Android

### Google Login

1. [Firebase Console](https://console.firebase.google.com)에서 **안드로이드 앱을 생성합니다.**
   
   업로드키 인증서 등록하기 (SHA-1 of Keystore used when building APK)
   
   [Firebase Console](https://console.firebase.google.com)에서  **프로젝트 설정 > 일반 > 지원 이메일 설정**.

![support email](https://user-images.githubusercontent.com/20632507/136521132-a91808b7-d0cb-4b1b-814f-74eb03334db5.png)

2. 아래와 같이 인증서 지문을 등록하면 Google API Console 에 API 키가 자동생성 됩니다.

![aos-google-step1](https://user-images.githubusercontent.com/20632507/145372069-76981a90-a1af-4686-8798-b73a52641aa0.png)

3. [Google API Console](https://console.developers.google.com/apis/credentials) 에 접속. Client ID 복사 **(Web Client ID).**

![aos-google-step2](https://user-images.githubusercontent.com/20632507/145372120-0f2047d9-ce5b-42eb-9624-a5401c2a9ad2.png)

### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) > App ID 복사.

### Apple Login

1. Identifiers 메뉴에서 "+" 버튼을 클릭.

![apple-login1](https://user-images.githubusercontent.com/20632507/140308507-7158e7f0-884a-46c0-bf04-2df2b785978f.png)

2. Apple에 로그인한 사용자에 대한 정보를 수신하기 위해 서비스 ID를 등록합니다.

![apple-login2](https://user-images.githubusercontent.com/20632507/140308587-75e719f4-b1d2-4f1f-b632-f474ffe7bc0e.png)

3. Description은 Apple 로그인 시 게임 이름이 노출될 공간입니다.(수정 가능)   
   도메인 이름을 포함하도록 Identifier를 작성하십시오.(단, AppID와 다르게 작성해주세요.)

![apple-login3](https://user-images.githubusercontent.com/20632507/140308628-4556783e-1b72-4727-9f64-ab7742f81bfb.png)

4. Services ID가 등록되어 있으면 Identifiers 메뉴 목록에서 등록된 Services ID를 클릭하여 설정 페이지로 이동합니다.

![apple-login4](https://user-images.githubusercontent.com/20632507/140308696-e4e9f4fc-acc7-43fc-a055-749ea7229b32.png)

5. 웹사이트 URL 옆에 있는 "+" 버튼을 클릭합니다.
   * Primary App ID: 연결할 앱 ID 선택
   * Domains and Subdomains : 리디렉션 URL의 도메인을 입력하세요.
   * Return URLs : Apple 서버에서 리디렉션을 수신하려면 URL을 입력하십시오. **(백엔드에서 post로 받으신 후 redirect 하셔야 합니다.)**

![apple-login5](https://user-images.githubusercontent.com/20632507/140308771-a0c81456-6e29-4916-b41e-0ed64f3897c5.png)

### 프로젝트에 소셜 ID 적용

Assets/Plugins/Android/launcherTemplate.gradle 을 편집해주세요
체크박스를 활성화시키면 파일이 생성됩니다.

![check-gradle](https://user-images.githubusercontent.com/20632507/159444201-e56789e8-4ae7-4262-8a0b-325bdab590f6.png)

아래 resValue 줄을 넣어주세요. 그래도 안된다면 [Demo](https://github.com/coolishbee/universal-sdk-unity-demo) 프로젝트를 참고해주세요.

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

## iOS

### Google Login

1. Firebase 콘솔에 iOS 앱 등록

2. [Google API Console](https://console.developers.google.com/apis/credentials) 로그인

![ios-google-step2](https://user-images.githubusercontent.com/20632507/145372659-db92570f-0762-4151-bbcf-0f38f197127d.png)

3. 클라이언트 ID(google_web_client_id) 및 iOS URL scheme(REVERSED Client ID)를 복사합니다.

![ios-google-step3](https://user-images.githubusercontent.com/20632507/140313293-0b460dbb-abe9-418c-b247-04d2ed16a919.png)

### Facebook Login

[Developer Facebook Console](https://developers.facebook.com/apps) > App ID 복사.

### Apple Login

1. Apple Developer Console > Identifiers > App ID Configuration 편집 > Sign In with Apple 체크박스 활성화.
2. Universal iOS SDK > Apple Login 체크박스 활성화.

### Settings in Tools > UniversalSDK > Edit Settings

* [Google API Console](https://console.developers.google.com/apis/credentials)에서 프로젝트와 OAuth 2.0 항목을 선택하면 기존 프로젝트의 web client ID와 iOS URL schema를 확인할 수 있다. (iOS 플랫폼을 확인해주세요)
* Facebook 앱 ID 값을 입력합니다.
* Apple 로그인을 활성화하면 Unity 빌드 시 Capability 설정도 자동으로 설정됩니다.

![ios-sdk-editor](https://user-images.githubusercontent.com/20632507/143774011-c959f885-5ce2-407d-9283-7a3472b728ea.png)


# Integrating Universal SDK with your Unity game

## Scene에 UniversalSDK 프리팹 추가

패키지를 가져온 후 **Project** 패널에서 `Assets/UniversalSDK/` 아래에 **UniversalSDK** 프리팹을 찾을 수 있습니다. 로그인을 추가하려는 scene의 **Hierarchy** 패널로 드래그합니다:

![add prefab](https://user-images.githubusercontent.com/20632507/136521043-f4f8d88d-0c7f-4df6-a30c-e741076debe2.png)

## Update player settings

게임에서 Universal SDK API 사용하기 전에 아래 단계에 따라 프로젝트 플레이어 설정이 올바른지 확인하세요.

### Android 빌드 설정

1. **File > Build Settings** 선택.
2. **Player Settings** 클릭.
3. Platform > **Other Settings** 선택.
4. **Minimum API Level**을 **API level 19** 이상으로 설정합니다.
5. **Target API Level**을 **API Level 29 and 30** 으로 설정합니다.
6. **Publishing Settings**에서 **Custom Gradle Template**을 활성화합니다. (.gradle 파일을 'Assets/UniversalSDK/Plugins/Android'에서 'Assets/Plugins/Android'로 이동합니다.)

### iOS 빌드 설정

1. **File > Build Settings** 선택.
2. **Player Settings** 클릭.
3. Platform > **Other Settings** 선택.
4. **Target minimum iOS 버전**을 `10.0` 이상으로 설정합니다.

## Implement login with Social

이제 UniversalSDK(GameObject)가 있는 scene에서 Social을 통한 로그인을 구현할 수 있습니다:

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

Unity용 Universal SDK는 현재 iOS 및 Android만 지원합니다. Unity 에디터 플레이 모드에서 실행하면 항상 오류를 반환합니다. 테스트하려면 장면을 iOS 또는 Android 장치로 내보내야 합니다.

CocoaPods를 종속성 관리자로 사용하는 경우 Xcode 프로젝트에 게임을 빌드한 후 원본 `Unity-iPhone.xcodeproj` 대신 `Unity-iPhone.xcworkspace` 파일을 엽니다.

## Logout

소셜 로그인 시 안드로이드 구글만 `로그아웃`을 지원합니다. 기타 소셜 로그인은 각 소셜 설정을 통해 로그아웃해 주세요.

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

SDK와 관련된 기능 요청 및 버그 보고서를 보려면 이 저장소의 [Github 이슈 트래커](https://github.com/jameschun7/universal-sdk-unity/issues)를 방문하세요.

기타 질문이 있으시면 chc3484@gmail.com으로 이메일을 보내주십시오.
