#if !UNITY_IOS && !UNITY_ANDROID
namespace Universal.UniversalSDK
{
    public class NativeInterface
    {
        public static void SetupSDK() { }
        public static void Login(string identifier, LoginType loginType) { }
        public static void Logout(string identifier) { }
        public static void OpenCustomTabView(string identifier, string url) { }
    }
}
#endif