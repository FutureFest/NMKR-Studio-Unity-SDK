using Nmkr.Sdk.Schemas;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Nmkr.Sdk.Api;

namespace Nmkr.Sdk
{
    public class SdkWrapper
    {
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
                var result = response.result;
                List<TxInTokensClass> tokens = new List<TxInTokensClass>();
                for (int i = 0; i < result.txIn.Length; i++)
                {
                    var tx = result.txIn[i];
                    if(tx.tokens != null && tx.tokens.Length > 0)
                    {
                        tokens.AddRange(tx.tokens);
                    }
                }

                var assets = new WalletAssets()
                {
                    balanceInLovelace = result.lovelaceSummary,
                    tokens = tokens.ToArray()
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
                    },
                    senderaddress = managedWalletAddress,
                    walletpassword = managedWalletPassword
                };

                var transactionResponse = await Api.MakeTransaction(transactionRequest);
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
                },
                senderaddress = senderaddress,
                walletpassword = walletpassword
            };
            return await Api.MakeTransaction(transactionRequest);
        }
    }
}