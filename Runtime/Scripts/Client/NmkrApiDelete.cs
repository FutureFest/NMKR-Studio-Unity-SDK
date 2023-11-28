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
        // DELETE with response
        public static async Task DeleteAsync<TResponse>(string endpoint, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError("NMKR SDK not initialized.");
                return;
            }

            try
            {
                string url = $"{_apiServerUrl}/{endpoint}";
                using var request = CreateDeleteRequest(url);
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    HandleApiError("NMKR DELETEAsync API error.", url, request, onFailure);
                }
                else if (request.downloadHandler != null && !string.IsNullOrEmpty(request.downloadHandler.text))
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(request.downloadHandler.text);
                    Debug.Log($"NMKR DELETEAsync success: {response}");
                    onSuccess?.Invoke(response);
                    return;
                }
            }
            catch (Exception ex)
            {
                CatchException("NMKR DELETEAsync error.", endpoint, ex, onFailure);
            }
        }

        // DELETE without response
        public static async Task DeleteAsync(string endpoint, Action onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError("NMKR SDK not initialized.");
                return;
            }

            try
            {
                string url = $"{_apiServerUrl}/{endpoint}";
                using var request = CreateDeleteRequest(url);
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    HandleApiError("NMKR DELETEAsync API error.", url, request, onFailure);
                    return;
                }
                else
                {
                    Debug.Log("NMKR DELETEAsync success");
                    onSuccess?.Invoke();
                }
            }
            catch (Exception ex)
            {
                CatchException("NMKR DELETEAsync error.", endpoint, ex, onFailure);
            }
        }

        private static UnityWebRequest CreateDeleteRequest(string url)
        {
            var request = UnityWebRequest.Delete(url);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
            return request;
        }
    }
}