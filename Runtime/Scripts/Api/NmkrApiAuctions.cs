using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Returns the state and the last bids of an auction project.
        /// </summary>
        /// <param name="auctionuid">Unique identifier of the auction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of auction state.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetAuctionState(string auctionuid, Action<GetAuctionStateResultClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetAuctionState/{auctionuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }
    }
}