using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetVehicleManagement.Dialogs
{
    public partial class AddServiceDialog : Form
    {
		// sets the title label on the the form to include a space and the value being passed in as a string
		public string RegistrationNumber
        {
            set { lbl_Title.Text += " " + value.ToString(); }
        }

		// sets the text in odometer reading to the value being passed in
		public int TotalKmsTravelled
        {
            set
            {
                txt_OdometerReading.Text = value.ToString();
            }
        }

        public AddServiceDialog()
        {
            InitializeComponent();
        }

		// sets the dialog result to ok and closes the form
		private void btn_Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

		// sets the dialog result to cancel and closes the form
		private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
