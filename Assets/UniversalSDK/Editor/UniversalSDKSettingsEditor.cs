using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Universal.UniversalSDK.Editor
{
    [CustomEditor(typeof(UniversalSDKSettings))]
    public class UniversalSDKSettingsEditor : UnityEditor.Editor
    {
        GUIContent facebookAppIDLabel = new GUIContent("Facebook AppID [?]:", "Facebook AppId can be found at https://developers.facebook.com/apps");
        GUIContent facebookClientTokenLabel = new GUIContent("Facebook ClientToken [?]:", "Facebook ClientToken can be found at https://developers.facebook.com/apps");
        GUIContent googleClientIDLabel = new GUIContent("GoogleClientID [?]:", "GoogleClientID can be found at https://console.developers.google.com/apis/credentials");
        GUIContent reversedClientIDLabel = new GUIContent("ReversedClientID [?]:", "ReversedClientID can be found at https://console.developers.google.com/apis/credentials");

        GUIContent useAppleLoginLabel = new GUIContent("Use AppleLogin [?]:", "Run app with extended debugging");
        GUIContent useFacebookLoginLabel = new GUIContent("Use FacebookLogin [?]:", "Run app with extended debugging");
        GUIContent useGoogleLoginLabel = new GUIContent("Use GoogleLogin [?]:", "Run app with extended debugging");
        GUIContent devBuildLabel = new GUIContent("Dev Build [?]:", "Run app with extended debugging");

        const string UnityAssetFolder = "Assets";
        
        public static UniversalSDKSettings GetOrCreateSettingsAsset()
        {
            // Construct the full path to the settings asset.
            string fullPath = Path.Combine(UnityAssetFolder, "Editor", "Resources", UniversalSDKSettings.settingsPath, 
                UniversalSDKSettings.settingsAssetName + UniversalSDKSettings.settingsAssetExtension);

            // Try to load the settings asset.
            UniversalSDKSettings instance = AssetDatabase.LoadAssetAtPath<UniversalSDKSettings>(fullPath);

            // If the asset doesn't exist, create it.
            if (instance == null)
            {
                // Ensure the Editor folder exists.
                string editorFolderPath = Path.Combine(UnityAssetFolder, "Editor");
                if (!Directory.Exists(editorFolderPath))
                {
                    AssetDatabase.CreateFolder(UnityAssetFolder, "Editor");
                }

                // Ensure the Resources folder exists within the Editor folder.
                string resourcesFolderPath = Path.Combine(editorFolderPath, "Resources");
                if (!Directory.Exists(resourcesFolderPath))
                {
                    AssetDatabase.CreateFolder(editorFolderPath, "Resources");
                }

                // Ensure the settings path exists within the Resources folder.
                string settingsFolderPath = Path.Combine(resourcesFolderPath, UniversalSDKSettings.settingsPath);
                if (!Directory.Exists(settingsFolderPath))
                {
                    AssetDatabase.CreateFolder(resourcesFolderPath, UniversalSDKSettings.settingsPath);
                }

                // Create a new settings asset.
                instance = ScriptableObject.CreateInstance<UniversalSDKSettings>();
                AssetDatabase.CreateAsset(instance, fullPath);
                AssetDatabase.SaveAssets();
            }

            return instance;
        }

        [MenuItem("Tools/UniversalSDK/Edit Settings")]
        public static void Edit()
        {
            Selection.activeObject = GetOrCreateSettingsAsset();

            ShowInspector();
        }

        public override void OnInspectorGUI()
        {
            UniversalSDKSettings settings = (UniversalSDKSettings)target;
            UniversalSDKSettings.SetInstance(settings);

            EditorGUILayout.HelpBox("Universal SDK version information.", MessageType.Info);
            
            GUILayout.TextArea("SDK Version : " + UniversalSDKSettings.sdkVersion, EditorStyles.wordWrappedLabel);            

            EditorGUILayout.HelpBox("Add the GoogleClientID and ReversedClientID and Facebook AppID with this game.(It's all iOS settings)", MessageType.None);

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.FacebookAppID = EditorGUILayout.TextField(facebookAppIDLabel, UniversalSDKSettings.FacebookAppID).Trim();
            EditorGUILayout.EndHorizontal();

            if (UniversalSDKSettings.UseFacebookLogin && string.IsNullOrEmpty(UniversalSDKSettings.FacebookAppID))
            {
                EditorGUILayout.HelpBox("not working if FacebookAppID is empty.", MessageType.Warning);
            }

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.FacebookClientToken = EditorGUILayout.TextField(facebookClientTokenLabel, UniversalSDKSettings.FacebookClientToken).Trim();
            EditorGUILayout.EndHorizontal();

            if (UniversalSDKSettings.UseFacebookLogin && string.IsNullOrEmpty(UniversalSDKSettings.FacebookClientToken))
            {
                EditorGUILayout.HelpBox("not working if FacebookClientToken is empty.", MessageType.Warning);
            }

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.GoogleClientID = EditorGUILayout.TextField(googleClientIDLabel, UniversalSDKSettings.GoogleClientID).Trim();
            EditorGUILayout.EndHorizontal();

            if (UniversalSDKSettings.UseGoogleLogin && string.IsNullOrEmpty(UniversalSDKSettings.GoogleClientID))
            {
                EditorGUILayout.HelpBox("not working if GoogleClientID is empty.", MessageType.Warning);
            }

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.ReversedClientID = EditorGUILayout.TextField(reversedClientIDLabel, UniversalSDKSettings.ReversedClientID).Trim();
            EditorGUILayout.EndHorizontal();

            if (UniversalSDKSettings.UseGoogleLogin && string.IsNullOrEmpty(UniversalSDKSettings.ReversedClientID))
            {
                EditorGUILayout.HelpBox("not working if ReversedClientID is empty.", MessageType.Warning);
            }

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.UseAppleLogin = EditorGUILayout.Toggle(useAppleLoginLabel, UniversalSDKSettings.UseAppleLogin);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.UseFacebookLogin = EditorGUILayout.Toggle(useFacebookLoginLabel, UniversalSDKSettings.UseFacebookLogin);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.UseGoogleLogin = EditorGUILayout.Toggle(useGoogleLoginLabel, UniversalSDKSettings.UseGoogleLogin);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            UniversalSDKSettings.DevBuild = EditorGUILayout.Toggle(devBuildLabel, UniversalSDKSettings.DevBuild);
            EditorGUILayout.EndHorizontal();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(settings);                
                AssetDatabase.SaveAssets();
            }
        }

        private static void ShowInspector()
        {
            try
            {
                var editorAsm = typeof(UnityEditor.Editor).Assembly;
                var type = editorAsm.GetType("UnityEditor.InspectorWindow");
                Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);

                if (findObjectsOfTypeAll.Length > 0)
                {
                    ((EditorWindow)findObjectsOfTypeAll[0]).Focus();
                }
                else
                {
                    EditorWindow.GetWindow(type);
                }
            }
            catch
            {
                EditorUtility.DisplayDialog("Universal SDK", "Unity Inspector Error.", "OK");
            }
        }
    }
}
