using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class PurchaseDataList
    {
        [SerializeField]
        private PurchaseData[] purchaseResultList = null;

        public PurchaseData[] PurchaseDatas { get { return purchaseResultList; } }
    }
}