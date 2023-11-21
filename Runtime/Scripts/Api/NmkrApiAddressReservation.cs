using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Cancels an address reservation.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="paymentaddress">Payment address to cancel reservation for</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CancelAddressReservation(string projectuid, string paymentaddress, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CancelAddressReservation/{projectuid}/{paymentaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Checks an address for state changes.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="address">Address to check</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckAddress(string projectuid, string address, Action<CheckAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckAddress/{projectuid}/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Checks an address with a custom property for state changes.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="customproperty">Custom property to check</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckAddressWithCustomproperty(string projectuid, string customproperty, Action<CheckAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckAddressWithCustomproperty/{projectuid}/{customproperty}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns an address for a random NFT sale.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="countnft">Count of NFTs</param>
        /// <param name="lovelace">Amount in Lovelace</param>
        /// <param name="customeripaddress">Customer IP address</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPaymentAddressForRandomNftSale(string projectuid, long countnft, long lovelace, string customeripaddress, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPaymentAddressForRandomNftSale/{projectuid}/{countnft}/{lovelace}/{customeripaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns an address for a random NFT sale with a customer IP address.
        /// </summary>
        /// <param name="projectuid">Project UID</param>
        /// <param name="countnft">Count of NFTs</param>
        /// <param name="customeripaddress">Customer IP address</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPaymentAddressForRandomNftSale(string projectuid, long countnft, string customeripaddress, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPaymentAddressForRandomNftSale/{projectuid}/{countnft}/{customeripaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns an address for a specific NFT sale with token count and lovelace.
        /// </summary>
        /// <param name="nftuid">NFT UID</param>
        /// <param name="tokencount">Token count</param>
        /// <param name="lovelace">Amount in Lovelace</param>
        /// <param name="customeripaddress">Customer IP address</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPaymentAddressForSpecificNftSale(string nftuid, long tokencount, long lovelace, string customeripaddress, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPaymentAddressForSpecificNftSale/{nftuid}/{tokencount}/{lovelace}/{customeripaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns an address for a specific NFT sale.
        /// </summary>
        /// <param name="nftuid">NFT UID</param>
        /// <param name="tokencount">Token count</param>
        /// <param name="customeripaddress">Customer IP address</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPaymentAddressForSpecificNftSale(string nftuid, long tokencount, string customeripaddress, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPaymentAddressForSpecificNftSale/{nftuid}/{tokencount}/{customeripaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns an address for a specific NFT sale with a customer IP address.
        /// </summary>
        /// <param name="customeripaddress">Customer IP address</param>
        /// <param name="request">Request details</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetPaymentAddressForSpecificNftSale(string customeripaddress, ReserveMultipleNftsClassV2 request, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"v2/GetPaymentAddressForSpecificNftSale/{customeripaddress}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }
    }
}