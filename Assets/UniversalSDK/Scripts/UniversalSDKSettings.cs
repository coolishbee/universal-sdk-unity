using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    public class UniversalSDKSettings : ScriptableObject
    {
        public const string settingsAssetName = "UniversalSDKSettings";
        public const string settingsPath = "UniversalSDK/Resources";
        public const string settingsAssetExtension = ".asset";

        private static UniversalSDKSettings instance;

        public static UniversalSDKSettings Instance
        {
            get
            {
                if (ReferenceEquals(instance, null))
                {
                    instance = Resources.Load(settingsAssetName) as UniversalSDKSettings;
                    if (ReferenceEquals(instance, null))
                    {
                        instance = CreateInstance<UniversalSDKSettings>();
                    }
                }
                return instance;
            }
        }
        
        [SerializeField]
        private bool devBuild = true;

        [SerializeField]
        private bool appleLogin = false;
        [SerializeField]
        private bool facebookLogin = false;
        [SerializeField]
        private bool googleLogin = false;

        [SerializeField]
        private string facebookAppID = "";
        [SerializeField]
        private string googleClientID = "";
        [SerializeField]
        private string reversedClientID = "";        

        public static bool DevBuild
        {
            get { return Instance.devBuild; }
            set { Instance.devBuild = value; }
        }

        public static bool UseAppleLogin
        {
            get { return Instance.appleLogin; }
            set { Instance.appleLogin = value; }
        }

        public static bool UseFacebookLogin
        {
            get { return Instance.facebookLogin; }
            set { Instance.facebookLogin = value; }
        }

        public static bool UseGoogleLogin
        {
            get { return Instance.googleLogin; }
            set { Instance.googleLogin = value; }
        }

        public static string FacebookAppID
        {
            get { return Instance.facebookAppID; }
            set { Instance.facebookAppID = value; }
        }

        public static string GoogleClientID
        {
            get { return Instance.googleClientID; }
            set { Instance.googleClientID = value; }
        }

        public static string ReversedClientID
        {
            get { return Instance.reversedClientID; }
            set { Instance.reversedClientID = value; }
        }
    }
}