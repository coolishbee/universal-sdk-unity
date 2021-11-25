using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class InAppProductList
    {
        [SerializeField]
        private InAppProduct[] iapInfoList = null;

        public InAppProduct[] Products { get { return iapInfoList; } }
    }
}