using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Patterns.RandomCode
{
    public class Times
    {
        public static void Run()
        {
            Times t = new Times();
            t.GetTimezoneInfo();
            t.GetTimeZoneShort();
        }

        public void GetTimezoneInfo()
        {
            foreach (TimeZoneInfo item in TimeZoneInfo.GetSystemTimeZones().Where(x => x.DisplayName.Contains("Haiti")))
            {
                Console.WriteLine(item.DaylightName);
                Console.WriteLine(item.StandardName);
                Console.WriteLine(item.DisplayName);
                Console.WriteLine(item.Id);
                Console.WriteLine(item.SupportsDaylightSavingTime);
            }
        }

        public void GetTimeZoneShort()
        {
            Dictionary<string, string> TimezoneAbbreviationMapping = new Dictionary<string, string>()
            {
                {"Dateline Standard Time", "IDLW"},
                {"UTC-11", "UTC-11"},
                {"Aleutian Standard Time", "HAST"},
                {"Hawaiian Standard Time", "HST"},
                {"Marquesas Standard Time", "MART"},
                {"Alaskan Standard Time", "AKST"},
                {"UTC-09", "UTC-09"},
                {"UTC-08", "UTC-08"},
                {"Pacific Standard Time (Mexico)", "PST"},
                {"Pacific Standard Time", "PST"},
                {"US Mountain Standard Time", "MST"},
                {"Mountain Standard Time (Mexico)", "MST"},
                {"Mountain Standard Time", "MST"},
                {"Central America Standard Time", "CT"},
                {"Central Standard Time", "CST"},
                {"Easter Island Standard Time", "EAST"},
                {"Central Standard Time (Mexico)", "CST"},
                {"Canada Central Standard Time", "CST"},
                {"Cuba Standard Time", "CST"},
                {"SA Pacific Standard Time", "PET"},
                {"Eastern Standard Time", "EST"},
                {"Eastern Standard Time (Mexico)", "EST"},
                {"Haiti Standard Time", "EST"},
                {"US Eastern Standard Time", "EST"},
                {"Venezuela Standard Time", "VET"},
                {"Paraguay Standard Time", "PYST"},
                {"Atlantic Standard Time", "AST"},
                {"Turks And Caicos Standard Time", "AST"},
                {"Central Brazilian Standard Time", "AMT"},
                {"SA Western Standard Time", "BOT"},
                {"Pacific SA Standard Time", "CLT"},
                {"Newfoundland Standard Time", "NST"},
                {"E. South America Standard Time", "BRT"},
                {"Tocantins Standard Time", "BRT"},
                {"Argentina Standard Time", "ART"},
                {"SA Eastern Standard Time", "GFT"},
                {"Greenland Standard Time", "WGT"},
                {"Montevideo Standard Time", "UYT"},
                {"Bahia Standard Time", "BRT"},
                {"UTC-02", "UTC-02"},
                {"Mid-Atlantic Standard Time", "MAT"},
                {"Saint Pierre Standard Time", "PMST"},
                {"Azores Standard Time", "AZOT"},
                {"Cape Verde Standard Time", "CVT"},
                {"Morocco Standard Time", "WET"},
                {"UTC", "UTC"},
                {"GMT Standard Time", "GMT"},
                {"Greenwich Standard Time", "GMT"},
                {"W. Europe Standard Time", "CET"},
                {"Central Europe Standard Time", "CET"},
                {"Romance Standard Time", "CET"},
                {"Central European Standard Time", "CET"},
                {"W. Central Africa Standard Time", "WAT"},
                {"Namibia Standard Time", "WAT"},
                {"Jordan Standard Time", "AST"},
                {"GTB Standard Time", "EET"},
                {"Middle East Standard Time", "EET"},
                {"Egypt Standard Time", "EET"},
                {"Syria Standard Time", "EET"},
                {"E. Europe Standard Time", "EET"},
                {"South Africa Standard Time", "CAT"},
                {"FLE Standard Time", "EET"},
                {"Turkey Standard Time", "EET"},
                {"Israel Standard Time", "IST"},
                {"Kaliningrad Standard Time", "EET"},
                {"West Bank Standard Time", "EET"},
                {"Libya Standard Time", "EET"},
                {"Arabic Standard Time", "AST"},
                {"Arab Standard Time", "AST"},
                {"Belarus Standard Time", "FET"},
                {"Russian Standard Time", "MSK"},
                {"E. Africa Standard Time", "EAT"},
                {"Iran Standard Time", "IRST"},
                {"Arabian Standard Time", "GST"},
                {"Azerbaijan Standard Time", "AZT"},
                {"Russia Time Zone 3", "SAMT"},
                {"Mauritius Standard Time", "MUT"},
                {"Georgian Standard Time", "GET"},
                {"Caucasus Standard Time", "AMT"},
                {"Astrakhan Standard Time", "MSD"},
                {"Afghanistan Standard Time", "AFT"},
                {"West Asia Standard Time", "UZT"},
                {"Ekaterinburg Standard Time", "YEKT"},
                {"Pakistan Standard Time", "PKT"},
                {"India Standard Time", "IST"},
                {"Sri Lanka Standard Time", "IST"},
                {"Nepal Standard Time", "NPT"},
                {"Tomsk Standard Time", "OMST"},
                {"Altai Standard Time", "OMST"},
                {"Central Asia Standard Time", "ALMT"},
                {"Bangladesh Standard Time", "BST"},
                {"N. Central Asia Standard Time", "NOVT"},
                {"Myanmar Standard Time", "MMT"},
                {"SE Asia Standard Time", "ICT"},
                {"North Asia Standard Time", "KRAT"},
                {"China Standard Time", "CST"},
                {"North Asia East Standard Time", "IRKT"},
                {"Singapore Standard Time", "MYT"},
                {"W. Australia Standard Time", "AWST"},
                {"Taipei Standard Time", "CST"},
                {"Ulaanbaatar Standard Time", "ULAT"},
                {"W. Mongolia Standard Time", "ULAT"},
                {"North Korea Standard Time", "KST"},
                {"Aus Central W. Standard Time", "CWT"},
                {"Transbaikal Standard Time", "YAKT"},
                {"Tokyo Standard Time", "JST"},
                {"Korea Standard Time", "KST"},
                {"Yakutsk Standard Time", "YAKT"},
                {"Cen. Australia Standard Time", "ACST"},
                {"AUS Central Standard Time", "ACST"},
                {"E. Australia Standard Time", "AEST"},
                {"AUS Eastern Standard Time", "AEST"},
                {"West Pacific Standard Time", "CHST"},
                {"Tasmania Standard Time", "AEST"},
                {"Magadan Standard Time", "VLAT"},
                {"Vladivostok Standard Time", "VLAT"},
                {"Russia Time Zone 10", "SRET"},
                {"Central Pacific Standard Time", "SBT"},
                {"Lord Howe Standard Time", "LHST"},
                {"Russia Time Zone 11", "PETT"},
                {"New Zealand Standard Time", "NZST"},
                {"Bougainville Standard Time", "BST"},
                {"Norfolk Standard Time", "NFT"},
                {"Sakhalin Standard Time", "SAKT"},
                {"UTC+12", "UTC+12"},
                {"Fiji Standard Time", "FJT"},
                {"Kamchatka Standard Time", "PETT"},
                {"Chatham Islands Standard Time", "CHAST"},
                {"Tonga Standard Time", "TOT"},
                {"Samoa Standard Time", "SST"},
                {"Line Islands Standard Time", "LINT"}
            };
            ReadOnlyCollection<TimeZoneInfo> timeZoneInfo = TimeZoneInfo.GetSystemTimeZones();
            foreach (KeyValuePair<string, string> item in TimezoneAbbreviationMapping)
            {
                TimeZoneInfo ds2 = timeZoneInfo.First(t => t.Id.Equals(item.Key));
                string ds = item.Value.LastIndexOf("ST") > 0 && item.Value.LastIndexOf("ST") == item.Value.IndexOf("ST") &&
                            item.Value.LastIndexOf("ST") == item.Value.Length - 2
                    ? item.Value.Replace("ST", "DT")
                    : "";
                ds = ds.Contains("SST") ? ds.Replace("SST", "DT") : ds;
                if (ds == "" )
                {
                    this.FillInMissingDS(item.Key, ref ds);
                }

                if (ds2.IsDaylightSavingTime(DateTime.UtcNow))
                {
                    //Console.WriteLine("Daylight>>>"+ds + "  " + ds2.DaylightName);
                    //Console.WriteLine("Standard>>>"+item.Value + "  " + ds2.StandardName);
                Console.WriteLine("{\"" + item.Key + "\", new TimeZoneInfoAbbreviation(\"" + item.Value + "\",\"" + ds + "\")},");
                    //Console.WriteLine("_________________________________________________________");
                }
                else
                {
                    //Console.WriteLine("*********NO DAYLIGHT FOR{0}",item.Key);

                    Console.WriteLine("{\"" + item.Key + "\", new TimeZoneInfoAbbreviation(\"" + item.Value + "\",\"\")},");
                }
                //var abbreviations = TZNames.GetAbbreviationsForTimeZone(item.Key, "en-US");
                //if (abbreviations != null)
                //{
                //    if (abbreviations.IsDaylightSavingTime(DateTime.UtcNow))
                //    {
                //        return abbreviations.Daylight;
                //    }
                //    return abbreviations.Standard;
                //}
            }


            }

        private void FillInMissingDS(string item ,ref string ds)
        {
            switch (item)
            {
                case "Easter Island Standard Time":
                    ds = "EASST";
                    break;
                case "Pacific SA Standard Time":
                    ds = "CLST";
                    break;
                case "Greenland Standard Time":
                    ds = "WGST";
                    break;
                case "Mid-Atlantic Standard Time":
                    ds = "MADT";
                    break;
                case "Azores Standard Time":
                    ds = "AZOST";
                    break;
                case "Morocco Standard Time":
                    ds = "WEST";
                    break;
                case "GMT Standard Time":
                    ds = "BST";
                    break;
                case "W. Europe Standard Time":
                case "Central Europe Standard Time":
                case "Romance Standard Time":
                case "Central European Standard Time":
                    ds = "CEST";
                    break;
                case "GTB Standard Time":
                case "Middle East Standard Time":
                case "Syria Standard Time":
                case "E. Europe Standard Time":
                case "FLE Standard Time":
                case "Turkey Standard Time":
                case "West Bank Standard Time":
                    ds = "EEST";
                    break;
                case "Ulaanbaatar Standard Time":
                case "W. Mongolia Standard Time":
                    ds = "ULAST";
                    break;
                case "Kamchatka Standard Time":
                    ds = "PETST";
                    break;
                default:
                {
                    ds = "";
                    break;
                }
            }
             
        }
    }

    public class TimeZoneInfoAbbreviation
    {
        public string StandardTimeAbbreviation;
        public string DaylightSavingTimeAbbreviation;

        public TimeZoneInfoAbbreviation(string standardTime, string daylightSavingsTime)
        {
            StandardTimeAbbreviation = standardTime;
            DaylightSavingTimeAbbreviation = daylightSavingsTime;
        }

    }
}

