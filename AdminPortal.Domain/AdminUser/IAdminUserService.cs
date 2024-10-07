using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Domain.AdminUser
{
    public interface IAdminUserService
    {
        Task<Result<AdminUserResponseModel>>Create(AdminUserRequestModel request);
        Result<AdminUserListResponseModel> GetAllAdminUsers();
        Task<Result<AdminUserResponseModel>> GetAdminUser(int id);
        Task<Result<AdminUserResponseModel>> UpdateAdminUser(AdminUserRequestModel requestModel);
        Task<Result<AdminUserResponseModel>>DeleteAdminUser(int id);
    }
}
