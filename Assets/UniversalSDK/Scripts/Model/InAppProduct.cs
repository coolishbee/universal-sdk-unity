using System;
using UnityEngine;

namespace Universal.UniversalSDK
{
    [Serializable]
    public class InAppProduct
    {
        [SerializeField]
        private string productId = "";
        [SerializeField]
        private string currency = "";
        [SerializeField]
        private string price = "";
        [SerializeField]
        private string title = "";
        [SerializeField]
        private string decs = "";

        public string ProductID { get { return productId; } }

        public string Currency { get { return currency; } }

        public string Price { get { return price; } }

        public string Title { get { return title; } }

        public string Decs { get { return decs; } }
    }
}