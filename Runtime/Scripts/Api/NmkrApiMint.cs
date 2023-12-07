using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        private static readonly Dictionary<long, string> errorCodes = new Dictionary<long, string>()
        {
            {401,"The access was denied. (Wrong or expired APIKEY, wrong projectuid etc.)"},
            {402,"Too less ADA in your account. Fill up ADA first before try to mint and send"},
            {404,"No more nft available"},
            {406,"The receiveraddress is not a valid cardano address or a valid ada handle; OR Invalid projectuid"}, // shouldnt be because of invalid projectuid
            {409,"There are pending transactions on the sender address (your account address). Please wait a second"},
            {500,"Internal server error - see the errormessage in the result"},
        };

        /// <summary>
        /// Mints random Nfts and sends it to an Address.
        /// When you call this API, random NFTs will be selected, minted and send to an ada address. You will need ADA in your Account for the transaction and minting costs.
        /// </summary>
        /// <param name="projectuid"><include file='SummaryParams.xml' path='docs/param[@name="projectuid"]/*' /></param>
        /// <param name="countnft">The number of nfts to mint</param>
        /// <param name="receiveraddress"><include file='SummaryParams.xml' path='docs/param[@name="receiveraddress"]/*' /></param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async Task<ApiResponse<MintAndSendResultClass>> MintAndSendRandom(string projectuid, int countnft, string receiveraddress, Action<MintAndSendResultClass> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"MintAndSendRandom/{projectuid}/{countnft}/{receiveraddress}";
            return await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Mints a specific Nft and sends it to an Address.
        /// When you call this API, a specific NFT will be minted and send to an ada address. You will need ADA in your Account for the transaction and minting costs.
        /// </summary>
        /// <param name="projectuid"><include file='SummaryParams.xml' path='docs/param[@name="projectuid"]/*' /></param>
        /// <param name="nftuid"><include file='SummaryParams.xml' path='docs/param[@name="receiveraddress"]/*' /></param>
        /// <param name="tokencount">Number of nfts to mint of this specific nft</param>
        /// <param name="receiveraddress"><include file='SummaryParams.xml' path='docs/param[@name="receiveraddress"]/*' /></param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void MintAndSendSpecific(string projectuid, string nftuid, long tokencount, string receiveraddress, Action<MintAndSendResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"MintAndSendSpecific/{projectuid}/{nftuid}/{tokencount}/{receiveraddress}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Mints the royalty token.
        /// When you call this API, the royalty token for this project will be minted and send to a burning address. You have to specify the address for the royalties 
        /// and the percentage of royalties. You need mint credits in your account. Only one royalty token can be minted for each project
        /// </summary>
        /// <param name="projectuid"><include file='SummaryParams.xml' path='docs/param[@name="projectuid"]/*' /></param>
        /// <param name="royaltyaddress"></param>
        /// <param name="percentage"></param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void MintRoyaltyToken(string projectuid, string royaltyaddress, double percentage, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"MintRoyaltyToken/{projectuid}/{royaltyaddress}/{percentage}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Remints and burns an NFT specified by the project UID and NFT UID.
        /// When you call this API, you can update the metadata of an already sold NFT.
        /// The NFT will be reminted and sent to a burning address.
        /// </summary>
        /// <param name="projectuid"><include file='SummaryParams.xml' path='docs/param[@name="projectuid"]/*' /></param>
        /// <param name="nftuid"><include file='SummaryParams.xml' path='docs/param[@name="receiveraddress"]/*' /></param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void RemintAndBurn(string projectuid, string nftuid, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"RemintAndBurn/{projectuid}/{nftuid}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        private static void HandleError(ResponseError errorResult, Action<ResponseError> onFailureCallback)
        {
            if (errorCodes.TryGetValue(errorResult.responseCode, out string errorMessage))
            {
                UnityEngine.Debug.LogError($"Error ({errorResult.responseCode}): {errorResult.apiMessage}");
            }
            onFailureCallback?.Invoke(errorResult);
        }
    }
}