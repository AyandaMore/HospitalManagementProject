using System.Threading.Tasks;
using ARHospitalProject.Configuration.Dto;

namespace ARHospitalProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
