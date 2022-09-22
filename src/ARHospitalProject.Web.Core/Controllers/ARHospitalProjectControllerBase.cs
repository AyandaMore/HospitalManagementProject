using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ARHospitalProject.Controllers
{
    public abstract class ARHospitalProjectControllerBase: AbpController
    {
        protected ARHospitalProjectControllerBase()
        {
            LocalizationSourceName = ARHospitalProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
