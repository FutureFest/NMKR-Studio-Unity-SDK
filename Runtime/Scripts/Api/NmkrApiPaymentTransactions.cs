using System;
using System.Collections.Generic;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Creates a payment transaction.
        /// </summary>
        /// <param name="request">The request body for creating the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful creation of the transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreatePaymentTransaction(CreatePaymentTransactionClass request, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = "CreatePaymentTransaction";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }

        /// <summary>
        /// Gets the transaction state of a specific payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier for the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of the transaction state.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetTransactionState(string paymenttransactionuid, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/GetTransactionState";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves the payment address for a specific payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier for the payment transaction.</param>
        /// <param name="paymentMethod">Specifies the payment method for the transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of the payment address.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetPaymentAddress(string paymenttransactionuid, PaymentMethodTypes paymentMethod, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/GetPaymentAddress?paymentMethod={paymentMethod}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Signs a decentralized payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier for the payment transaction.</param>
        /// <param name="signDecentralRequest">The request object containing data for signing the decentral payment.</param>
        /// <param name="onSuccess">Action to perform on successful signing of the payment transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void SignDecentralPayment(string paymenttransactionuid, SignDecentralClass signDecentralRequest, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/SignDecentralPayment";
            await PostAsync(endpoint, signDecentralRequest, onSuccess, onFailure);
        }


        /// <summary>
        /// Checks the payment address for a specific transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CheckPaymentAddress(string paymenttransactionuid, Action<CheckAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/CheckPaymentAddress";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Cancels a payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="buyerDetails">Buyer details for the transaction.</param>
        /// <param name="onSuccess">Action to perform on successful cancellation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CancelTransaction(string paymenttransactionuid, BuyerClass buyerDetails, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/CancelTransaction";
            await PostAsync(endpoint, buyerDetails, onSuccess, onFailure);
        }

        /// <summary>
        /// Cancels a payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful cancellation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CancelTransaction(string paymenttransactionuid, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/CancelTransaction";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Retrieves the pricelist for a specific project based on a payment transaction ID.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval of the pricelist.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetPriceListForProject(string paymenttransactionuid, Action<PricelistClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/GetPriceListForProject";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Locks an NFT based on a specific payment transaction ID.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="seller">Seller information for the transaction.</param>
        /// <param name="onSuccess">Action to perform on successful locking of the NFT.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void LockNft(string paymenttransactionuid, SellerClass seller, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/LockNft";
            await PostAsync(endpoint, seller, onSuccess, onFailure);
        }

        /// <summary>
        /// Locks ADA based on a specific payment transaction ID.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="buyer">Buyer information for the transaction.</param>
        /// <param name="onSuccess">Action to perform on successful locking of the ADA.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void LockAda(string paymenttransactionuid, BuyerClass buyer, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/LockAda";
            await PostAsync(endpoint, buyer, onSuccess, onFailure);
        }

        /// <summary>
        /// Submits a transaction based on a specific payment transaction ID.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="submitTransaction">Transaction submission data.</param>
        /// <param name="onSuccess">Action to perform on successful submission of the transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void SubmitTransaction(string paymenttransactionuid, SubmitTransactionClass submitTransaction, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/SubmitTransaction";
            await PostAsync(endpoint, submitTransaction, onSuccess, onFailure);
        }


        /// <summary>
        /// Places a bet on an auction based on a specific payment transaction ID.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="buyer">Buyer information for placing the bet.</param>
        /// <param name="onSuccess">Action to perform on successful placement of the bet.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void BetOnAuction(string paymenttransactionuid, BuyerClass buyer, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/BetOnAuction";
            await PostAsync(endpoint, buyer, onSuccess, onFailure);
        }

        /// <summary>
        /// Initiates a direct sale purchase for a specified payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="buyer">Buyer information for the direct sale purchase.</param>
        /// <param name="onSuccess">Action to perform on successful purchase.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void BuyDirectsale(string paymenttransactionuid, BuyerClass buyer, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/BuyDirectsale";
            await PostAsync(endpoint, buyer, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves the smart contract address for a buyout associated with a specific payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetBuyoutSmartcontractAddress(string paymenttransactionuid, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/GetBuyoutSmartcontractAddress";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Offers a direct sale for a specific payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="seller">Details of the seller initiating the offer.</param>
        /// <param name="onSuccess">Action to perform on successful transaction.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void SellDirectsaleOffer(string paymenttransactionuid, SellerClass seller, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/SellDirectsaleOffer";
            await PostAsync(endpoint, seller, onSuccess, onFailure);
        }

        /// <summary>
        /// Ends a specific payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful transaction completion.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void EndTransaction(string paymenttransactionuid, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/EndTransaction";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Reserves the minting and sending of an NFT through the payment gateway.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="onSuccess">Action to perform on successful reservation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ReservePaymentgatewayMintAndSendNft(string paymenttransactionuid, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/ReservePaymentgatewayMintAndSendNft";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Mints and sends an NFT via the payment gateway.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="receiver">The receiver's information for minting and sending.</param>
        /// <param name="onSuccess">Action to perform on successful minting and sending.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void MintAndSendPaymentgatewayNft(string paymenttransactionuid, MintAndSendReceiverClass receiver, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/MintAndSendPaymentgatewayNft";
            await PostAsync(endpoint, receiver, onSuccess, onFailure);
        }

        /// <summary>
        /// Updates custom properties for a payment transaction.
        /// </summary>
        /// <param name="paymenttransactionuid">Unique identifier of the payment transaction.</param>
        /// <param name="customProperties">The custom properties to update.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateCustomProperties(string paymenttransactionuid, Dictionary<string, string> customProperties, Action<PaymentTransactionResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ProceedPaymentTransaction/{paymenttransactionuid}/UpdateCustomProperties";
            await PostAsync(endpoint, customProperties, onSuccess, onFailure);
        }
    }
}