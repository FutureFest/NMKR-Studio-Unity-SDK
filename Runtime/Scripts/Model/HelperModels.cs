using System;

namespace Nmkr.Sdk.Schemas
{
    public class PurchaseAndMintResult
    {
        public NFT[] nfts;
    }

    public struct WalletInfo
    {
        public string walletName;
        public string address;
        public string addressType;
        public string network;
    }

    public struct WalletAssets
    {
        /// <summary>
        /// fullbalance in just lovelace
        /// </summary>
        public long balanceInLovelace;

        /// <summary>
        /// fullbalance in ada as a float
        /// </summary>
        public float balanceInAda { get { return (float)balanceInLovelace / 1000000; }}

        /// <summary>
        /// in whole ada
        /// </summary>
        /// 
        public long adaAmount { get { return balanceInLovelace / 1000000; }}

        /// <summary>
        /// just the lovelace parts
        /// </summary>
        public long lovelaceAmount { get { return balanceInLovelace % 1000000; }}

        public TxInTokensClass[] tokens;
    }

    public struct WalletToken
    {
        public string policyId;
        public string tokenname;
        public string tokennameHex;
        public long quantity;
        public string tokenHex;
        public string token;
        public string fingerprint;
        public string ipfsGatewayAddress;
    }


}