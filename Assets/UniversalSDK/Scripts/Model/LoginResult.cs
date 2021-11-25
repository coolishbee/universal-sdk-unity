using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class LoginResult
    {
        [SerializeField]
        private int responseCode = 0;
        [SerializeField]
        private UserProfile userProfile = null;

        public int ResponseCode { get { return responseCode; } }
        public UserProfile UserProfile { get { return userProfile; } }
    }
}
