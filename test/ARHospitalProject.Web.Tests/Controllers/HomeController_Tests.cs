using System.Threading.Tasks;
using ARHospitalProject.Models.TokenAuth;
using ARHospitalProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace ARHospitalProject.Web.Tests.Controllers
{
    public class HomeController_Tests: ARHospitalProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}