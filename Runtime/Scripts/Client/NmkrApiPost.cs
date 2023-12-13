using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        // POST
        public static async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest requestObject, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                return GetApiInitializeError<TResponse>();
            }

            string url = $"{_apiServerUrl}/{endpoint}";
            try
            {
                using (var request = new UnityWebRequest(url))
                {
                    CreatePostRequest(requestObject, request);
                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    return HandleApiResponse<TResponse>("POSTAsync", request, url, onSuccess, onFailure);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<TResponse>()
                {
                    error = GetException("NMKR POSTAsync error.", endpoint, ex, onFailure),
                };
                return response;
            }
        }

        public static async Task PostAsync<TRequest>(string endpoint, TRequest requestObject, Action onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError($"NMKR SDK not initialized.");
                return;
            }

            string url = $"{_apiServerUrl}/{endpoint}";
            try
            {
                using (var request = new UnityWebRequest(url))
                {
                    CreatePostRequest(requestObject, request);
                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        HandleApiError("NMKR POSTAsync API error.", url, request, onFailure);
                    }
                    else
                    {
                        Debug.Log($"NMKR POSTAsync success");
                        onSuccess?.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {
                GetException("NMKR POSTAsync error.", endpoint, ex, onFailure);
                return;
            }
        }

        private static UnityWebRequest CreatePostRequest<TRequest>(TRequest requestObject, UnityWebRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(requestObject);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(requestJson);

            request.method = UnityWebRequest.kHttpVerbPOST;
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
            return request;
        }
    }
}