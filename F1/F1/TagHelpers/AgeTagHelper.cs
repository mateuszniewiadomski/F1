using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1.TagHelpers
{
    [HtmlTargetElement("age-helper", Attributes = ValueAttribute)]
    public class AgeTagHelper: TagHelper
    {
        private const string ValueAttribute = "age-helper-value";
        [HtmlAttributeName(ValueAttribute)] public DateTime Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var today = DateTime.Today;

            var age = today.Year - Value.Year;

            if (Value.Date > today.AddYears(-age)) age--;

            string val = age.ToString();
            output.Content.SetContent(val);
        }
    }
}
