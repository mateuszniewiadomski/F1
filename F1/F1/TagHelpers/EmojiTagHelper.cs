using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1.TagHelpers
{
    [HtmlTargetElement("emoji-helper", Attributes = ValueAttribute)]
    public class EmojiTagHelper : TagHelper
    {
        private const string ValueAttribute = "emoji-helper-value";
        [HtmlAttributeName(ValueAttribute)] public int Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string emojiString = "";
            while (Value > 0)
            {
                int x = (Value % 10);
                Value = Value / 10;
                switch (x)
                {
                    case 0:
                        emojiString = "0️⃣" + emojiString;
                        break;
                    case 1:
                        emojiString = "1️⃣" + emojiString;
                        break;
                    case 2:
                        emojiString = "2️⃣" + emojiString;
                        break;
                    case 3:
                        emojiString = "3️⃣" + emojiString;
                        break;
                    case 4:
                        emojiString = "4️⃣" + emojiString;
                        break;
                    case 5:
                        emojiString = "5️⃣" + emojiString;
                        break;
                    case 6:
                        emojiString = "6️⃣" + emojiString;
                        break;
                    case 7:
                        emojiString = "7️⃣" + emojiString;
                        break;
                    case 8:
                        emojiString = "8️⃣" + emojiString;
                        break;
                    case 9:
                        emojiString = "9️⃣" + emojiString;
                        break;
                    default:
                        break;
                }
            }       
            
            output.Content.SetContent(emojiString);
        }
    }
}
