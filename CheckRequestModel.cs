using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5
{
    internal class CheckRequestModel
    {
        public CheckRequestModel(string text, string language)
        {
            this.text = text;
            this.language = language;
            enabledOnly = false;
        }
        public string text { get; set; }
        public string? data { get; set; }
        public string language { get; set; }
        public string? altLanguages { get; set; }
        public string? motherTongue { get; set; }
        public string? preferredVariants { get; set; }
        public string? enabledRules { get; set; }
        public string? disabledRules { get; set; }
        public string? enabledCategories { get; set; }
        public string? disabledCategories { get; set; }
        public bool? enabledOnly { get; set; }
    }
}
