using System.Globalization;
using SharedObjects.Models.Enums;

namespace apw.Helpers
{
    public static class LocalisationHelper
    {
        public static string GetLocalisedTld(Country country)
        {
            switch (country)
            {
                case Country.Australia:
                    return "com.au";
                case Country.Brazil:
                    return "com.br";
                case Country.Canada:
                    return "ca";
                case Country.China:
                    return "cn";
                case Country.France:
                    return "fr";
                case Country.Germany:
                    return "de";
                case Country.India:
                    return "in";
                case Country.Italy:
                    return "it";
                case Country.Japan:
                    return "co.jp";
                case Country.Mexico:
                    return "com.mx";
                case Country.Netherlands:
                    return "nl";
                case Country.Singapore:
                    return "com.sg";
                case Country.Spain:
                    return "es";
                case Country.Turkey:
                    return "com.tr";
                case Country.UnitedKingdom:
                    return "co.uk";
                default:
                    return "com";
            }
        }

        public static CultureInfo GetCultureInfo(Country country)
        {
            string cultureCode = "en-US";

            switch (country)
            {
                case Country.Australia:
                    cultureCode = "en-AU";
                    break;
                case Country.Brazil:
                    cultureCode = "pt-BR";
                    break;
                case Country.Canada:
                    cultureCode = "en-CA";
                    break;
                case Country.China:
                    cultureCode = "zh-CN";
                    break;
                case Country.France:
                    cultureCode = "fr-FR";
                    break;
                case Country.Germany:
                    cultureCode = "de-DE";
                    break;
                case Country.India:
                    cultureCode = "hi-IN";
                    break;
                case Country.Italy:
                    cultureCode = "it-IT";
                    break;
                case Country.Japan:
                    cultureCode = "ja-JP";
                    break;
                case Country.Mexico:
                    cultureCode = "es-MX";
                    break;
                case Country.Netherlands:
                    cultureCode = "nl-NL";
                    break;
                case Country.Singapore:
                    cultureCode = "zh-SG";
                    break;
                case Country.Spain:
                    cultureCode = "es-ES";
                    break;
                case Country.Turkey:
                    cultureCode = "tr-TR";
                    break;
                case Country.UnitedKingdom:
                    cultureCode = "en-GB";
                    break;
            }

            return CultureInfo.GetCultureInfo(cultureCode);
        }
    }
}