using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tín_Phát_Metech
{
    public class Image_NV
    {
        public void Creat(TextBox txt, PictureEdit pic, DefaultLookAndFeel def)
        {
            var char_name = GetFirstAndLastLetterFromName(txt.Text);
            Size imageSize = new System.Drawing.Size(250, 250);
            Image img_name = GlyphPainter.CreateRoundedStubGlyph(def.LookAndFeel, imageSize, char_name);
            pic.Image = img_name;
        }

        private string GetFirstAndLastLetterFromName(string name)
        {
            string first = name.Substring(0, 1);
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            string last = new string(charArray);

            if (last.Contains(' '))
            {
                char[] splitchar = { ' ' };
                string[] temp = last.Split(splitchar);
                int b = temp[0].ToString().Length - 2;
                int c = temp[0].ToString().Length - 1;
                last = temp[0].ToString().Substring(c, 1);
            }
            else
            {
                return first.ToUpper();
            }

            return ConvertToUnsign(first + last).ToUpper();
        }

        Regex ConvertToUnsign_rg = null;

        private string ConvertToUnsign(string strInput)
        {
            if (ReferenceEquals(ConvertToUnsign_rg, null))
            {
                ConvertToUnsign_rg = new Regex("p{IsCombiningDiacriticalMarks}+");
            }
            var temp = strInput.Normalize(NormalizationForm.FormD);
            return ConvertToUnsign_rg.Replace(temp, string.Empty).Replace("đ", "d").Replace("Đ", "D").ToLower();
        }
    }
}
