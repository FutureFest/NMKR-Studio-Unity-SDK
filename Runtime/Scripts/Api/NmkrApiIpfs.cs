using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Upload a file and pin it to IPFS.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="request">Request data containing the file as BASE64 content, URL link, or IPFS hash.</param>
        /// <param name="onSuccess">Action to perform on successful upload.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UploadToIpfs(int customerid, UploadToIpfsClass request, Action<string> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UploadToIpfs/{customerid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }
    }
}