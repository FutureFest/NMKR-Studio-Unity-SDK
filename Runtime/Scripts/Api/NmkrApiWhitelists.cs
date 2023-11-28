using Nmkr.Sdk.Schemas;
using System;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Gets all entries of a project's whitelist.
        /// </summary>
        /// <param name="projectuid">The unique identifier of the project.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetAllEntriesFromWhitelist(string projectuid, Action<GetWhitelistEntriesClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ManageWhitelist/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Adds an entry to a project's whitelist.
        /// </summary>
        /// <param name="projectuid">The unique identifier of the project.</param>
        /// <param name="address">The address to add to the whitelist.</param>
        /// <param name="countofnfts">The count of NFTs for the whitelist entry.</param>
        /// <param name="onSuccess">Action to perform on successful addition.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void AddEntryToManageWhitelist(string projectuid, string address, int countofnfts, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ManageWhitelist/{projectuid}/{address}/{countofnfts}";
            await PostAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Deletes an entry from a project's whitelist.
        /// </summary>
        /// <param name="projectuid">The unique identifier of the project.</param>
        /// <param name="address">The address to remove from the whitelist.</param>
        /// <param name="onSuccess">Action to perform on successful deletion.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void DeleteEntryFromWhitelist(string projectuid, string address, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ManageWhitelist/{projectuid}/{address}";
            await DeleteAsync(endpoint, onSuccess, onFailure);
        }
    }
}