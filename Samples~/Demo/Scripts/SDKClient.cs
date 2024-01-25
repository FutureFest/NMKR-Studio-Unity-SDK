using Nmkr.Sdk.Schemas;
using UnityEngine;
using static Nmkr.Sdk.Api;
using System.Threading.Tasks;
using static Nmkr.Demo.SDKServer;

namespace Nmkr.Demo
{
    /// <summary>
    /// This class is a starter point for communication between a Unity game client and the Unity game server.
    /// Use multiplayer solutions like RPC calls.
    /// !DONT USE THIS DEMO IN PRODUCTION. YOU ARE RESPONSIBLE FOR THE SECURITY OF YOUR API KEYS AND OTHER SENSITIVE DATA!
    /// </summary>
    public class SDKClient : MonoBehaviour
    {
        public static async Task<ApiResponse<WalletInfo>> CreateWallet(string walletName, string walletPassword)
        {
            return await SDKServer.CreateWallet(walletName, walletPassword);
        }

        public static async Task<ApiResponse<TxInAddressesClass>> GetWalletUtxo(string address)
        {
            return await SDKServer.GetWalletUtxo(address);
        }

        public static async Task<ApiResponse<WalletAssets>> GetWalletAssets(string address)
        {
            return await SDKServer.GetWalletAssets(address);
        }

        public static async Task<ApiResponse<NftProjectsDetails>> GetProjectDetails(string projectUid)
        {
            return await SDKServer.GetProjectDetails(projectUid);
        }

        public static async Task<ApiResponse<MakeTransactionResultClass>> MakeManagedWalletTransaction(string senderaddress, string walletpassword, string receiverAddress, TransactionTokensClass token)
        {
            var transactionRequest = new CreateManagedWalletTransactionClass()
            {
                receivers = new TransactionReceiversClass[]
                {
                    new TransactionReceiversClass()
                    {
                        receiverAddress = receiverAddress,
                        sendTokens = new TransactionTokensClass[]
                        {
                            token
                        }
                    },
                }
            };
            return await SDKServer.MakeManagedWalletTransaction(senderaddress, walletpassword, transactionRequest);
        }

        public static async Task<ApiResponse<MintAndSendResultClass>> MintAndSendRandom(string projectUid, int nftCount, string receiverAddress)
        {
            return await SDKServer.MintAndSendRandom(projectUid, nftCount, receiverAddress);
        }

        public static async Task<ApiResponse<PurchaseAndMintResult>> PurchaseAndMint(string projectUid, string managedWalletAddress, string managedWalletPassword, long itemPriceLovelace, int nftCount)
        {
            return await SDKServer.PurchaseAndMint(projectUid, managedWalletAddress, managedWalletPassword, itemPriceLovelace, nftCount);
        }
    }
}