/* Payroll.aspx.cs
 * Author: Travis Thaxter
 * Last Modified: 13/12/2019
 * Description: Form to enter the related worker information to calculate payment and notify the user and send the data to the database.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB06___Travis_Thaxter
{
    public partial class Payroll : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFirstName.Focus(); // initial focus on the first name field.
        }
        /// <summary>
        /// Handles the activation of the btnCalculate, intended to perform the desired calculation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCalculate_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                //creates worker according to which radio button is selected
                PieceworkWorker worker = (rblWorkerType.SelectedItem.Value == "Senior" ? new SeniorWorker(txtFirstName.Text, txtLastName.Text, txtMessagesSent.Text) : new PieceworkWorker(txtFirstName.Text, txtLastName.Text, txtMessagesSent.Text));
                lblPay.Text = worker.ToString(); // displays workers pay
                ToggleControls(false);
                btnClear.Focus();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        
        /// <summary>
        /// resets the form to initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        /// <summary>
        /// clears the form and re-enables controls
        /// </summary>
        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMessagesSent.Text = "";
            lblPay.Text = "";
            ToggleControls(true);
            txtFirstName.Focus();
        }
        /// <summary>
        /// Toggles the controls on the form
        /// </summary>
        protected void ToggleControls(bool enable)
        {
            btnCalculate.Enabled = enable;
            txtFirstName.Enabled = enable;
            txtLastName.Enabled = enable;
            txtMessagesSent.Enabled = enable;
            rblWorkerType.Enabled = enable;
        }
    }
}
