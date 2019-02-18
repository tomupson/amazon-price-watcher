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
    }
}