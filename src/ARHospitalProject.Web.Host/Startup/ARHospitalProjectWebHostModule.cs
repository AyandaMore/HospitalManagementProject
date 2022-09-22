using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ARHospitalProject.Configuration;

namespace ARHospitalProject.Web.Host.Startup
{
    [DependsOn(
       typeof(ARHospitalProjectWebCoreModule))]
    public class ARHospitalProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ARHospitalProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ARHospitalProjectWebHostModule).GetAssembly());
        }
    }
}
