using FleetVehicleManagement.Dialogs;
using FleetVehicleManagement.Entities;
using FleetVehicleManagement.SeedCode;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FleetVehicleManagement.Forms
{
    public partial class VehicleManagementForm : Form
    {

        public List<Vehicle> VehiclesList { get; set; }
        string registrationNo;
        public VehicleManagementForm()
        {
            InitializeComponent();

            txt_OutPut.Enabled = true;
            txt_OutPut.ReadOnly = true;

            VehiclesList = new List<Entities.Vehicle>();
            CreateVehicles();
            populateOutputs();

        }


        private void populateOutputs()
        {
            populateVehicleGridView();
            populateOutputTextBox();
        }

        private void populateVehicleGridView()
        {
            VehicleGridView.AutoGenerateColumns = false;
            VehicleGridView.Columns[0].DataPropertyName = "Manufacturer";
            VehicleGridView.Columns[1].DataPropertyName = "Registration";
            VehicleGridView.Columns[2].DataPropertyName = "RequiresServicing";
            VehicleGridView.DataSource = VehiclesList;
            VehicleGridView.Refresh();

        }

        private void populateOutputTextBox()
        {
            txt_OutPut.Text = string.Empty;
            foreach (var v in VehiclesList)
            {
                txt_OutPut.Text += v.ToString() + Environment.NewLine + Environment.NewLine;
            }
        }

        private void VehicleGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            registrationNo = VehicleGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (VehicleGridView.Columns[e.ColumnIndex].Name == "AddJourney")
            {
                Vehicle vehicle = GetVehicleForRegNumber(registrationNo);
                if (vehicle != null)
                {
                    AddJourneyDialog jDialog = new AddJourneyDialog();

                    bool requiresService = vehicle.RequiresService();
                    if (requiresService == false)
                    {



                        jDialog.StartPosition = FormStartPosition.CenterParent;
                        jDialog.ControlBox = false;
                        jDialog.Text = String.Empty;

                        jDialog.RegistrationNumber = registrationNo;
                        DialogResult result = jDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Journey newJourney = new Journey(jDialog.RentalType, jDialog.NumberDays, jDialog.KmsTravelled);


                            {
                                vehicle.AddJourney(newJourney);
                                populateOutputs();
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Sorry. This vehicle requires a service and cannot be rented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (VehicleGridView.Columns[e.ColumnIndex].Name == "AddFuel")
            {

                AddFuelDialog fDialog = new Dialogs.AddFuelDialog();

                fDialog.StartPosition = FormStartPosition.CenterParent;
                fDialog.ControlBox = false;
                fDialog.Text = String.Empty;

                fDialog.RegistrationNumber = registrationNo;
                DialogResult result = fDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FuelPurchase fuelPurchase = new FuelPurchase(fDialog.FuelQuantity);

                    Vehicle vehicle = GetVehicleForRegNumber(registrationNo);
                    if (vehicle != null)
                    {
                        vehicle.AddFuelPurchase(fuelPurchase);
                        populateOutputs();
                    }
                }




            }
            else if (VehicleGridView.Columns[e.ColumnIndex].Name == "AddService")
            {

                Vehicle vehicle = GetVehicleForRegNumber(registrationNo);
                if (vehicle != null)
                {
                    int TotalKmsTravelled = vehicle.GetTotalKms();

                    AddServiceDialog sDialog = new AddServiceDialog();
                    sDialog.TotalKmsTravelled = TotalKmsTravelled;

                    sDialog.StartPosition = FormStartPosition.CenterParent;
                    sDialog.ControlBox = false;
                    sDialog.Text = String.Empty;

                    sDialog.RegistrationNumber = registrationNo;
                    DialogResult result = sDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Service service = new Service(TotalKmsTravelled);

                        vehicle.AddService(service);
                        populateOutputs();
                    }
                }
            }
        }


        private Vehicle GetVehicleForRegNumber(string registrationNo)
        {
            foreach (var v in VehiclesList)
            {
                if (v.Registration==registrationNo)
                {
                    return v;
                }
            }
            return null;
        }



        private void CreateVehicles()
        {
            Vehicle v1 = new Vehicle(2015, "Honda", "CR-V", "1ABC-001");

            v1.AddJourney(new Journey(Journey.Rental.Daily, 3, 450));
            v1.AddJourney(new Journey(Journey.Rental.None, 3, 50));
            v1.AddJourney(new Journey(Journey.Rental.PerKM, 3, 450));
            v1.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v1.AddFuelPurchase(new FuelPurchase(25));
            v1.AddFuelPurchase(new FuelPurchase(25));
            v1.AddFuelPurchase(new FuelPurchase(50));

            v1.AddService(new Service(100));
            v1.AddService(new Service(200));
            v1.AddService(new Service(300));
            v1.AddService(new Service(400));
            v1.AddService(new Service(500));
            v1.AddService(new Service(600));
            v1.AddService(new Service(700));
            v1.AddService(new Service(800));
            v1.AddService(new Service(900));


            Vehicle v2 = new Vehicle(2016, "Toyota", "Highlander", "1ABD-002");

            v2.AddJourney(new Journey(Journey.Rental.PerKM, 3, 600));
            v2.AddJourney(new Journey(Journey.Rental.None, 3, 50));
            v2.AddJourney(new Journey(Journey.Rental.PerKM, 3, 450));
            v2.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v2.AddFuelPurchase(new FuelPurchase(50));
            v2.AddFuelPurchase(new FuelPurchase(50));
            v2.AddFuelPurchase(new FuelPurchase(75));

            v2.AddService(new Service(100));
            v2.AddService(new Service(200));
            v2.AddService(new Service(900));


            Vehicle v3 = new Vehicle(2016, "Ford", "F-150", "1BEC-003");

            v3.AddJourney(new Journey(Journey.Rental.Daily, 5, 450));
            v3.AddJourney(new Journey(Journey.Rental.Daily, 3, 50));
            v3.AddJourney(new Journey(Journey.Rental.PerKM, 3, 700));
            v3.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v3.AddFuelPurchase(new FuelPurchase(60));
            v3.AddFuelPurchase(new FuelPurchase(60));
            v3.AddFuelPurchase(new FuelPurchase(80));

            v3.AddService(new Service(100));
            v3.AddService(new Service(200));
            v3.AddService(new Service(300));
            v3.AddService(new Service(400));
            v3.AddService(new Service(500));
            v3.AddService(new Service(600));
            v3.AddService(new Service(700));
            v3.AddService(new Service(800));
            v3.AddService(new Service(900));
            v3.AddService(new Service(1000));
            v3.AddService(new Service(1100));
            v3.AddService(new Service(1200));


            Vehicle v4 = new Vehicle(2016, "Mazda", "CX-5", "1BDT-004");

            v4.AddJourney(new Journey(Journey.Rental.PerKM, 5, 450));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 50));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 700));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 55));

            v4.AddFuelPurchase(new FuelPurchase(10));
            v4.AddFuelPurchase(new FuelPurchase(10));
            v4.AddFuelPurchase(new FuelPurchase(5));

            v4.AddService(new Service(100));
            v4.AddService(new Service(200));
            v4.AddService(new Service(300));
            v4.AddService(new Service(400));
            v4.AddService(new Service(500));
            v4.AddService(new Service(600));
            v4.AddService(new Service(700));
            v4.AddService(new Service(800));
            v4.AddService(new Service(900));
            v4.AddService(new Service(1000));
            v4.AddService(new Service(1100));
            v4.AddService(new Service(1200));


            Vehicle v5 = new Vehicle(2017, "Honda", "Civic", "1ABE-005");

            v5.AddJourney(new Journey(Journey.Rental.Daily, 5, 450));

            v5.AddFuelPurchase(new FuelPurchase(10));

            v5.AddService(new Service(100));
            v5.AddService(new Service(200));

            VehiclesList.Add(v1);
            VehiclesList.Add(v2);
            VehiclesList.Add(v3);
            VehiclesList.Add(v4);
            VehiclesList.Add(v5);
        }
    }
}
