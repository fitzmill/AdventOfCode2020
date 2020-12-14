namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Day4
    {
        public static int Compute()
        {
            var input = File.ReadAllLines("inputs\\day4.txt");

            var passport = new Passport();
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    if (passport.IsValid()) count++; 
                    passport = new Passport();
                    continue;
                }
                var properties = input[i].Split(' ');
                foreach (string prop in properties)
                {
                    var val = prop.Substring(4);
                    switch (prop.Substring(0, 3))
                    {
                        case "byr":
                            passport.BirthYear = val;
                            break;
                        case "iyr":
                            passport.IssueYear = val;
                            break;
                        case "eyr":
                            passport.ExpirationYear = val;
                            break;
                        case "hgt":
                            passport.Height = val;
                            break;
                        case "hcl":
                            passport.HairColor = val;
                            break;
                        case "ecl":
                            passport.EyeColor = val;
                            break;
                        case "pid":
                            passport.PassportId = val;
                            break;
                        case "cid":
                            passport.CountryId = val;
                            break;
                    }
                }
            }
            if (passport.IsValid()) count++;
            return count;
        }
    }

    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(BirthYear) || !int.TryParse(BirthYear, out int byr) || byr < 1920 || byr > 2002) return false;
            if (string.IsNullOrEmpty(IssueYear) || !int.TryParse(IssueYear, out int iyr) || iyr < 2010 || iyr > 2020) return false;
            if (string.IsNullOrEmpty(ExpirationYear) || !int.TryParse(ExpirationYear, out int eyr) || eyr < 2020 || eyr > 2030) return false;
            if (string.IsNullOrEmpty(Height) || !int.TryParse(Height[0..^2], out int hgt)) return false;
            if (Height.EndsWith("cm"))
            {
                if (hgt < 150 || hgt > 193) return false;
            }
            else if (Height.EndsWith("in"))
            {
                if (hgt < 59 || hgt > 76) return false;
            }
            else
            {
                return false;
            }
            if (string.IsNullOrEmpty(HairColor) || HairColor.Length > 7 || HairColor[0] != '#') return false;
            if (!Regex.IsMatch(HairColor, "[0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f]")) return false;
            if (!int.TryParse(HairColor[1..], System.Globalization.NumberStyles.HexNumber, null, out int _)) return false;
            if (string.IsNullOrEmpty(EyeColor) || !(EyeColor == "amb" || EyeColor == "blu" || EyeColor == "brn" || EyeColor == "gry" || EyeColor == "grn" || EyeColor == "hzl" || EyeColor == "oth")) return false;
            if (string.IsNullOrEmpty(PassportId) || PassportId.Length != 9 || !int.TryParse(PassportId, out int _)) return false;
            return true;
        }
    }
}
