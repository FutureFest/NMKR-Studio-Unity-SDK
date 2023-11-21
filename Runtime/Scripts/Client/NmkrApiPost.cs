using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        // POST
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest requestObject, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError($"NMKR SDK not initialized.");
                return default;
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
                    else if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                    {
                        var response = JsonConvert.DeserializeObject<TResponse>(request.downloadHandler.text);
                        Debug.Log($"NMKR POSTAsync success");
                        onSuccess?.Invoke(response);
                        return response;
                    }
                    else
                    {
                        // no response, send empty response instead of erroring
                        onSuccess?.Invoke(default);
                    }
                    return default;
                }
            }
            catch (Exception ex)
            {
                CatchException("NMKR POSTAsync error.", endpoint, ex, onFailure);
                return default;
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
                CatchException("NMKR POSTAsync error.", endpoint, ex, onFailure);
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