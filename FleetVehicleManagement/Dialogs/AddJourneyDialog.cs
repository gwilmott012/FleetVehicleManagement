﻿using FleetVehicleManagement.Entities;
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
    public partial class AddJourneyDialog : Form
    {
		// sets the title label on the the form to include a space and the value being passed in as a string
		public string RegistrationNumber {
            set { lbl_Title.Text += " " + value.ToString(); }
        }

		// declares a integer (result) and trys to parse txt_NoDays to result and returns it
		public int NumberDays
        {
            get
            {
                int result = 0;
                int.TryParse(txt_NoDays.Text, out result);
                return result;
            }
        }

		// declares a integer (result) and trys to parse txt_kmsTravelled to result and returns it
		public int KmsTravelled
        {
            get
            {
                int result = 0;
                int.TryParse(txt_kmsTravelled.Text, out result);
                return result;
            }
        }

        public Journey.Rental RentalType
        {
            get
            {
                Journey.Rental result;
                Enum.TryParse<Journey.Rental>(cb_RentalType.SelectedValue.ToString(), out result);
                return result;
            }
        }

        public AddJourneyDialog()
        {
            InitializeComponent();

            cb_RentalType.DataSource = Enum.GetValues(typeof(Journey.Rental));
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
