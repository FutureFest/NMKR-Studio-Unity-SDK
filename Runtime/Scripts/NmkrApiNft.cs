using Nmkr.Sdk.Schemas;
using System;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Duplicates a nft/token inside a project. If a token already exists, it will be skipped
        /// </summary>
        /// <param name="nftuid">Id of the existing nft to duplicate</param>
        /// <param name="request"></param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void DuplicateNft(string nftuid, DuplicateNftClass request, Action<NftProjectsDetails> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"DuplicateNft/{nftuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Checks if the metadata are valid
        /// </summary>
        /// <param name="nftuid">Id of the nft</param>
        /// <param name="request">UploadMetadataClass request object</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void CheckMetadata(string nftuid, UploadMetadataClass request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CheckMetadata/{nftuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Updates the Metadata for one specific NFT
        /// </summary>
        /// <param name="projectuid">Id of the project</param>
        /// <param name="nftuid">Id of the nft</param>
        /// <param name="request">UploadMetadataClass request object</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void UpdateMetadata(string projectuid, string nftuid, UploadMetadataClass request, Action<NftDetailsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateMetadata/{projectuid}/{nftuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Upload a File to a project and pin it to IPFS
        /// </summary>
        /// <param name="projectuid">Id of the project</param>
        /// <param name="request">UploadNftClassV2 request object</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void UploadNft(string projectuid, UploadNftClassV2 request, Action<UploadNftResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UploadNft/{projectuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Blocks/Unblocks an nft (nft uid)
        /// </summary>
        /// <param name="nftuid">Id of the nft</param>
        /// <param name="blockNft">Boolean to block or unblock</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void BlockUnblockNft(string nftuid, bool blockNft, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"BlockUnblockNft/{nftuid}/{blockNft}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Returns detail information about one nft specified by Id (nft uid)
        /// </summary>
        /// <param name="nftuid">Id of the nft</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetNftDetailsById(string nftuid, Action<NftDetailsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetNftDetailsById/{nftuid}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }
        /// <summary>
        /// Returns detail information about one nft specified by its name
        /// </summary>
        /// <param name="projectuid">Id of the project</param>
        /// <param name="nftname">Name of the nft</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetNftDetailsByTokenname(string projectuid, string nftname, Action<NftDetailsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetNftDetailsByTokenname/{projectuid}/{nftname}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Returns detail information about nfts with a specific state with Pagination support. (project uid)
        /// </summary>
        /// <param name="projectuid">Id of the project</param>
        /// <param name="state">State of the nfts</param>
        /// <param name="count">Number of items per page</param>
        /// <param name="page">Page number</param>
        /// <param name="onSuccess">Action on success</param>
        /// <param name="onFailure">Action on failure</param>
        public static async void GetNfts(string projectuid, string state, int count, int page, Action<NFT[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetNfts/{projectuid}/{state}/{count}/{page}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Deletes a NFT from the database (NFT UID).
        /// You can delete a NFT if it is not in sold or reserved state.
        /// </summary>
        /// <param name="nftuid">The UID of the NFT to be deleted.</param>
        /// <param name="onSuccess">Action to perform if the API call is successful.</param>
        /// <param name="onFailure">Action to perform if the API call fails.</param>
        public static async void DeleteNft(string nftuid, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"DeleteNft/{nftuid}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }

        /// <summary>
        /// Deletes all NFTs from the database for a specified project.
        /// This function deletes all NFTs from a project. You can delete an NFT if it is not in sold or reserved state. All other NFTs will be deleted.
        /// </summary>
        /// <param name="projectuid">The unique identifier of the project from which all NFTs will be deleted</param>
        /// <param name="onSuccess"><include file='SummaryParams.xml' path='docs/param[@name="onSuccess"]/*' /></param>
        /// <param name="onFailure"><include file='SummaryParams.xml' path='docs/param[@name="onFailure"]/*' /></param>
        public static async void DeleteAllNftsFromProject(string projectuid, Action<DeleteAllNftsResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"v2/DeleteAllNftsFromProject/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure: (error) => { HandleError(error, onFailure); });
        }
    }
}