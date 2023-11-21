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
        public struct ApiSettings
        {
            public ApiServer apiServer;
            public string apiKey;
        }

        public enum ApiServer
        {
            Mainnet,
            Preprod
        }
        
        private const string API_SERVER_MAINNET = "https://studio-api.nmkr.io/v2";
        private const string API_SERVER_PREPROD = "https://studio-api.preprod.nmkr.io/v2";

        private static string _apiServerUrl = API_SERVER_PREPROD;
        private static string _apiKey = string.Empty;
        private static bool _initialized = false;

        public static void Initialize(ApiSettings settings)
        {
            _apiServerUrl = GetApiServerUrl(settings.apiServer);
            _apiKey = settings.apiKey;
            _initialized = true;
            Debug.Log($"Initialized NMKR API. API server url: {_apiServerUrl}");
        }

        public static void Initialize(string apiKey)
        {
            _apiKey = apiKey;
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

        // GET
        public static async Task<TResponse> GetAsync<TResponse>(string endpoint, Action<TResponse> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            if (!_initialized) 
            {
                Debug.LogError($"NMKR SDK not initialized.");
                return default; 
            }

            try
            {
                string url = $"{_apiServerUrl}/{endpoint}";
                using var request = UnityWebRequest.Get(url);
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"NMKR GETAsync {request.result}. Endpoint: {url};\n Error: {request.error}");
                    if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ApiErrorResultClass>(request.downloadHandler.text);
                        ResponseError error = new ResponseError()
                        {
                            type = GetResponseErrorType(request.result),
                            message = request.error,
                            responseCode = request.responseCode,
                            apiMessage = errorResponse.errorMessage
                        };
                        onFailure?.Invoke(error);
                        return default;
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
                        return default;
                    }
                }

                if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(request.downloadHandler.text);
                    Debug.Log($"NMKR GETAsync success: {response}");
                    onSuccess?.Invoke(response);
                    return response;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"NMKR GETAsync error. Endpoint: {endpoint};\n Ex: {ex}");
                ResponseError error = new ResponseError()
                {
                    type = ErrorType.Unknown,
                    message = ex.ToString(),
                };
                onFailure?.Invoke(error);
                return default;
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

            string url = $"{_apiServerUrl}/{endpoint}";
            try
            {
                using var request = UnityWebRequest.Get(url);
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");
                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"NMKR GETAsync {request.result}. Endpoint: {url};\n Error: {request.error}");
                    if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ApiErrorResultClass>(request.downloadHandler.text);
                        ResponseError error = new ResponseError()
                        {
                            type = GetResponseErrorType(request.result),
                            message = request.error,
                            responseCode = request.responseCode,
                            apiMessage = errorResponse.errorMessage
                        };
                        onFailure?.Invoke(error);
                        return;
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
                        return;
                    }

                }

                Debug.Log($"NMKR GETAsync success");
                onSuccess?.Invoke();
                return;
            }
            catch (Exception ex)
            {
                Debug.LogError($"NMKR GETAsync error. Endpoint: {url};\n Ex: {ex}");
                ResponseError error = new ResponseError()
                {
                    type = ErrorType.Unknown,
                    message = ex.ToString()
                };
                onFailure?.Invoke(error);
                return;
            }
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
                    string requestJson = JsonConvert.SerializeObject(requestObject);
                    byte[] bodyRaw = Encoding.UTF8.GetBytes(requestJson);

                    Debug.Log($"REQUEST BODY:\n{requestJson}");

                    request.method = UnityWebRequest.kHttpVerbPOST;
                    request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    request.uploadHandler.contentType = "application/json";
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");

                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError($"NMKR POSTAsync {request.result}. Endpoint: {url}.\n Error: {request.error}");
                        if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                        {
                            var errorResponse = JsonConvert.DeserializeObject<ApiErrorResultClass>(request.downloadHandler.text);
                            ResponseError error = new ResponseError()
                            {
                                type = GetResponseErrorType(request.result),
                                message = request.error,
                                responseCode = request.responseCode,
                                apiMessage = errorResponse.errorMessage
                            };
                            onFailure?.Invoke(error);
                            return default;
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
                            return default;
                        }
                    }

                    if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
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
                        return default;
                    }
                }
            }
            catch (Exception ex)
            {
                ResponseError error = new ResponseError()
                {
                    type = ErrorType.Unknown,
                    message = ex.ToString()
                };
                Debug.LogError($"NMKR POSTAsync Error. Endpoint: {url}.\n Ex: {ex}");
                onFailure?.Invoke(error);
                return default;
            }
        }

        // POST
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
                    string requestJson = JsonConvert.SerializeObject(requestObject);
                    byte[] bodyRaw = Encoding.UTF8.GetBytes(requestJson);

                    request.method = UnityWebRequest.kHttpVerbPOST;
                    request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    request.uploadHandler.contentType = "application/json";
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Authorization", $"Bearer {_apiKey}");

                    var operation = request.SendWebRequest();

                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }

                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError($"NMKR POSTAsync {request.result}. Endpoint: {url}.\n Error: {request.error}");
                        if (request.downloadHandler != null && string.IsNullOrEmpty(request.downloadHandler.text) == false)
                        {
                            var errorResponse = JsonConvert.DeserializeObject<ApiErrorResultClass>(request.downloadHandler.text);
                            ResponseError error = new ResponseError()
                            {
                                type = GetResponseErrorType(request.result),
                                message = request.error,
                                responseCode = request.responseCode,
                                apiMessage = errorResponse.errorMessage
                            };
                            onFailure?.Invoke(error);
                            return;
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
                            return;
                        }
                    }

                    Debug.Log($"NMKR POSTAsync success");
                    onSuccess?.Invoke();
                    return;
                }
            }
            catch (Exception ex)
            {
                ResponseError error = new ResponseError()
                {
                    type = ErrorType.Unknown,
                    message = ex.ToString()
                };
                Debug.LogError($"NMKR POSTAsync Error. Endpoint: {url}.\n Ex: {ex}");
                onFailure?.Invoke(error);
                return;
            }
        }
    }
}