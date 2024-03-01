using Nmkr.Sdk;
using Nmkr.Sdk.Schemas;
using System.Threading.Tasks;
using static Nmkr.Sdk.Api;

namespace Nmkr.Demo
{
    /// <summary>
    /// This class is a starter point for communication between a Unity game client and the Unity game server.
    /// Use multiplayer solutions like RPC calls.
    /// !DONT USE THIS DEMO IN PRODUCTION. YOU ARE RESPONSIBLE FOR THE SECURITY OF YOUR API KEYS AND OTHER SENSITIVE DATA!
    /// </summary>
    public class SDKServer
    {
        public static async Task<ApiResponse<WalletInfo>> CreateWallet(string walletName, string walletPassword)
        {
            return await SdkWrapper.CreateWallet(walletName, walletPassword);
        }

        public static async Task<ApiResponse<TxInAddressesClass>> GetWalletUtxo(string walletAddress)
        {
            return await Api.GetWalletUtxo(walletAddress);
        }

        public static async Task<ApiResponse<WalletAssets>> GetWalletAssets(string walletAddress)
        {
            return await SdkWrapper.GetWalletAssets(walletAddress);
        }

        public static async Task<ApiResponse<NftProjectsDetails>> GetProjectDetails(string projectUid)
        {
            return await Api.GetProjectDetails(projectUid);
        }

        public static async Task<ApiResponse<MakeTransactionResultClass>> MakeManagedWalletTransaction(CreateManagedWalletTransactionClass request)
        {
            return await Api.MakeTransaction(request);
        }

        public static async Task<ApiResponse<MintAndSendResultClass>> MintAndSendRandom(string projectUid, int nftCount, string receiverAddress)
        {
            return await Api.MintAndSendRandom(projectUid, nftCount, receiverAddress);
        }

        public static async Task<ApiResponse<PurchaseAndMintResult>> PurchaseAndMint(string projectUid, string managedWalletAddress, string managedWalletPassword, long itemPriceLovelace, int nftCount)
        {
            return await SdkWrapper.PurchaseAndMint(projectUid, managedWalletAddress, managedWalletPassword, itemPriceLovelace, nftCount);
        }
    }
}