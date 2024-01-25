using UnityEngine;
using static Nmkr.Sdk.Api;

namespace Nmkr.Demo
{
    public class SDKServerInitializer : MonoBehaviour
    {
        /// <summary>
        /// UNITY_SERVER define strips this code from non Server Builds. To activate this define uncomment and choose Dedicated Server in Build Settings.
        /// This is to prevent sensitive data from being exposed to the client. 
        /// !DONT USE THIS DEMO IN PRODUCTION. YOU ARE RESPONSIBLE FOR THE SECURITY OF YOUR API KEYS AND OTHER SENSITIVE DATA!
        /// </summary>
//#if UNITY_SERVER || UNITY_EDITOR
        [SerializeField] private int customerId = 000000; //user id of NMKR Studio account
        [SerializeField] private string apiKey = string.Empty;
        [SerializeField] private ApiServer server = ApiServer.Preprod;

        private void Awake()
        {
            ApiSettings settings = new ApiSettings(server: server, apiKey, customerId);
            Initialize(settings);
        }
//#endif
    }
}