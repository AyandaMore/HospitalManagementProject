using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ARHospitalProject.Configuration.Dto;

namespace ARHospitalProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ARHospitalProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
