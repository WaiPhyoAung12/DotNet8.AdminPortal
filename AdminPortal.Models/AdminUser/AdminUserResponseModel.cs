using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Models.AdminUser
{
    public class AdminUserResponseModel
    {
        public AdminUserModel? AdminUserModel { get; set; }
    }
    public class AdminUserListResponseModel
    {
        public List<AdminUserModel> AdminUserListModel { get; set; }
    }
}
