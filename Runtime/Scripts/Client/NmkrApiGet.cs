using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        // GET
        public static async Task GetAsync<TResponse>(string endpoint, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized) 
            {
                Debug.LogError($"NMKR SDK not initialized.");
                return; 
            }

            try
            {
                string url = $"{_apiServerUrl}/{endpoint}";
                using var request = CreateGetRequest(url);
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    HandleApiError("NMKR GETAsync API error.", url, request, onFailure);
                }
                else if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(request.downloadHandler.text);
                    Debug.Log($"NMKR GETAsync success: {response}");
                    onSuccess?.Invoke(response);
                    return;
                }
            }
            catch (Exception ex)
            {

                CatchException("NMKR GETAsync error.", endpoint, ex, onFailure);
            }
        }

        // GETs should have responses, but some APIs dont have response objects to deserialize
        public static async Task GetAsync(string endpoint, Action onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError($"NMKR SDK not initialized.");
                return;
            }

            try
            {
                string url = $"{_apiServerUrl}/{endpoint}";
                using var request = CreateGetRequest(url);
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    HandleApiError("NMKR GETAsync API error.", url, request, onFailure);
                    return;
                }
                else
                {
                    Debug.Log($"NMKR GETAsync success");
                    onSuccess?.Invoke();
                }
            }
            catch (Exception ex)
            {
                CatchException("NMKR GETAsync error.", endpoint, ex, onFailure);
            }
        }

        private static UnityWebRequest CreateGetRequest(string url)
        {
            var request = UnityWebRequest.Get(url);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
            return request;
        }
    }
}