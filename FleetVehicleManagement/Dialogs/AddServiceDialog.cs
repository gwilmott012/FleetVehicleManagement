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
        public string RegistrationNumber
        {
            set { lbl_Title.Text += " " + value.ToString(); }
        }

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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
