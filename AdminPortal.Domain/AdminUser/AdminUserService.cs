using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Domain.AdminUser
{
    public class AdminUserService(AdminUserRepo adminUserRepo) : IAdminUserService
    {
        public async Task<Result<AdminUserResponseModel>> Create(AdminUserRequestModel request)
        {
            return await adminUserRepo.Create(request);
        }

        public async Task<Result<AdminUserResponseModel>> DeleteAdminUser(int id)
        {
            return await adminUserRepo.DeleteAdminUser(id);
        }

        public async Task<Result<AdminUserResponseModel>> GetAdminUser(int id)
        {
            var response= await adminUserRepo.GetAdminUserById(id);
            return response;
        }

        public Result<AdminUserListResponseModel> GetAllAdminUsers()
        {
            return adminUserRepo.GetAdminUserList();
        }

        public Task<Result<AdminUserResponseModel>> UpdateAdminUser(AdminUserRequestModel requestModel)
        {
            return adminUserRepo.UpdateAdminUser(requestModel);
        }
    }
}
