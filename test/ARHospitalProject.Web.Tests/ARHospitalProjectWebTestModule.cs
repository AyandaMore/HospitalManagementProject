using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ARHospitalProject.EntityFrameworkCore;
using ARHospitalProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ARHospitalProject.Web.Tests
{
    [DependsOn(
        typeof(ARHospitalProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ARHospitalProjectWebTestModule : AbpModule
    {
        public ARHospitalProjectWebTestModule(ARHospitalProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ARHospitalProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ARHospitalProjectWebMvcModule).Assembly);
        }
    }
}