using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        // GET
        public static async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string endpoint, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized) 
            {
                return GetApiInitializeError<TResponse>(); 
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

                return HandleApiResponse<TResponse>("GETAsync", request, url, onSuccess, onFailure);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<TResponse>()
                {
                    error = GetException("NMKR GETAsync error.", endpoint, ex, onFailure),
                };
                return response;
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
                GetException("NMKR GETAsync error.", endpoint, ex, onFailure);
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