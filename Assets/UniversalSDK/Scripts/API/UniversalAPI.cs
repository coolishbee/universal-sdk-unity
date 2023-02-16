using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.UniversalSDK
{
    public class UniversalAPI
    {
        public static Dictionary<string, FlattenAction> actions =
            new Dictionary<string, FlattenAction>();        

        public static void Login(LoginType loginType,                                 
                                 Action<Result<LoginResult>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<LoginResult>(action));

            NativeInterface.Login(identifier, loginType);
        }        

        static string AddAction(FlattenAction action)
        {
            var identifier = Guid.NewGuid().ToString();
            actions.Add(identifier, action);
            return identifier;
        }

        static FlattenAction PopActionFromPayload(CallbackMessageForUnity payload)
        {
            var identifier = payload.Identifier;
            if (identifier == null)
            {
                return null;
            }
            FlattenAction action = null;
            if (actions.TryGetValue(identifier, out action))
            {
                actions.Remove(identifier);
                return action;
            }
            return null;
        }        

        public static void _OnApiOk(string result)
        {
            var payload = CallbackMessageForUnity.FromJson(result);
            var action = PopActionFromPayload(payload);
            if (action != null)
            {
                action.CallOk(payload.Value);
            }
        }

        public static void _OnApiError(string result)
        {
            var payload = CallbackMessageForUnity.FromJson(result);
            var action = PopActionFromPayload(payload);
            if (action != null)
            {
                action.CallError(payload.Value);
            }
        }        
    }

}