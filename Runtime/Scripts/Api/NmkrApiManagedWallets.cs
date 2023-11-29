using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Creates a Managed Wallet with a specified name.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="walletpassword">The wallet password.</param>
        /// <param name="enterpriseaddress">Boolean indicating if the address is an enterprise address.</param>
        /// <param name="walletname">The name of the wallet.</param>
        /// <param name="onSuccess">Action to perform on successful creation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreateWallet(int customerid, string walletpassword, bool enterpriseaddress, string walletname, Action<CreateWalletResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CreateWallet/{customerid}/{walletpassword}/{enterpriseaddress}/{walletname}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Creates a Managed Wallet without specifying a wallet name.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="walletpassword">The wallet password.</param>
        /// <param name="enterpriseaddress">Boolean indicating if the address is an enterprise address.</param>
        /// <param name="onSuccess">Action to perform on successful creation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreateWallet(int customerid, string walletpassword, bool enterpriseaddress, Action<CreateWalletResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CreateWallet/{customerid}/{walletpassword}/{enterpriseaddress}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Returns the UTxO of a Managed Wallet.
        /// </summary>
        /// <param name="address">The wallet address.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetWalletUtxo(string address, Action<TxInAddressesClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetWalletUtxo/{address}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Imports a Wallet.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="request">The request details for importing a wallet.</param>
        /// <param name="onSuccess">Action to perform on successful import.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ImportWallet(int customerid, ImportManagedWalletClass request, Action<ImportWalletResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ImportWallet/{customerid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Lists all wallets for a given customer.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ListAllWallets(int customerid, Action<Wallets[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ListAllWallets/{customerid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Creates a transaction for a managed wallet.
        /// </summary>
        /// <param name="customerid">The customer identifier.</param>
        /// <param name="senderaddress">The sender wallet address.</param>
        /// <param name="walletpassword">The wallet password.</param>
        /// <param name="onSuccess">Action to perform on successful transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void MakeTransaction(int customerid, string senderaddress, string walletpassword, Action<MakeTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"MakeTransaction/{customerid}/{senderaddress}/{walletpassword}";
            await PostAsync(endpoint, onSuccess, onFailure);
        }
    }
}