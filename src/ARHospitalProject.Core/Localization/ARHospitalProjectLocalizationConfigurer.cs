using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ARHospitalProject.Localization
{
    public static class ARHospitalProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ARHospitalProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ARHospitalProjectLocalizationConfigurer).GetAssembly(),
                        "ARHospitalProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
