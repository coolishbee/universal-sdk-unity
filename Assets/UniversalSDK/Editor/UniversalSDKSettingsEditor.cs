using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Universal.UniversalSDK.Editor
{
    [CustomEditor(typeof(UniversalSDKSettingsEditor))]
    public class UniversalSDKSettingsEditor : UnityEditor.Editor
    {

        const string UnityAssetFolder = "Assets";

        public static UniversalSDKSettings GetOrCreateSettingsAsset()
        {
            string fullPath = Path.Combine(Path.Combine(UnityAssetFolder, UniversalSDKSettings.settingsPath),
                                           UniversalSDKSettings.settingsAssetName + UniversalSDKSettings.settingsAssetExtension);

            UniversalSDKSettings instance = AssetDatabase.LoadAssetAtPath(fullPath, typeof(UniversalSDKSettings)) as UniversalSDKSettings;

            if (instance == null)
            {
                if (!Directory.Exists(Path.Combine(UnityAssetFolder, UniversalSDKSettings.settingsPath)))
                {
                    AssetDatabase.CreateFolder(Path.Combine(UnityAssetFolder, "UniversalSDK"), "Resources");
                }

                instance = CreateInstance<UniversalSDKSettings>();
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
