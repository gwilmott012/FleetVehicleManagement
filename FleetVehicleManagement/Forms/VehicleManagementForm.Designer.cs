namespace FleetVehicleManagement.Forms
{
    partial class VehicleManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VehicleGridView = new System.Windows.Forms.DataGridView();
            this.txt_OutPut = new System.Windows.Forms.TextBox();
            this.VehicleMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleRegistration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleRequireService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddFuel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddRental = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddService = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VehicleGridView
            // 
            this.VehicleGridView.AllowUserToDeleteRows = false;
            this.VehicleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VehicleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleMake,
            this.VehicleRegistration,
            this.VehicleRequireService,
            this.AddFuel,
            this.AddRental,
            this.AddService});
            this.VehicleGridView.Location = new System.Drawing.Point(22, 38);
            this.VehicleGridView.Name = "VehicleGridView";
            this.VehicleGridView.Size = new System.Drawing.Size(631, 440);
            this.VehicleGridView.TabIndex = 0;
            this.VehicleGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VehicleGridView_CellContentClick);
            // 
            // txt_OutPut
            // 
            this.txt_OutPut.Enabled = false;
            this.txt_OutPut.Location = new System.Drawing.Point(683, 38);
            this.txt_OutPut.Multiline = true;
            this.txt_OutPut.Name = "txt_OutPut";
            this.txt_OutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_OutPut.Size = new System.Drawing.Size(353, 440);
            this.txt_OutPut.TabIndex = 1;
            // 
            // VehicleMake
            // 
            this.VehicleMake.HeaderText = "Make";
            this.VehicleMake.Name = "VehicleMake";
            this.VehicleMake.ReadOnly = true;
            this.VehicleMake.Width = 90;
            // 
            // VehicleRegistration
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VehicleRegistration.DefaultCellStyle = dataGridViewCellStyle3;
            this.VehicleRegistration.HeaderText = "Registration No";
            this.VehicleRegistration.Name = "VehicleRegistration";
            // 
            // VehicleRequireService
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VehicleRequireService.DefaultCellStyle = dataGridViewCellStyle4;
            this.VehicleRequireService.HeaderText = "Requires a Service";
            this.VehicleRequireService.Name = "VehicleRequireService";
            this.VehicleRequireService.Width = 90;
            // 
            // AddFuel
            // 
            this.AddFuel.HeaderText = "";
            this.AddFuel.Name = "AddFuel";
            this.AddFuel.ReadOnly = true;
            this.AddFuel.Text = "Add Fuel";
            this.AddFuel.UseColumnTextForButtonValue = true;
            this.AddFuel.Width = 95;
            // 
            // AddRental
            // 
            this.AddRental.HeaderText = "";
            this.AddRental.Name = "AddRental";
            this.AddRental.ReadOnly = true;
            this.AddRental.Text = "Add Rental";
            this.AddRental.UseColumnTextForButtonValue = true;
            this.AddRental.Width = 95;
            // 
            // AddService
            // 
            this.AddService.HeaderText = "";
            this.AddService.Name = "AddService";
            this.AddService.ReadOnly = true;
            this.AddService.Text = "Add Service";
            this.AddService.UseColumnTextForButtonValue = true;
            this.AddService.Width = 95;
            // 
            // VehicleManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 541);
            this.Controls.Add(this.txt_OutPut);
            this.Controls.Add(this.VehicleGridView);
            this.Name = "VehicleManagementForm";
            this.Text = "VehicleManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.VehicleGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView VehicleGridView;
        private System.Windows.Forms.TextBox txt_OutPut;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleRegistration;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleRequireService;
        private System.Windows.Forms.DataGridViewButtonColumn AddFuel;
        private System.Windows.Forms.DataGridViewButtonColumn AddRental;
        private System.Windows.Forms.DataGridViewButtonColumn AddService;
    }
}