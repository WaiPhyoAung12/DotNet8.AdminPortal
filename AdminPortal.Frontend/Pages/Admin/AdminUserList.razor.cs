using AdminPortal.Frontend.API;
using AdminPortal.Frontend.Constants;
using AdminPortal.Frontend.Shared;
using AdminPortal.Models.AdminUser;
using AdminPortal.Models.DataGrid;
using AdminPortal.Shared.Enums;
using AdminPortal.Shared.ResponseModels;
using MudBlazor;
using Radzen;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdminPortal.Frontend.Pages.Admin
{
    public partial class AdminUserList
    {
        private DataGridResponseModel<AdminUserModel> responseModel;
        public List<DataGridColumns> columns = new()
        {
            new DataGridColumns{PropertyName="Name",Title="Name"},
            new DataGridColumns{PropertyName="Address",Title="Address"},
            new DataGridColumns{PropertyName="PhoneNumber",Title="PhoneNumber"},
            new DataGridColumns{PropertyName="Email",Title="Email"},
        };
        
        protected override async Task OnInitializedAsync()
        {
            responseModel = new()
            {
                Columns = columns,

            };
        }
        private async Task LoadData(LoadDataArgs args)
        {
            try
            {
                await GetList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
        }
        private void Edit(AdminUserModel adminUserModel)
        {
            _injectionService.Go(PageUrl.EditAdminUser+"/"+adminUserModel.Id);
        }
        private async void Delete(AdminUserModel adminUserModel)
        {
            var dialogResult = await _injectionService.ConfirmDialogAsync<AdminUserModel>("Admin User", adminUserModel);
            if (dialogResult.Canceled == false)
            {
                var response = await _injectionService.CallApiAsync<AdminUserResponseModel>(string.Format(ApiRoute.DeleteAdminUser, adminUserModel.Id), EnumHttpMethod.POST);
                if (response.IsSuccess)
                {
                    await GetList();
                    StateHasChanged();
                }
            }

        }
        private async Task GetList()
        {
            var responseData = await _injectionService.CallApiAsync<AdminUserListResponseModel>(ApiRoute.AdminUserList, EnumHttpMethod.GET);

            if (responseData.Data is not null)
            {
                responseModel.Datalist = responseData.Data.AdminUserListModel;
            };
        }
       
    }
}