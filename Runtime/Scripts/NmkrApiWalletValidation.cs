using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Returns the result of a wallet validation.
        /// </summary>
        /// <param name="validationuid">The unique identifier of the wallet validation</param>
        public static async void CheckWalletValidation(string validationuid, Action<CheckWalletValidationResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckWalletValidation/{validationuid}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Returns an address for wallet validation.
        /// </summary>
        /// <param name="validationname">The name for the wallet validation</param>
        public static async void GetWalletValidationAddress(string validationname, Action<GetWalletValidationAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetWalletValidationAddress/{validationname}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }
    }
}