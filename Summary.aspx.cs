/* Summary.aspx.cs
 * Author: Travis Thaxter
 * Last Modified: 13/12/2019
 * Description: Summary page of the workers entered into the database.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB06___Travis_Thaxter
{
    public partial class Summary : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotalWorkers.Text = Worker.TotalWorkers.ToString();
            lblCumulativeMessages.Text = Worker.TotalMessages.ToString();
            lblCumulativePay.Text = String.Format("{0:c}", Worker.TotalPay);
            lblAveragePay.Text = String.Format("{0:c}", Worker.AveragePay);
        }
    }
}