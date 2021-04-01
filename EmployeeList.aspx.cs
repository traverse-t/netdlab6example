/* EmployeeList.aspx.cs
 * Author: Travis Thaxter
 * Last Modified: 13/12/2019
 * Description: A page containing a list of all entered employees and their information, 
 * and the controls needed to edit employee entries.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB06___Travis_Thaxter
{
    public partial class EmployeeList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /// <summary>
        /// Updates alter fields with relevant data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFirstName.Text = gvEmployeeList.SelectedRow.Cells[2].Text;
            txtLastName.Text = gvEmployeeList.SelectedRow.Cells[3].Text;
            txtMessagesSent.Text = gvEmployeeList.SelectedRow.Cells[4].Text;
            rblWorkerType.SelectedValue = gvEmployeeList.SelectedRow.Cells[7].Text;
            ToggleControls(true);
        }
        /// <summary>
        /// Updates the worker with the modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                int id = int.Parse(gvEmployeeList.SelectedRow.Cells[1].Text);
                //creates worker according to which radio button is selected
                PieceworkWorker worker = (rblWorkerType.SelectedItem.Value == "Senior" ? new SeniorWorker(txtFirstName.Text, txtLastName.Text, txtMessagesSent.Text, id) : new PieceworkWorker(txtFirstName.Text, txtLastName.Text, txtMessagesSent.Text, id));
                UpdateTable();
                ToggleControls(false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        /// <summary>
        /// Toggles the controls on the form
        /// </summary>
        protected void ToggleControls(bool enable)
        {
            btnUpdate.Enabled = enable;
            txtFirstName.Enabled = enable;
            txtLastName.Enabled = enable;
            txtMessagesSent.Enabled = enable;
            rblWorkerType.Enabled = enable;
        }
        /// <summary>
        /// Updates table with altered data.
        /// </summary>
        protected void UpdateTable()
        {
            gvEmployeeList.DataSource = Worker.AllWorkers.DefaultView; // data population
            gvEmployeeList.DataBind();
        }
    }
}