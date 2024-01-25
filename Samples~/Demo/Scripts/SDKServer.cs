using Nmkr.Sdk;
using Nmkr.Sdk.Schemas;
using System;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using static Nmkr.Demo.SDKServer;
using static Nmkr.Sdk.Api;

namespace Nmkr.Demo
{
    public class SDKServer
    {
        /// <summary>
        /// UNITY_SERVER define strips this code from non Server Builds. To activate this define choose Dedicated Server in Build Settings.
        /// This is to prevent sensitive data from being exposed to the client. 
        /// !DONT USE THIS DEMO IN PRODUCTION. YOU ARE RESPONSIBLE FOR THE SECURITY OF YOUR API KEYS AND OTHER SENSITIVE DATA!
        /// </summary>
#if UNITY_SERVER || UNITY_EDITOR
        public void InitializeApi(string apiKey, int customerId)
        {
            ApiSettings settings = new ApiSettings(server: ApiServer.Preprod, apiKey, customerId);
            Initialize(settings);
        }
#endif

        public static async Task<ApiResponse<WalletInfo>> CreateWallet(string walletName, string walletPassword)
        {
            var response = await Api.CreateWallet(walletpassword: walletPassword, enterpriseaddress: true, walletname: walletName);

            var createWalletResponse = new ApiResponse<WalletInfo>();

            if (response.success)
            {
                var walletResult = response.result;
                var wallet = new WalletInfo()
                {
                    walletName = walletResult.walletName,
                    address = walletResult.address,
                    addressType = walletResult.addressType,
                    network = walletResult.network,
                };
                createWalletResponse.result = wallet;
                return createWalletResponse;
            }
            else
            {
                createWalletResponse.error = response.error;
                return createWalletResponse;
            }

        }

        public static async Task<ApiResponse<TxInAddressesClass>> GetWalletUtxo(string walletAddress)
        {
            return await Api.GetWalletUtxo(walletAddress);
        }

        public static async Task<ApiResponse<WalletAssets>> GetWalletAssets(string walletAddress)
        {
            var response = await Api.GetWalletUtxo(walletAddress);
            var resultResponse = new ApiResponse<WalletAssets>();

            if (response.success)
            {
                var assets = new WalletAssets()
                {
                    balanceInLovelace = response.result.lovelaceSummary,
                    tokens = response.result.getAllTokens
                };
                resultResponse.result = assets;
                return resultResponse;
            }
            else
            {
                resultResponse.error = response.error;
                return resultResponse;
            }
        }

        public static async Task<ApiResponse<NftProjectsDetails>> GetProjectDetails(string projectUid)
        {
            return await Api.GetProjectDetails(projectUid);
        }

        public static async Task<ApiResponse<MakeTransactionResultClass>> MakeManagedWalletTransaction(string senderaddress, string walletpassword, CreateManagedWalletTransactionClass request)
        {
            return await Api.MakeTransaction(senderaddress, walletpassword, request);
        }

        public static async Task<ApiResponse<MintAndSendResultClass>> MintAndSendRandom(string projectUid, int nftCount, string receiverAddress)
        {
            return await Api.MintAndSendRandom(projectUid, nftCount, receiverAddress);
        }

        public static async Task<ApiResponse<PurchaseAndMintResult>> PurchaseAndMint(string projectUid, string managedWalletAddress, string managedWalletPassword, long itemPriceLovelace, int nftCount)
        {
            var response = new ApiResponse<PurchaseAndMintResult>();

            //Check wallet funds
            ApiResponse<TxInAddressesClass> getWalletResponse = await GetWalletUtxo(managedWalletAddress);
            if (getWalletResponse.success)
            {
                TxInAddressesClass walletUtxo = getWalletResponse.result;
                if (walletUtxo.lovelaceSummary < itemPriceLovelace)
                {
                    response.error = getWalletResponse.error;
                    return response;
                }
            }
            else
            {
                response.error = getWalletResponse.error;
                return response;
            }

            // Get project payout wallet
            var projectDetailsResponse = await GetProjectDetails(projectUid);
            if (projectDetailsResponse.success)
            {
                NftProjectsDetails projectDetails = projectDetailsResponse.result;
                string payoutAddress = projectDetails.adaPayoutWalletAddress;
                // Make transaction
                var transactionRequest = new CreateManagedWalletTransactionClass()
                {
                    receivers = new TransactionReceiversClass[]
                    {
                        new TransactionReceiversClass()
                        {
                            receiverAddress = payoutAddress,
                            receiverLovelace = itemPriceLovelace
                        },
                    }
                };

                var transactionResponse = await MakeManagedWalletTransaction(managedWalletAddress, managedWalletPassword, transactionRequest);
                if (transactionResponse.success && transactionResponse.result.state == MakeTransactionResults.success)
                {
                    var mintResponse = await Api.MintAndSendRandom(projectUid, nftCount, receiveraddress: managedWalletAddress);
                    if (mintResponse.success)
                    {
                        response.result = new PurchaseAndMintResult()
                        {
                            nfts = mintResponse.result.sendedNft
                        };
                        return response;
                    }
                    else
                    {
                        response.error = transactionResponse.error;
                        return response;
                    }
                }
                else
                {
                    response.error = transactionResponse.error;
                    return response;
                }
            }
            else
            {
                response.error = projectDetailsResponse.error;
                return response;
            }
        }
    }
}