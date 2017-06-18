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
    public partial class AddFuelDialog : Form
    {

        public string RegistrationNumber
        {
            set { lbl_Title.Text += " " + value.ToString(); }
        }


        public double FuelQuantity
        {
            get
            {
                double result = 0;
                double.TryParse(txt_FuelQuantity.Text, out result);
                return result;
            }
        }

        public AddFuelDialog()
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
