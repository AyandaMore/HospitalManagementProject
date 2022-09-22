using System.ComponentModel.DataAnnotations;

namespace ARHospitalProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}