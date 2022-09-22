using ARHospitalProject.Debugging;

namespace ARHospitalProject
{
    public class ARHospitalProjectConsts
    {
        public const string LocalizationSourceName = "ARHospitalProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "20c8499b54b94c60a703315c3dec6d35";
    }
}
