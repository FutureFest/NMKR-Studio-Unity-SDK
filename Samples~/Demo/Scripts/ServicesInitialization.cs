using System;
using Unity.Services.Core;
using UnityEngine;

namespace Nmkr.Demo
{
    public class ServicesInitialization
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Initialize();
        }

        private static async void Initialize()
        {
            try
            {
                await UnityServices.InitializeAsync();
                Debug.Log($"Unity Services Initialized.");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}