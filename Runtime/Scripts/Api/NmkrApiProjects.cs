using System;
using System.Threading.Tasks;
using Nmkr.Sdk.Schemas;

namespace Nmkr.Sdk
{
    public static partial class Api
    {
        /// <summary>
        /// When you call this endpoint, a Burning Address is created for this project. 
        /// All NFTs associated with this project (same policyid) that are sent to this 
        /// endpoint will be deleted (burned). All other NFTs will be sent back. 
        /// The policy of the project must still be active.If it is already locked, it can no longer be deleted
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="addressactiveinhours">Duration in hours for which the address remains active.</param>
        /// <param name="onSuccess">The burning address was created successfully</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void CreateBurningAddress(string projectuid, int addressactiveinhours, Action<CreateBurningEndpointClass> onSuccess, Action<ResponseError> onFailure = null)
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
        /// <param name="onSuccess">Returns the Apiresultclass with the information about the address incl. the assigned NFTs</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void DeleteProject(string projectuid, Action<ApiErrorResultClass> onSuccess, Action<ResponseError> onFailure = null)
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
        /// <param name="onSuccess">Returns the Identities(if available).</param>
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
        public static async void GetNotifications(string projectuid, Action<GetNotificationsClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetNotifications/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves the pricelist for a specific project. You will get the predefined prices for one or more NFTs
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetPricelist(string projectuid, Action<PricelistClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetPricelist/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// Retrieves detailed information about a specific project.
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async Task<ApiResponse<NftProjectsDetails>> GetProjectDetails(string projectuid, Action<NftProjectsDetails> onSuccess = null, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetProjectDetails/{projectuid}";
            return await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// You will get all active saleconditions for this project
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void GetSaleConditions(string projectuid, Action<GetSaleconditionsClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"GetSaleConditions/{projectuid}";
            await GetAsync(endpoint, onSuccess, onFailure);
        }


        /// <summary>
        /// You will receive a list with all of your projects
        /// IMPORTANT: This function uses an internal cache.All results will be cached for 10 seconds.
        /// You do not need to call this function more than once in 10 seconds, because the results will be the same.
        /// </summary>
        /// <param name="onSuccess">Action to perform on successful retrieval.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void ListProjects(Action<NftProjectsDetails[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = "ListProjects";
            await GetAsync(endpoint, onSuccess, onFailure);
        }

        /// <summary>
        /// You will receive a list with your projects with a certain count and at a certain page.
        /// IMPORTANT: This function uses an internal cache.All results will be cached for 10 seconds.
        /// You do not need to call this function more than once in 10 seconds, because the results will be the same.
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
        /// WIth this Controller you can update the discounts of a project. All old entries will be deleted. 
        /// If you want to clear the discounts, just send an empty array
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing discount update details.</param>
        /// <param name="onSuccess">The discounts was successfully updated.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateDiscounts(string projectuid, PriceDiscountClassV2[] request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateDiscounts/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// WIth this Controller you can update the notifications. All old entries will be deleted. 
        /// If you want to clear the notifications, just send an empty array
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing notification update details.</param>
        /// <param name="onSuccess">Action to perform on successful update.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateNotifications(string projectuid, NotificationsClassV2[] request, Action<GetNotificationsClass[]> onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateNotifications/{projectuid}";
            await PostAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates the pricelist for a project.
        /// WIth this Controller you can update a pricelist of a project. All old entries will be deleted. 
        /// If you want to clear the pricelist, just send an empty array
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing pricelist update details.</param>
        /// <param name="onSuccess">The pricelist was successfully updated.</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdatePricelist(string projectuid, PricelistClassV2[] request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdatePricelist/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }


        /// <summary>
        /// Updates sale conditions for a project.
        /// WIth this Controller you can update the saleconditions of a project. All old entries will be deleted. 
        /// If you want to clear the saleconditions, just send an empty array
        /// </summary>
        /// <param name="projectuid">Project unique identifier.</param>
        /// <param name="request">Object containing sale condition update details.</param>
        /// <param name="onSuccess">The saleconditions was successfully updated</param>
        /// <param name="onFailure">Action to perform on execution failure.</param>
        public static async void UpdateSaleConditions(string projectuid, SaleconditionsClassV2[] request, Action onSuccess, Action<ResponseError> onFailure = null)
        {
            var endpoint = $"UpdateSaleConditions/{projectuid}";
            await PutAsync(endpoint, request, onSuccess, onFailure);
        }
    }
}