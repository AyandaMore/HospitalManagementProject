using Abp.Authorization;
using ARHospitalProject.Authorization.Roles;
using ARHospitalProject.Authorization.Users;

namespace ARHospitalProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
