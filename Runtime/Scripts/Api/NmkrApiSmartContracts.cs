using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Retrieves the buyout smart contract address for a specific customer and transaction hash.
        /// </summary>
        /// <param name="customerid">The customer's unique identifier.</param>
        /// <param name="txHashLockedinAssets">The transaction hash of the locked-in assets.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of the smart contract address.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetBuyOutSmartcontractAddress(int customerid, string txHashLockedinAssets, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetBuyOutSmartcontractAddress/{customerid}/{txHashLockedinAssets}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns the datum information for a smartcontract directsale transaction.
        /// </summary>
        /// <param name="txhash">The transaction hash of the direct sale transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of the datum information.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetDatumInformationForSmartcontractDirectsaleTransaction(string txhash, Action<SmartcontractDirectsaleDatumInformationClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetDatumInformationForSmartcontractDirectsaleTransaction/{txhash}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves the payment transaction for a listed asset.
        /// </summary>
        /// <param name="policyid">The policy ID of the asset.</param>
        /// <param name="assetnameinhex">The asset name in hexadecimal format.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of payment transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetListedAssetPaymentTransaction(string policyid, string assetnameinhex, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetListedAssetPaymentTransaction/{policyid}/{assetnameinhex}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }
    }
}