
using AdminPortal.Domain.AdminUser;
using AdminPortal.Models.AdminUser;
using AdminPortal.Shared.ResponseModels;

namespace AdminPortal.Backend.EndPoints.AdminUser
{
    public class AdminUserEndPoint : IEndPoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            var adminUserEndpoint = app.MapGroup("/api/adminuser").WithOpenApi();
            adminUserEndpoint.MapGet("/list", GetAllAdminUser);
            adminUserEndpoint.MapPost("/create", CreateAdminUser);
            adminUserEndpoint.MapPost("/update", UpdateAdminUser);
            adminUserEndpoint.MapPost("/delete/{id}", DeleteAdminUser);
            adminUserEndpoint.MapPost("/{id}", GetAdminUser);
        }
        private IResult GetAllAdminUser(IAdminUserService _adminUserService)
        {
            var response = _adminUserService.GetAllAdminUsers();
            return Results.Ok(response);
        }
        private async Task<Result<AdminUserResponseModel>>CreateAdminUser(AdminUserRequestModel adminUserRequest,IAdminUserService _adminUserService)
        {
            var response= await _adminUserService.Create(adminUserRequest);
            return response;
        }
        private async Task<Result<AdminUserResponseModel>> GetAdminUser(int id, IAdminUserService _adminUserService)
        {
            var response=await _adminUserService.GetAdminUser(id);
            return response;
        }
        private async Task<Result<AdminUserResponseModel>>UpdateAdminUser(AdminUserRequestModel requestModel,IAdminUserService _adminUserService)
        {
            return await _adminUserService.UpdateAdminUser(requestModel);
        }
        private async Task<Result<AdminUserResponseModel>> DeleteAdminUser(int id, IAdminUserService _adminUserService)
        {
            return await _adminUserService.DeleteAdminUser(id);
        }
    }
}
