namespace Car_Rental_Management_System.Forms
{
    partial class VehiclesForm
    {
        private Label lblHeader;
        private DataGridView dgvVehicles;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TextBox txtSearch;

        private void InitializeComponent()
        {
            lblHeader = new Label();
            dgvVehicles = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();

            // Header
            lblHeader.Text = "Vehicle Management";
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.Location = new System.Drawing.Point(20, 15);
            lblHeader.AutoSize = true;

            // Search
            txtSearch.Location = new System.Drawing.Point(25, 70);
            txtSearch.Width = 350;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtSearch.PlaceholderText = "Search vehicle...";

            // DataGridView
            dgvVehicles.Location = new System.Drawing.Point(25, 110);
            dgvVehicles.Size = new System.Drawing.Size(800, 400);
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Buttons
            btnAdd.Text = "Add";
            btnAdd.Location = new System.Drawing.Point(850, 110);
            btnAdd.Size = new System.Drawing.Size(120, 40);

            btnEdit.Text = "Edit";
            btnEdit.Location = new System.Drawing.Point(850, 160);
            btnEdit.Size = new System.Drawing.Size(120, 40);

            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(850, 210);
            btnDelete.Size = new System.Drawing.Size(120, 40);

            // VehiclesForm
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(1000, 550);

            this.Controls.Add(lblHeader);
            this.Controls.Add(txtSearch);
            this.Controls.Add(dgvVehicles);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
        }
    }
}
