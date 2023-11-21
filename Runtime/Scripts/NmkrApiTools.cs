using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Returns all assets that are in a wallet
        /// </summary>
        /// <param name="address">The wallet address to check for assets</param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void GetAllAssetsInWallet(string address, Action<AssetsAssociatedWithAccount[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetAllAssetsInWallet/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }
    }
}