using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement.Managements
{
    internal class InputValidateHelper
    {
        public static void ValidateTextBoxLength(TextBox textBox,int minLengh, int maxLengh)
        {
            if(textBox.Text.Length < minLengh)
            {
                //TODO: 
            }
            else if (textBox.Text.Length > maxLengh)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                MessageBox.Show(TextDictionary.MESSAGE_TEXT_LENGH_LIMITED);
            }
        }

        public static void ValidateNumberic(TextBox textBox, int minNoDigit, int maxNoDigit)
        {
            if (textBox.Text.Length < minNoDigit) textBox.Text = "0";
            if (textBox.Text.Length > maxNoDigit) textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Text = "0";
                MessageBox.Show("Accept numberic only!");
            }
        }

        public static void ValidateTextBoxLength(RichTextBox rTextBox, int minLengh, int maxLengh)
        {
            if (rTextBox.Text.Length < minLengh)
            {
                //TODO: 
            }
            else if (rTextBox.Text.Length > maxLengh)
            {
                rTextBox.Text = rTextBox.Text.Remove(rTextBox.Text.Length - 1);
                MessageBox.Show(TextDictionary.MESSAGE_TEXT_LENGH_LIMITED);
            }
        }
    }
}
