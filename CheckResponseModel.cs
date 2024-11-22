using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal class CheckResponseModel
    {
        public LanguageInfo language { get; set; }
        public DetectedLanguageInfo detectedLanguage { get; set; }
        public List<Match> matches { get; set; }
        public SoftwareInfo software { get; set; }
    }

    public class LanguageInfo
    {
        public string code { get; set; }
    }

    public class DetectedLanguageInfo
    {
        public string code { get; set; }
        public string name { get; set; }
        public double confidence { get; set; }
    }

    public class Match
    {
        public MatchContext context { get; set; }
        public string message { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public List<Replacement> replacements { get; set; }
        public string sentence { get; set; }
        public RuleInfo rule { get; set; }
    }

    public class MatchContext
    {
        public int length { get; set; }
    }

    public class Replacement
    {
        public string value { get; set; }
    }

    public class RuleInfo
    {
        public string shortMessage { get; set; }
    }

    public class SoftwareInfo
    {
        public int apiVersion { get; set; }
        public string buildDate { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public bool? premium { get; set; }
        public string? status { get; set; }
    }
}
