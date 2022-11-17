using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.UniversalSDK
{
    public class UniversalSDK : MonoBehaviour
    {
        static UniversalSDK instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            SetupSDK();
        }

        public static UniversalSDK Ins
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("UniversalSDK");
                    instance = go.AddComponent<UniversalSDK>();
                }
                return instance;
            }
        }

        void SetupSDK()
        {            
            NativeInterface.SetupSDK();
        }        

        public void Login(LoginType loginType,
                          Action<Result<LoginResult>> action)
        {            
            UniversalAPI.Login(loginType, action);
        }

        public void Logout(Action<Result<UniversalUnit>> action)
        {
            UniversalAPI.Logout(action);
        }        
        
        public void OpenCustomTabView(string url,
                                      Action<Result<UniversalUnit>> action)
        {
            UniversalAPI.OpenCustomTabView(url, action);
        }        

        public void OnApiOk(string result)
        {            
            result.Log();
            UniversalAPI._OnApiOk(result);
        }

        public void OnApiError(string result)
        {            
            result.Log();
            UniversalAPI._OnApiError(result);
        }
    }
}
