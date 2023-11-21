using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Checks if an address is eligible for a discount.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="address">Address to check</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckIfEligibleForDiscount(string projectuid, string address, Action<CheckDiscountsResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckIfEligibleForDiscount/{projectuid}/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Checks if the sale conditions are met for an address.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="address">Address to check</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckIfSaleConditionsMet(string projectuid, string address, Action<CheckConditionsResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckIfSaleConditionsMet/{projectuid}/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Checks the UTXO of a specific address.
        /// </summary>
        /// <param name="address">Address to check</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckUtxo(string address, Action<AssetsAssociatedWithAccount> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckUtxo/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves active direct sale listings for a project.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetActiveDirectSaleListings(string projectuid, Action<DirectSaleResultsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetActiveDirectSaleListings/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves current ADA rates.
        /// </summary>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetAdaRates(Action<AdaRatesClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetAdaRates";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves the amount of a specific token in a wallet.
        /// </summary>
        /// <param name="policyid">Policy ID of the token</param>
        /// <param name="assetname">Asset name of the token</param>
        /// <param name="address">Wallet address</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetAmountOfSpecificTokenInWallet(string policyid, string assetname, string address, Action<AssetsAssociatedWithAccount> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetAmountOfSpecificTokenInWallet/{policyid}/{assetname}/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves the amount of a specific token in a wallet using POST request.
        /// </summary>
        /// <param name="request">Token amount request details</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void PostGetAmountOfSpecificTokenInWallet(AssetsAssociatedWithAccount request, Action<AssetsAssociatedWithAccount> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetAmountOfSpecificTokenInWallet";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves information from the Cardano token registry.
        /// </summary>
        /// <param name="policyid">Policy ID of the token</param>
        /// <param name="assetname">Asset name of the token</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetCardanoTokenRegistryInformation(string policyid, string assetname, Action<TokenRegistryMetadata> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetCardanoTokenRegistryInformation/{policyid}/{assetname}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves a snapshot of a policy.
        /// </summary>
        /// <param name="policyid">Policy ID</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPolicySnapshot(string policyid, Action<PolicyClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPolicySnapshot/{policyid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves royalty information for a given policy.
        /// </summary>
        /// <param name="policyid">Policy ID</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetRoyaltyInformation(string policyid, Action<RoyaltyClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetRoyaltyInformation/{policyid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

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