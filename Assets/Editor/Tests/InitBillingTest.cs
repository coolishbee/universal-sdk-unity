using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;
using System.Linq;

using Universal.UniversalSDK;

public class InitBillingTest
{
    [Test]
    public void InitBillingTestOk()
    {
        var json = @"
        {
            ""code"": 123,
            ""message"": ""error""
        }
        ";
        var called = false;
        UniversalAPI.InitBilling(new string[] { "boxer_unity1000" }, result =>
        {
            Assert.True(result.IsFailure);
            result.MatchError(error =>
            {
                called = true;
                Assert.AreEqual(123, error.Code);
                Assert.AreEqual("error", error.Message);
            });
        });

        var identifier = UniversalAPI.actions.Keys.ToList()[0];
        UniversalAPI._OnApiError(CallbackMessageForUnity.WrapValue(identifier, json));
        Assert.True(called);

    }


}