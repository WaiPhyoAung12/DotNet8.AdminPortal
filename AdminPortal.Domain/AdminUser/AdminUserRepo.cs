using AdminPortal.Database.AppDbContextModels;
using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.ResponseModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Domain.AdminUser
{
    public class AdminUserRepo(AppDbContext dbContext)
    {
        public async Task<Result<AdminUserResponseModel>>Create(AdminUserRequestModel adminUser)
        {
            TblAdmin tblAdmin = new TblAdmin()
            {
                Id = adminUser.Id,
                Name = adminUser.Name,
                Email = adminUser.Email,
                Address = adminUser.Address,
                PhoneNumber = adminUser.PhoneNumber,
                CreatedUserId = 1,
                DeleteFlag = false

            };
            dbContext.tblAdmin.AddAsync(tblAdmin);
            int result=await dbContext.SaveChangesAsync();
            if(result is 0)
            {
                return Result<AdminUserResponseModel>.Fail("Saving Error");
            }
            return Result<AdminUserResponseModel>.Success("Successfully Created");
        }

        public Result<AdminUserListResponseModel> GetAdminUserList()
        {
            AdminUserListResponseModel adminUserList = new();
            var response=dbContext.tblAdmin.Where(a=>a.DeleteFlag==false).ToList();
            if(response.Count is 0)
            {
                return Result<AdminUserListResponseModel>.Fail("No Record Found");
            }
            adminUserList.AdminUserListModel = response.Adapt<List<AdminUserModel>>();
            return Result<AdminUserListResponseModel>.Success("Admin User List", adminUserList);
        }
        public async Task<Result<AdminUserResponseModel>>GetAdminUserById(int id)
        {
            AdminUserResponseModel adminUser = new();
            var adminUserModel=await dbContext.tblAdmin.Where(a=>a.Id==id && a.DeleteFlag==false).FirstOrDefaultAsync();
            if(adminUserModel == null)
            {
                return Result<AdminUserResponseModel>.Fail("No Record Found");
            }
            adminUser.AdminUserModel=adminUserModel.Adapt<AdminUserModel>();
            return Result<AdminUserResponseModel>.Success("Found",adminUser);
        }
        public async Task<Result<AdminUserResponseModel>>UpdateAdminUser(AdminUserRequestModel requestModel)
        {
            TblAdmin adminTable = new();
            var response=await dbContext.tblAdmin.Where(a=>a.Id==requestModel.Id).FirstOrDefaultAsync();
            if(response is null)
            {
                return Result<AdminUserResponseModel>.Fail("No Record Found");
            }
            await using var transaction = await dbContext.Database.BeginTransactionAsync();

            requestModel.Adapt(adminTable);
            adminTable.UpdatedDate = DateTime.Now;
            adminTable.UpdatedUserId = 2;
            dbContext.tblAdmin.Update(adminTable);
            int result=await dbContext.SaveChangesAsync();
            if (result < 1) { 
                await transaction.RollbackAsync();
                return Result<AdminUserResponseModel>.Fail("Update Fail");
            }
            await transaction.CommitAsync();
            return Result<AdminUserResponseModel>.Success("Updage Success");
        }
        public async Task<Result<AdminUserResponseModel>>DeleteAdminUser(int id)
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync();
            var response =await dbContext.tblAdmin.Where(a=>a.Id == id && a.DeleteFlag==false).FirstOrDefaultAsync();
            if (response is null)
                return Result<AdminUserResponseModel>.Fail("No Record found");
           response.DeleteFlag =true;
            response.UpdatedDate = DateTime.Now;
            response.UpdatedUserId = 2;
            dbContext.tblAdmin.Update(response);
            int result=await dbContext.SaveChangesAsync();
            if (result < 1)
            {
               await transaction.RollbackAsync();
                return Result<AdminUserResponseModel>.Fail("Delete Fail");
            }
            await transaction.CommitAsync();
            return Result<AdminUserResponseModel>.Success("Successfully Delete");

        }
    }
}
