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
        // PUT with response
        public static async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest requestObject, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError("NMKR SDK not initialized.");
                return default;
            }

            string url = $"{_apiServerUrl}/{endpoint}";
            try
            {
                using (var request = new UnityWebRequest(url))
                {
                    CreatePutRequest(requestObject, request);
                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    return HandleApiResponse<TResponse>("PUTAsync", request, url, onSuccess, onFailure);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<TResponse>()
                {
                    error = GetException("NMKR PUTAsync error.", endpoint, ex, onFailure),
                };
                return response;
            }
        }

        // PUT without response
        public static async Task PutAsync<TRequest>(string endpoint, TRequest requestObject, Action onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized)
            {
                Debug.LogError("NMKR SDK not initialized.");
                return;
            }

            string url = $"{_apiServerUrl}/{endpoint}";
            try
            {
                using (var request = new UnityWebRequest(url))
                {
                    CreatePutRequest(requestObject, request);
                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        HandleApiError("NMKR PUTAsync API error.", url, request, onFailure);
                    }
                    else
                    {
                        Debug.Log("NMKR PUTAsync success");
                        onSuccess?.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {
                GetException("NMKR PUTAsync error.", endpoint, ex, onFailure);
                return;
            }
        }

        private static UnityWebRequest CreatePutRequest<TRequest>(TRequest requestObject, UnityWebRequest request)
        {
            string requestJson = JsonConvert.SerializeObject(requestObject);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(requestJson);

            request.method = UnityWebRequest.kHttpVerbPUT;
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.uploadHandler.contentType = "application/json";
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
            return request;
        }
    }
}