namespace AdminPortal.Frontend.API
{
    public class ApiRoute
    {
        public static string AdminUserList { get; } = "/api/adminuser/list";
        public static string AdminUser { get; } = "/api/adminuser/{0}";
        public static string UpateAdminUser { get; } = "/api/adminuser/update";
        public static string DeleteAdminUser { get; } = "/api/adminuser/delete/{0}";
        public static string CreateAdminUser { get; } = "/api/adminuser/create";
    }
}
