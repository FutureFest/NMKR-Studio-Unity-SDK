using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nmkr.Sdk.Schemas
{
    [System.Serializable]
    public class NFT
    {
        public int id;
        public string uid;
        public string name;
        public string displayname;
        public string detaildata;
        public string ipfsLink;
        public string gatewayLink;
        public string state;
        public bool minted;
        public string policyId;
        public string assetId;
        public string assetname;
        public string fingerprint;
        public string initialMintTxHash;
        public string series;
        public long tokenamount;
        public long? price;
        public string selldate; // Assuming date-time is serialized as a string
        public string paymentGatewayLinkForSpecificSale;
    }

    [System.Serializable]
    public class AdaRatesClass
    {
        public float usdRate;
        public float eurRate;
        public float jpyRate;
        public float btcRate;
        public string effectivedate;
    }
    [System.Serializable]
    public class AddressTxInClass
    {
        public string address;
        public TxInClass[] utxo;
    }

    [System.Serializable]
    public class TxInClass
    {
        public string txHash;
        public int? txId;
        public long lovelace;
        public TxInTokensClass[] tokens;
        public string txHashId;
        public string txTimestamp;
        public long tokenSum;
    }

    [System.Serializable]
    public class TxInTokensClass
    {
        public string policyId;
        public string tokenname;
        public string tokennameHex;
        public long quantity;
        public string tokenHex;
        public string token;
        public string fingerprint;
    }

    [System.Serializable]
    public class ApiErrorResultClass
    {
        public string resultState; // Enum: [ "Ok", "Error" ]
        public string errorMessage;
        public int? errorCode;
        public string innerErrorMessage;
    }

    [System.Serializable]
    public class AssetsAssociatedWithAccount
    {
        public string unit;
        public long? quantity;
        public string fingerprint;
    }

    [System.Serializable]
    public class AuctionHistoryResultClass
    {
        public string txHash;
        public long bidAmount;
        public string created; // DateTime as string
        public string state; // Enum: [ "seller", "buyer", "outbid", "invalid", "expired" ]
        public string address;
        public string returnTxHash;
        public bool signedAndSubmitted;
    }

    [System.Serializable]
    public class AuctionParametersClass
    {
        public int durationInSeconds;
        public long minBet;
    }

    [System.Serializable]
    public class AuctionsHistory
    {
        public string txhash;
        public string senderaddress;
        public long bidamount;
        public string created; // DateTime as string
        public string state;
        public string returntxhash;
    }

    [System.Serializable]
    public class AuctionsNft
    {
        public string policyid;
        public string tokennamehex;
        public string ipfshash;
        public string metadata;
        public long tokencount;
    }

    [System.Serializable]
    public class AuctionsResultClass
    {
        public string jsonHash;
        public long minBet;
        public string runsUntil; // DateTime as string
        public long? actualBid;
        public AuctionHistoryResultClass[] history;
        public float? marketplaceFeePercent;
        public float? royaltyFeePercent;
    }

    [System.Serializable]
    public class BuyerClass
    {
        public TransactionAddressClass buyer;
        public long buyerOffer;
    }

    [System.Serializable]
    public class TransactionAddressClass
    {
        public string pkh;
        public AddressTxInClass[] addresses;
        public string collateralTxIn;
        public string changeAddress;
    }

    [System.Serializable]
    public class CheckAddressResultClass
    {
        public string state;
        public long lovelace;
        public long hasToPay;
        public Tokens[] additionalPriceInTokens;
        public string payDateTime;
        public string expiresDateTime;
        public string transaction;
        public string senderAddress;
        public NFT[] reservedNft;
        public string rejectReason;
        public string rejectParameter;
        public long? stakeReward;
        public long? discount;
        public string customProperty;
        public long? tokenReward;
        public long countNftsOrTokens;
        public string reservationType;
    }

    [System.Serializable]
    public class Tokens
    {
        public long countToken;
        public string policyId;
        public string assetNameInHex;
        public long multiplier;
        public long totalCount;
        public string assetName;
        public int decimals;
    }

    [System.Serializable]
    public class CheckConditionsResultClass
    {
        public bool conditionsMet;
        public string rejectReason;
        public string rejectParameter;
        public SendBackAddress sendBackAddress;
    }

    [System.Serializable]
    public class SendBackAddress
    {
        public string address;
        public string originatorAddress;
        public string stakeAddress;
    }

    [System.Serializable]
    public class CheckDiscountsResultClass
    {
        public float discountInPercent;
    }

    [System.Serializable]
    public class CheckWalletValidationResultClass
    {
        public string validationResult;
        public string senderAddress;
        public string stakeAddress;
        public long lovelace;
        public string validationaddress;
        public string validUntil;
        public string validationName;
    }


    [System.Serializable]
    public class CountedWhitelistAddressesClass
    {
        public string address;
        public long maxCount;
    }

    [System.Serializable]
    public class CreateBurningEndpointClass
    {
        public string address;
        public string validuntil; // Expected format: date-time
    }

    [System.Serializable]
    public class CreateManagedWalletTransactionClass
    {
        public TransactionReceiversClass[] receivers;
    }

    [System.Serializable]
    public class TransactionReceiversClass
    {
        public string receiverAddress;
        public long receiverLovelace;
        public TransactionTokensClass[] sendTokens;
    }

    [System.Serializable]
    public class TransactionTokensClass
    {
        public string policyId;
        public string assetNameInHex;
        public long quantity;
    }

    [System.Serializable]
    public class CreateNewProjectResultClass
    {
        public int projectId;
        public string metadata;
        public string policyId;
        public string policyScript;
        public string policyExpiration; // Expected format: date-time
        public string uid;
    }

    [System.Serializable]
    public class CreatePaymentTransactionClass
    {
        public string projectUid;
        public string paymentTransactionType; // enum [ paymentgateway_nft_specific, paymentgateway_nft_random, smartcontract_directsale, smartcontract_auction, legacy_auction, legacy_directsale, decentral_mintandsend_specific, decentral_mintandsend_random, decentral_mintandsale_specific, decentral_mintandsale_random, paymentgateway_mintandsend_specific, paymentgateway_mintandsend_random, nmkr_pay_random, nmkr_pay_specific, smartcontract_directsale_offer, paymentgateway_buyout_smartcontract ]
        public Dictionary<string, string> customProperties;
        public TransactionParametersClass[] transactionParameters;
        public PaymentgatewayParametersClass paymentgatewayParameters;
        public DecentralParametersClass decentralParameters;
        public AuctionParametersClass auctionParameters;
        public DirectSaleParameterClass directSaleParameters;
        public DirectSaleOfferParameterClass directSaleOfferParameters;
        public string customerIpAddress;
        public PaymentTransactionNotificationsClass[] paymentTransactionNotifications;
        public string referer;
        public string referencedPaymenttransactionUid;
    }

    [System.Serializable]
    public class TransactionParametersClass
    {
        public long tokencount;
        public string policyId;
        public string tokenname;
        public string tokennameHex;
    }

    [System.Serializable]
    public class PaymentgatewayParametersClass
    {
        public MintNftsClass mintNfts;
    }

    [System.Serializable]
    public class MintNftsClass
    {
        public long countNfts;
        public ReserveNftsClassV2[] reserveNfts;
    }

    [System.Serializable]
    public class ReserveNftsClassV2
    {
        public long lovelace;
        public string nftUid;
        public int? nftId; // Nullable due to deprecated: true
        public long tokencount;
    }

    [System.Serializable]
    public class DecentralParametersClass
    {
        public MintNftsClass mintNfts;
        public CreateRoyaltyTokenIfNotExistsClass createRoyaltyTokenIfNotExists;
    }

    [System.Serializable]
    public class CreateRoyaltyTokenIfNotExistsClass
    {
        public float percentage;
        public string address;
    }

    [System.Serializable]
    public class DirectSaleParameterClass
    {
        public long priceInLovelace;
        public string txHashForAlreadyLockedinAssets;
        public string smartContractName;
        public string overrideMarkteplaceFeeAddress;
        public double? overrideMarketplaceFee;
    }

    [System.Serializable]
    public class DirectSaleOfferParameterClass
    {
        public long offerInLovelace;
        public string txHashForAlreadyLockedinAssets;
        public string overrideMarkteplaceFeeAddress;
        public double? overrideMarketplaceFee;
    }

    [System.Serializable]
    public class PaymentTransactionNotificationsClass
    {
        public string notificationType; // enum [ webhook, email ]
        public string notificationEndpoint;
        public string hmacSecret;
    }

    [System.Serializable]
    public class CreateProjectClassV2
    {
        public string projectname;
        public string description;
        public string projecturl;
        public string tokennamePrefix;
        public string twitterHandle;
        public bool policyExpires;
        public string policyLocksDateTime; // Expected format: date-time
        public string payoutWalletaddress;
        public string payoutWalletaddressUsdc;
        public long maxNftSupply;
        public PolicyClass policy;
        public string metadataTemplate;
        public int addressExpiretime;
        public PricelistClassV2[] pricelist;
        public PayoutWalletsClassV2[] additionalPayoutWallets;
        public SaleconditionsClassV2[] saleConditions;
        public PriceDiscountClassV2[] discounts;
        public NotificationsClassV2[] notifications;
        public bool? enableFiat;
        public bool? enableDecentralPayments;
        public bool? enableCrossSaleOnPaymentgateway;
        public bool? activatePayinAddress;
        public string paymentgatewaysalestart; // Expected format: date-time
    }

    [System.Serializable]
    public class PolicyClass
    {
        public string policyId;
        public string privateVerifykey;
        public string privateSigningkey;
        public string policyScript;
    }

    [System.Serializable]
    public class PricelistClassV2
    {
        public long countNft;
        public long? priceInLovelace; // Nullable due to deprecated: true
        public float? price;
        public string currency; // Enum: ADA, USD, EUR, JPY
        public bool isActive;
        public string validFrom; // Expected format: date-time
        public string validTo; // Expected format: date-time
    }

    [System.Serializable]
    public class PayoutWalletsClassV2
    {
        public string payoutWallet;
        public double? valuePercent;
        public long? valueFixInLovelace;
    }

    [System.Serializable]
    public class SaleconditionsClassV2
    {
        public string condition; // Enum: [ walletcontainspolicyid, walletdoescontainmaxpolicyid, walletdoesnotcontainpolicyid, walletcontainsminpolicyid, walletmustcontainminofpolicyid, whitlistedaddresses, blacklistedaddresses, stakeonpool, countedwhitelistedaddresses ]
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public int? minOrMaxValue;
        public string description;
        public bool isActive;
        public string policyProjectname;
        public string[] blacklistedAddresses;
        public CountedWhitelistAddressesClass[] countedWhitelistAddresses;
    }

    [System.Serializable]
    public class PriceDiscountClassV2
    {
        public string condition; // Enum: walletcontainsminofpolicyid, whitlistedaddresses, stakeonpool
        public string description;
        public long? minvalue;
        public long? minvalue2;
        public long? minvalue3;
        public long? minvalue4;
        public long? minvalue5;
        public bool isActive;
        public float sendbackDiscount;
        public string policyIdOrStakeAddress1;
        public string policyIdOrStakeAddress2;
        public string policyIdOrStakeAddress3;
        public string policyIdOrStakeAddress4;
        public string policyIdOrStakeAddress5;
        public string[] whitelistedAddresses;
        public string policyProjectname;
        [JsonProperty("operator")] public string op;
    }

    [System.Serializable]
    public class NotificationsClassV2
    {
        public string notificationType; // Enum: webhook, email
        public string address;
        public bool isActive;
    }

    [System.Serializable]
    public class CreateWalletResultClass
    {
        public string address;
        [JsonProperty("adressType")] public string addressType;
        public string network;
        public string walletName;
        public string seedPhrase;
    }

    public struct WalletInfo
    {
        public string walletName;
        public string address;
        public string addressType;
        public string network;
    }

    // CurrencyTypesstring Enum
    public enum CurrencyTypes
    {
        ADA, USD, EUR, JPY // Enum options: ADA, USD, EUR, JPY
    }

    [System.Serializable]
    public class DecentralParametersResultClass
    {
        public MintNftsResultClass mintNfts;
        public long? priceInLovelace;
        public Tokens[] additionalPriceInTokens;
        public long? stakeRewards;
        public long? discount;
        public string rejectParameter;
        public string rejectReason;
        public long? tokenRewards;
    }

    [System.Serializable]
    public class MintNftsResultClass
    {
        public long? countNfts;
        public ReservedNftsClassV2[] reserveNfts;
    }

    [System.Serializable]
    public class ReservedNftsClassV2
    {
        public string nftUid;
        public long tokencount;
        public string tokennameHex;
        public string policyId;
        public int? nftId;
        public long? lovelace;
    }

    [System.Serializable]
    public class DeleteAllNftsDetail
    {
        public string nftUid;
        public string nftName;
        public string errorMessage;
    }

    [System.Serializable]
    public class DeleteAllNftsResultClass
    {
        public int successfullyDeleted;
        public int notDeleted;
        public DeleteAllNftsDetail[] errorDetails;
    }

    [System.Serializable]
    public class DirectSaleOfferResultsClass
    {
        public long offerPrice;
        public long lockedInAmount;
        public string buyerAddress;
        public string buyerTxDatumHash;
        public string buyerTxHash;
        public string buyerTxCreate; // Expected format: date-time
        public string sellerAddress;
        public SmartcontractDirectsaleReceiverClass[] receivers;
    }

    [System.Serializable]
    public class SmartcontractDirectsaleReceiverClass
    {
        public string pkh;
        public string address;
        public long amountInLovelace;
        public Tokens[] tokens;
        public string recevierType;
    }

    [System.Serializable]
    public class DirectSaleResultsClass
    {
        public long sellingPrice;
        public long lockedInAmount;
        public string sellerAddress;
        public string buyerAddress;
        public string sellerTxDatumHash;
        public string sellerTxHash;
        public string sellerTxCreate; // Expected format: date-time
        public SmartcontractDirectsaleReceiverClass[] receivers;
        public GetPaymentAddressResultClass buyoutSmartcontractAddress;
    }

    [System.Serializable]
    public class GetPaymentAddressResultClass
    {
        public string paymentAddress;
        public int paymentAddressId;
        public string expires; // Expected format: date-time
        public string adaToSend;
        public string debug;
        public float priceInEur;
        public float priceInUsd;
        public float priceInJpy;
        public float priceInBtc;
        public string effectivedate; // Expected format: date-time
        public long priceInLovelace;
        public Tokens[] additionalPriceInTokens;
        public long sendbackToUser;
        public string revervationtype;
    }

    [System.Serializable]
    public class DuplicateNftClass
    {
        public int countDuplicates;
        public string tokennameprefix;
        public string tokennamesuffix;
        public string displaynameprefix;
        public string displaynamesuffix;
        public int startingNumber;
        public int leadingZeros;
        public string tokennameSample;
        public string displaySample;
        public bool setDisplayName;
    }

    [System.Serializable]
    public class FrankenAddressProtectionClass
    {
        public string address;
        public string originatorAddress;
        public string stakeAddress;
    }

    [System.Serializable]
    public class GetAuctionStateResultClass
    {
        public string auctionname;
        public string auctionType;
        public string address;
        public long minbet;
        public long actualbet;
        public string runsuntil; // Expected format: date-time
        public string selleraddress;
        public string highestbidder;
        public string created; // Expected format: date-time
        public string state;
        public float? royaltyfeespercent;
        public string royaltyaddress;
        public float? marketplacefeepercent;
        public AuctionsNft[] auctionsNfts;
        public AuctionsHistory[] auctionshistories;
    }

    [System.Serializable]
    public class GetDiscountsClass
    {
        public string condition; // Enum: walletcontainsminofpolicyid, whitlistedaddresses, stakeonpool
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public long? minOrMaxValue;
        public string description;
        public float discountInPercent;
        public long? minValue1;
        public long? minValue2;
        public long? minValue3;
        public long? minValue4;
        public long? minValue5;
        [JsonProperty("operator")] public string op;
    }

    public enum PricelistDiscountTypes
    {
        walletcontainsminofpolicyid,
        whitlistedaddresses,
        stakeonpool
    }

    [System.Serializable]
    public class GetNotificationsClass
    {
        public string notificationType; // Enum: webhook, email
        public string address;
        public bool isActive;
        public string secret;
    }

    public enum PaymentTransactionNotificationTypes
    {
        webhook,
        email
    }

    [System.Serializable]
    public class GetPayoutWalletsResultClass
    {
        public string walletAddress;
        public string created; // Expected format: date-time
        public PayoutWalletState state; // Enum: Active, NotActive, Blocked, ConfirmationExpired
        public string comment;
    }

    public enum PayoutWalletState
    {
        Active, NotActive, Blocked, ConfirmationExpired
    }

    [System.Serializable]
    public class GetSaleconditionsClass
    {
        public SaleConditionsTypes condition; // Enum: walletcontainspolicyid, walletdoescontainmaxpolicyid, ...
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public long? minOrMaxValue;
        public string description;
        public string policyProjectname;
        public WhitelistetedCountClass[] whitelistedAddresses;
        public string[] blacklistedAddresses;
        public bool? onlyOneSalePerWhitelistAddress;
        public WhitelistetedCountClass[] alreadyUsedAddressOrStakeaddress;
    }

    public enum SaleConditionsTypes
    {
        walletcontainspolicyid, walletdoescontainmaxpolicyid, walletdoesnotcontainpolicyid,
        walletcontainsminpolicyid, walletmustcontainminofpolicyid, whitlistedaddresses,
        blacklistedaddresses, stakeonpool, countedwhitelistedaddresses
    }

    [System.Serializable]
    public class WhitelistetedCountClass
    {
        public string address;
        public long countNft;
        public string stakeAddress;
    }

    [System.Serializable]
    public class GetWalletValidationAddressResultClass
    {
        public string validationUId;
        public string address;
        public string expires; // Expected format: date-time
        public long lovelace;
    }

    [System.Serializable]
    public class GetWhitelistEntriesClass
    {
        public string addresss;
        public string stakeaddress;
        public long countNftsOrTokens;
        public string created; // Expected format: date-time
        public long totalSoldNftsOrTokens;
        public SoldNftsOrTokensFromWhitelist[] soldNftsOrTokens;
    }

    [System.Serializable]
    public class SoldNftsOrTokensFromWhitelist
    {
        public string usedaddress;
        public string originatoraddress;
        public string transactionid;
        public string created; // Expected format: date-time
        public long countnft;
    }

    [System.Serializable]
    public class IdentityInformationClass
    {
        public long? date;
        public string policyId;
        public string[] accounts; // missing type/class
        public bool? signatures;
    }

    [System.Serializable]
    public class ImportManagedWalletClass
    {
        public string walletName;
        public string walletPassword;
        public string[] seedWords;
        public bool enterpriseAddress;
    }

    [System.Serializable]
    public class ImportWalletResultClass
    {
        public string address;
        public string adressType;
        public string network;
        public string walletName;
    }

    [System.Serializable]
    public class MakeTransactionResultClass
    {
        public MakeTransactionResults state; // Enum: error, success
        public string errorMessage;
        public string txHash;
        public string executed; // Expected format: date-time
        public long? fee;
    }

    public enum MakeTransactionResults
    {
        error, success
    }

    [System.Serializable]
    public class MetadataPlaceholderClass
    {
        public string name;
        public string value;
    }

    [System.Serializable]
    public class MintAndSendReceiverClass
    {
        public string receiverAddress;
    }

    [System.Serializable]
    public class MintAndSendResultClass
    {
        public int? mintAndSendId;
        public NFT[] sendedNft;
    }

    public enum MintAndSendSubstates
    {
        execute, success, error, canceled, invalid
    }

    [System.Serializable]
    public class NftCountsClass
    {
        public long nftTotal;
        public long sold;
        public long free;
        public long reserved;
        public long error;
        public long blocked;
        public long totalTokens;
        public long totalBlocked;
        public long unknownOrBurnedState;
    }

    [System.Serializable]
    public class NftDetailsClass
    {
        public int id;
        public string ipfshash;
        public string state;
        public string name;
        public string displayname;
        public string detaildata;
        public bool minted;
        public string receiveraddress;
        public string selldate; // Expected format: date-time
        public string soldby;
        public string reserveduntil; // Expected format: date-time
        public string policyid;
        public string assetid;
        public string assetname;
        public string fingerprint;
        public string initialminttxhash;
        public string title;
        public string series;
        public string ipfsGatewayAddress;
        public string metadata;
        public long? singlePrice;
        public string uid;
        public string paymentGatewayLinkForSpecificSale;
        public long sendBackCentralPaymentInLovelace;
        public long priceInLovelaceCentralPayments;
        public string uploadSource;
    }

    [System.Serializable]
    public class NftFileV2
    {
        public string mimetype;
        public string fileFromBase64;
        public string fileFromsUrl;
        public string fileFromIPFS;
    }

    [System.Serializable]
    public class NftProjectsDetails
    {
        public int id;
        public string projectname;
        public string projecturl;
        public string projectLogo;
        public string state;
        public long free;
        public long sold;
        public long reserved;
        public long total;
        public long blocked;
        public long totalBlocked;
        public long totalTokens;
        public long error;
        public long unknownOrBurnedState;
        public string uid;
        public long maxTokenSupply;
        public string description;
        public int addressReservationTime;
        public string policyId;
        public bool enableCrossSaleOnPaymentGateway;
        public string adaPayoutWalletAddress;
        public string usdcPayoutWalletAddress;
        public bool enableFiatPayments;
        public string paymentGatewaySaleStart; // Expected format: date-time
        public bool enableDecentralPayments;
        public string policyLocks; // Expected format: date-time
        public string royaltyAddress;
        public float? royaltyPercent;
        public long? lockslot;
        public bool disableManualMintingbutton;
        public bool disableRandomSales;
        public bool disableSpecificSales;
        public string twitterHandle;
        public NmkrAccountOptionsTypes nmkrAccountOptions; // Enum: none, accountnecessary, accountandkycnecessary
        public string crossmintCollectiondId;
    }

    public enum NmkrAccountOptionsTypes
    {
        none, accountnecessary, accountandkycnecessary
    }

    [System.Serializable]
    public class NftSubfileFileV2
    {
        public NftFileV2 subfile;
        public string description;
        public MetadataPlaceholderClass[] metadataPlaceholder;
    }

    [System.Serializable]
    public class NmkrAssetAddress
    {
        public string policyId;
        public string assetName;
        public string fingerprint;
        public long? totalSupply;
        public long multiplier;
        public string address;
        public long quantity;
        public int decimals;
    }

    public enum PaymentMethodTypes
    {
        ADA, FIAT, SOL, ETH
    }

    [System.Serializable]
    public class PaymentTransactionResultClass
    {
        public string paymentTransactionUid;
        public string projectUid;
        public PaymentTransactionTypes paymentTransactionType; // Enum defined below
        public Dictionary<string, string> customProperties;
        public PaymentTransactionsStates state; // Enum defined below
        public TransactionParametersClass[] transactionParameters;
        public string paymentTransactionCreated; // Expected format: date-time
        public PaymentgatewayResultsClass paymentgatewayResults;
        public PaymentTransactionSubStateResultClass paymentTransactionSubStateResult;
        public AuctionsResultClass auctionResults;
        public DirectSaleResultsClass directSaleResults;
        public DirectSaleOfferResultsClass directSaleOfferResults;
        public DecentralParametersResultClass decentralParameters;
        public PaymentTransactionsMintAndSendResultClass mintAndSendResults;
        public SmartContractInformationResultClass smartContractInformation;
        public string cbor;
        public string signedCbor;
        public string expires; // Expected format: date-time
        public string signGuid;
        public long? fee;
        public string txHash;
        public string nmkrPayUrl;
        //public ReferencedTransaction referencedTransaction; // Define class ReferencedTransaction accordingly
        public string customeripaddress;
        public string referer;
    }

    public enum PaymentTransactionTypes
    {
        paymentgateway_nft_specific, paymentgateway_nft_random, smartcontract_directsale,
        smartcontract_auction, legacy_auction, legacy_directsale, decentral_mintandsend_specific,
        decentral_mintandsend_random, decentral_mintandsale_specific, decentral_mintandsale_random,
        paymentgateway_mintandsend_specific, paymentgateway_mintandsend_random, nmkr_pay_random,
        nmkr_pay_specific, smartcontract_directsale_offer, paymentgateway_buyout_smartcontract
    }

    public enum PaymentTransactionsStates
    {
        active, expired, finished, prepared, error, canceled, rejected
    }

    public enum PaymentTransactionSubstates
    {
        waitingforlocknft, waitingforbid, sold, canceled, readytosignbyseller,
        readytosignbysellercancel, readytosignbybuyer, readytosignbybuyercancel,
        auctionexpired, waitingforsale, submitted, confirmed, waitingforlockada
    }

    public enum AuctionHistoryStates
    {
        seller, buyer, outbid, invalid, expired
    }

    [System.Serializable]
    public class PaymentgatewayResultsClass
    {
        public long? priceInLovelace;
        public long? fee;
        public long? minUtxo;
        public MintNftsResultClass mintNfts;
        public Tokens[] additionalPriceInTokens;
    }

    [System.Serializable]
    public class PaymentTransactionSubStateResultClass
    {
        public PaymentTransactionSubstates paymentTransactionSubstate;
        public string lastTxHash;
    }

    [System.Serializable]
    public class PaymentTransactionsMintAndSendResultClass
    {
        public MintAndSendSubstates state;
        public string transactionId;
        public string executed; // Expected format: date-time
        public string receiverAddress;
    }

    [System.Serializable]
    public class SmartContractInformationResultClass
    {
        public string smartcontractName;
        public string smartcontractType;
        public string smartcontractAddress;
    }

    public enum ResultStates
    {
        Ok, Error
    }

    [System.Serializable]
    public class PricelistClass
    {
        public long countNft;
        public long priceInLovelace;
        public string adaToSend;
        public float priceInEur;
        public float priceInUsd;
        public float priceInJpy;
        public float priceInBtc;
        public string effectivedate; // Expected format: date-time
        public Tokens[] additionalPriceInTokens;
        public string paymentGatewayLinkForRandomNftSale;
        public string currency;
        public long sendBackCentralPaymentInLovelace;
        public string sendBackCentralPaymentInAda;
        public long priceInLovelaceCentralPayments;
        public string adaToSendCentralPayments;
    }

    [System.Serializable]
    public class ProblemDetails
    {
        public string type;
        public string title;
        public int? status;
        public string detail;
        public string instance;
    }

    [System.Serializable]
    public class RejectedErrorResultClass
    {
        public ResultStates resultState;
        public string errorMessage;
        public int errorCode;
        public string rejectReason;
        public string rejectParameter;
    }

    [System.Serializable]
    public class ReserveMultipleNftsClassV2
    {
        public ReserveNftsClassV2[] reserveNfts;
    }



    [System.Serializable]
    public class RoyaltyClass
    {
        public float percentage;
        public string address;
        public string pkh;
    }

    [System.Serializable]
    public class SellerClass
    {
        public TransactionAddressClass seller;
    }

    [System.Serializable]
    public class SignDecentralClass
    {
        public TransactionAddressClass buyer;
    }

    [System.Serializable]
    public class SmartcontractDirectsaleDatumInformationClass
    {
        public long totalPriceInLovelace;
        public string smartContractName;
        public string smartContractAddress;
        public string nmkrPayLink;
        public string preparedPaymentTransactionId;
        public string datumCbor;
        public SmartcontractDirectsaleReceiverClass[] receivers;
    }

    [System.Serializable]
    public class SubmitTransactionClass
    {
        public string signedCbor;
        public string signGuid;
    }

    [System.Serializable]
    public class TokenRegistryMetadata
    {
        public string name;
        public string description;
        public string ticker;
        public string url; // URL type
        public string logo;
        public long? decimals;
    }

    [System.Serializable]
    public class TxInAddressesClass
    {
        public string address;
        public string stakeAddress;
        public TxInClass[] txIn;
        public long lovelaceSummary;
        public int tokensSum;
        public string dataProvider;
        public long totalTokenSum;
        public TxInTokensClass[] getAllTokens;
    }

    [System.Serializable]
    public class UploadMetadataClass
    {
        public string metadata;
    }

    [System.Serializable]
    public class UploadNftClassV2
    {
        public string tokenname;
        public string displayname;
        public string description;
        public NftFileV2 previewImageNft;
        public NftSubfileFileV2[] subfiles;
        public MetadataPlaceholderClass[] metadataPlaceholder;
        public string metadataOverride;
        public long? priceInLovelace;
        public bool? isBlocked;
    }

    [System.Serializable]
    public class UploadNftResultClass
    {
        public int nftId;
        public string nftUid;
        public string ipfsHashMainnft;
        public string[] ipfsHashSubfiles;
        public string metadata;
        public string assetId;
    }

    [System.Serializable]
    public class UploadToIpfsClass
    {
        public string mimetype;
        public string fileFromBase64;
        public string fileFromsUrl;
        public string name;
    }

    // Api calls this "Wallets"
    [System.Serializable]
    public class Wallet
    {
        public string address;
        [JsonProperty("adressType")] public string addressType;
        public string network;
        public string walletName;
        public string state;
        public string created; // Expected format: date-time
    }

}