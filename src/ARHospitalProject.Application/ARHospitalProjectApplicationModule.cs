using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ARHospitalProject.Authorization;

namespace ARHospitalProject
{
    [DependsOn(
        typeof(ARHospitalProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ARHospitalProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ARHospitalProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ARHospitalProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
