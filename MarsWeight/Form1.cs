using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsWeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateName(txtObject.Text, out string objectName, out string nameErrorMessage))
            {
                MessageBox.Show(nameErrorMessage, "Object Name Error");
                txtObject.Focus(); // Move focus to this TextBox for user to correct error
                return;         // Stop processing this event
            }
            if (!ValidatePositiveDouble(txtWeightEarth.Text, out double earthWeigth, out string weightErrorMessage)) //try
            {
                MessageBox.Show(weightErrorMessage, "Earth Weight Error");
                txtWeightEarth.Focus(); // Move focus to this TextBox for user to correct error
                return;         // Stop processing this event

            }
            double earthWeight = Double.Parse(txtWeightEarth.Text);
            double conversionFactor = 0.377;
            double marsWeight = earthWeight * conversionFactor;
            //txtWeightMars.Text = marsWeight.ToString();
            txtWeightMars.Text = String.Format("{0} weighs {1} On Mars", objectName, marsWeight);

            /*catch (FormatException)
            {
                MessageBox.Show("Enter numbers only", "Error");

            }
            catch (OverflowException)
            {
                MessageBox.Show("Enter a smaller number", "Error");
            }*/

        }

        private bool ValidatePositiveDouble(string text, out double number, out string errorMessage)
        {
            errorMessage = null;
            number = 0;

            try
            {
                number = double.Parse(text);

                if (number >= 0)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Enter a positive number";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "Enter a number";
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "Enter a smaller number";
                return false;
            }

        }

        private bool ValidateName(string text, out string name, out string errorMessage)
        {
            errorMessage = null;
            name = text;

            if (String.IsNullOrEmpty(text))
            {
                errorMessage = "Can't be empty";
                return false;

            }
            if (text.Length < 2)
            {
                errorMessage = "Enter at least 2 letters";
                return false;

            }
            return true;
        }
    }
}
