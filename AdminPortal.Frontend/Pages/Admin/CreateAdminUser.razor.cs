using AdminPortal.Frontend.API;
using AdminPortal.Frontend.Constants;
using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.Enums;
using AdminPortal.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;

namespace AdminPortal.Frontend.Pages.Admin
{
    public partial class CreateAdminUser
    {
        public AdminUserRequestModel Model { get; set; } = new();
        private async Task OnValidSubmit()
        {
            var response=await _injectionService.CallApiAsync<AdminUserResponseModel>(ApiRoute.CreateAdminUser,EnumHttpMethod.POST,Model);
           if(response.IsSuccess is false)
            {
                 _injectionService.Go(PageUrl.CreateAdmin);
            }
           _injectionService.Go(PageUrl.AdminUserList);
        }
    }
}