using Unity.Services.Authentication;

namespace Nmkr.Demo
{
    public class ClientAccount
    {
        private static string _managedWalletAddress = null;

        public static string ManagedWalletAddress => _managedWalletAddress;
        public static string PlayerId => AuthenticationService.Instance.PlayerId;
        public static string Username => AuthenticationService.Instance.PlayerInfo.Username;
        // for simplicity of the demo, wallet password would be generated with the player's id.
        // This is not best practice
        public static string ManagedWalletPassword => AuthenticationService.Instance.PlayerId;

        public static void SetManagedWalletAddress(string walletAddress)
        {
            _managedWalletAddress = walletAddress;

        }
    }
}
