using System;
using System.Collections.Generic;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
       
        /// <summary>
        /// Adds a payout wallet to your account.
        /// </summary>
        /// <param name="walletaddress">The wallet address to add</param>
        /// <param name="onSuccess">Action to perform on successful response</param>
        /// <param name="onFailure">Action to perform on error response</param>
        public static async void AddPayoutWallet(string walletaddress, Action<ApiErrorResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"AddPayoutWallet/{walletaddress}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Returns all payout wallets in your account.
        /// </summary>
        /// <param name="onSuccess">Action to perform on successful response</param>
        /// <param name="onFailure">Action to perform on error response</param>
        public static async void GetPayoutWallets(Action<GetPayoutWalletsResultClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = "GetPayoutWallets";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }
    }
}