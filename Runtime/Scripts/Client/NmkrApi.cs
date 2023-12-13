using Newtonsoft.Json;
using Nmkr.Sdk.Schemas;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        public struct ApiSettings
        {
            public ApiServer apiServer;
            public string apiKey;
            public int customerId;

            public ApiSettings(ApiServer server, string apiKey, int customnerId)
            {
                this.apiServer = server;
                this.apiKey = apiKey;
                this.customerId = customnerId;
            }
        }

        public enum ApiServer
        {
            Preprod,
            Mainnet
        }
        
        private const string API_SERVER_MAINNET = "https://studio-api.nmkr.io/v2";
        private const string API_SERVER_PREPROD = "https://studio-api.preprod.nmkr.io/v2";

        private static int _customerId = 000000;
        private static string _apiServerUrl = API_SERVER_PREPROD;
        private static string _apiKey = string.Empty;
        private static bool _initialized = false;

        public static void Initialize(ApiSettings settings)
        {
            _apiServerUrl = GetApiServerUrl(settings.apiServer);
            _apiKey = settings.apiKey;
            _customerId = settings.customerId;
            _initialized = true;
            Debug.Log($"Initialized NMKR API. API server url: {_apiServerUrl}");
        }

        public static void SetApiServer(string serverUrl)
        {
            _apiServerUrl = serverUrl;
        }

        public static void SetApiServer(ApiServer apiServer)
        {
            _apiServerUrl = GetApiServerUrl(apiServer);
        }

        private static string GetApiServerUrl(ApiServer apiServer)
        {
            switch(apiServer)
            {
                case ApiServer.Mainnet:
                    return API_SERVER_MAINNET;
                case ApiServer.Preprod:
                    return API_SERVER_PREPROD;
                default: return API_SERVER_PREPROD;
            } 
        }

        public class ApiResponse<TResult>
        {
            public TResult result;
            public ResponseError error;
            public bool success => result != null;
        }

        private static ApiResponse<TResponse> HandleApiResponse<TResponse>(string apiType, UnityWebRequest request, string url, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (request.result != UnityWebRequest.Result.Success)
            {
                var errorResponse = HandleApiError($"NMKR {apiType} API error.", url, request, onFailure);
                var response = new ApiResponse<TResponse>()
                {
                    error = errorResponse
                };
                return response;
            }
            else if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
            {
                var result = JsonConvert.DeserializeObject<TResponse>(request.downloadHandler.text);
                Debug.Log($"NMKR {apiType} success: {result}");
                onSuccess?.Invoke(result);

                var response = new ApiResponse<TResponse>()
                {
                    result = result,
                };

                return response;
            }
            else if(request.result == UnityWebRequest.Result.Success)
            {
                // no downloadable response but still a success, send empty response instead of erroring
                onSuccess?.Invoke(default);
                var response = new ApiResponse<TResponse>()
                {
                    result = default,
                };
                return response;
            }
            else
            {
                var unknownResponse = new ApiResponse<TResponse>()
                {
                    error = GetException($"NMKR {apiType} error.", url, new Exception("Unknown Error"), onFailure),
                };
                return unknownResponse;
            }
        }

        private static ResponseError HandleApiError(string errorPrefix, string url, UnityWebRequest request, Action<ResponseError> onFailure = null)
        {
            Debug.LogError($"{errorPrefix}. {request.result}. Endpoint: {url}.\n Error: {request.error}");
            if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
            {
                var errorResponse = JsonConvert.DeserializeObject<ApiErrorResultClass>(request.downloadHandler.text);
                ResponseError error = new ResponseError()
                {
                    type = GetResponseErrorType(request.result),
                    message = errorResponse.errorMessage,
                    responseCode = request.responseCode,
                };
                onFailure?.Invoke(error);
                return error;
            }
            else
            {
                ResponseError error = new ResponseError()
                {
                    type = GetResponseErrorType(request.result),
                    message = request.error,
                    responseCode = request.responseCode,
                };
                onFailure?.Invoke(error);
                return error;
            }
        }

        private static ApiResponse<TResponse> GetApiInitializeError<TResponse>()
        {
            Debug.LogError($"NMKR SDK not initialized.");
            var response = new ApiResponse<TResponse>()
            {
                error = HandleApiError("NMKR SDK not initialized.", string.Empty, null),
            };
            return response;
        }

        private static ErrorType GetResponseErrorType(UnityWebRequest.Result response)
        {
            switch(response)
            {
                case UnityWebRequest.Result.ConnectionError: return ErrorType.ConnectionError;
                case UnityWebRequest.Result.ProtocolError: return ErrorType.ProtocolError;
                case UnityWebRequest.Result.DataProcessingError: return ErrorType.DataProcessingError;
                default: return ErrorType.Unknown;
            }
        }

        private static ResponseError GetException(string errorPrefix, string endpoint, Exception ex, Action<ResponseError> onFailure)
        {
            Debug.LogError($"{errorPrefix} Endpoint: {endpoint};\n Ex: {ex}");
            ResponseError error = new ResponseError()
            {
                type = ErrorType.Unknown,
                message = ex.ToString(),
            };
            onFailure?.Invoke(error);
            return error;
        }
    }
}