using AdminPortal.Frontend.API;
using AdminPortal.Frontend.Constants;
using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.Enums;
using AdminPortal.Shared.ResponseModels;
using Mapster;
using Microsoft.AspNetCore.Components;

namespace AdminPortal.Frontend.Pages.Admin
{
    public partial class UpdateAdminUser
    {
        [Parameter]
        public int Id { get; set; }
        private AdminUserRequestModel Model { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            var response =await _injectionService.CallApiAsync<AdminUserResponseModel>(string.Format(ApiRoute.AdminUser, Id), EnumHttpMethod.POST);
            
            response.Data.AdminUserModel.Adapt(Model);
        }
        private async Task OnValidSubmit()
        {
            var response=await _injectionService.CallApiAsync<AdminUserResponseModel>(ApiRoute.UpateAdminUser, EnumHttpMethod.POST,Model);
            _injectionService.Go(PageUrl.AdminUserList);
        }
    }
}