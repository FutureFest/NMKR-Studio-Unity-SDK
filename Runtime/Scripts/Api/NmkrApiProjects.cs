using System;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// Creates a burning endpoint for a specific address.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="addressactiveinhours">Duration in hours for which the address remains active.</param>
        /// <param name="onSuccess">Action to perform on successful execution.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreateBurningAddress(string projectuid, int addressactiveinhours, Action<GetPaymentAddressResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"CreateBurningAddress/{projectuid}/{addressactiveinhours}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="request">Object containing project creation details.</param>
        /// <param name="onSuccess">Action to perform on successful creation.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreateProject(CreateProjectClassV2 request, Action<CreateNewProjectResultClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = "CreateProject";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Deletes a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier to delete.</param>
        /// <param name="onSuccess">Action to perform on successful deletion.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void DeleteProject(string projectuid, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"DeleteProject/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns the count of sold, reserved, and free NFTs for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetCounts(string projectuid, Action<NftCountsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetCounts/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves discount information for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetDiscounts(string projectuid, Action<GetDiscountsClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetDiscounts/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns information about the identities associated with a policy.
        /// </summary>
        /// <param name="policyid">Policy identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetIdentityAccounts(string policyid, Action<IdentityInformationClass> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetIdentityAccounts/{policyid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Returns the notifications for a specific project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetNotifications(string projectuid, Action<NotificationsClassV2[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetNotifications/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves sale conditions for a specific project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetSaleConditions(string projectuid, Action<SaleconditionsClassV2[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetSaleConditions/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Lists all your projects.
        /// </summary>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ListProjects(Action<NftProjectsDetails[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = "ListProjects";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// Lists all your projects with pagination.
        /// </summary>
        /// <param name="count">Number of projects to return per page.</param>
        /// <param name="page">Page number to retrieve.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ListProjects(int count, int page, Action<NftProjectsDetails[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"ListProjects/{count}/{page}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates discount information for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing discount update details.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateDiscounts(string projectuid, PriceDiscountClassV2 request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateDiscounts/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates notification settings for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing notification update details.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateNotifications(string projectuid, NotificationsClassV2 request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateNotifications/{projectuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates the pricelist for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing pricelist update details.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdatePricelist(string projectuid, PricelistClass request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdatePricelist/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates sale conditions for a project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing sale condition update details.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateSaleConditions(string projectuid, SaleconditionsClassV2 request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateSaleConditions/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves detailed information about a specific project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetProjectDetails(string projectuid, Action<NftProjectsDetails> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetProjectDetails/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves the pricelist for a specific project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetPricelist(string projectuid, Action<PricelistClassV2[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPricelist/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }
    }
}