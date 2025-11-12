using System.Globalization;
using AmazonPriceWatcher.SharedObjects.Models.Enums;

namespace AmazonPriceWatcher.Helpers;

internal static class LocalisationHelper
{
    public static string GetLocalisedTld(Country country) => country switch
    {
        Country.Australia => "com.au",
        Country.Brazil => "com.br",
        Country.Canada => "ca",
        Country.China => "cn",
        Country.France => "fr",
        Country.Germany => "de",
        Country.India => "in",
        Country.Italy => "it",
        Country.Japan => "co.jp",
        Country.Mexico => "com.mx",
        Country.Netherlands => "nl",
        Country.Singapore => "com.sg",
        Country.Spain => "es",
        Country.Turkey => "com.tr",
        Country.UnitedKingdom => "co.uk",
        _ => "com",
    };

    public static CultureInfo GetCultureInfo(Country country)
    {
        string cultureCode = country switch
        {
            Country.Australia => "en-AU",
            Country.Brazil => "pt-BR",
            Country.Canada => "en-CA",
            Country.China => "zh-CN",
            Country.France => "fr-FR",
            Country.Germany => "de-DE",
            Country.India => "hi-IN",
            Country.Italy => "it-IT",
            Country.Japan => "ja-JP",
            Country.Mexico => "es-MX",
            Country.Netherlands => "nl-NL",
            Country.Singapore => "zh-SG",
            Country.Spain => "es-ES",
            Country.Turkey => "tr-TR",
            Country.UnitedKingdom => "en-GB",
            _ => "en-US",
        };

        return CultureInfo.GetCultureInfo(cultureCode);
    }
}
