using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Developer_Test
{
    // Time spent: 12 hours
    class GUI : Form
    {
        private Panel mainPanel;
        private Button ReturnRentalButton;
        private Panel rentalPanel;
        private TextBox BookingNumberInput;
        private Button newRentalButton;
        private DataGridView rentalLog;
        private Label label1;
        private ComboBox CarCategoryInput;
        private TextBox CustomerBirthDateInput;
        private TextBox MilageInput;
        private TextBox RentalDateInput;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button RentalBackButton;
        private Button RentalConfirmButton;
        private Panel returnPanel;
        private Label priceLabel;
        private Label label8;
        private ComboBox ReturnBookingNumberInput;
        private TextBox ReturnDateInput;
        private Label label10;
        private Label label9;
        private Button ReturnBackButton;
        private Button ReturnConfimButton;
        private Label label11;
        private TextBox ReturnMilageInput;
        private Model model;

        public static void Main()
        {
            new GUI();
        }

        public GUI()
        {
            model = new Model();
            InitializeComponent();
            this.CarCategoryInput.Items.AddRange(Enum.GetValues(typeof(CarCategories)).Cast<object>().ToArray());
            BackToMain(null);
            ShowDialog();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.newRentalButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnRentalButton = new System.Windows.Forms.Button();
            this.rentalLog = new System.Windows.Forms.DataGridView();
            this.rentalPanel = new System.Windows.Forms.Panel();
            this.RentalBackButton = new System.Windows.Forms.Button();
            this.RentalConfirmButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CarCategoryInput = new System.Windows.Forms.ComboBox();
            this.CustomerBirthDateInput = new System.Windows.Forms.TextBox();
            this.MilageInput = new System.Windows.Forms.TextBox();
            this.RentalDateInput = new System.Windows.Forms.TextBox();
            this.BookingNumberInput = new System.Windows.Forms.TextBox();
            this.returnPanel = new System.Windows.Forms.Panel();
            this.ReturnBackButton = new System.Windows.Forms.Button();
            this.ReturnConfimButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ReturnMilageInput = new System.Windows.Forms.TextBox();
            this.ReturnDateInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ReturnBookingNumberInput = new System.Windows.Forms.ComboBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentalLog)).BeginInit();
            this.rentalPanel.SuspendLayout();
            this.returnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newRentalButton
            // 
            this.newRentalButton.Location = new System.Drawing.Point(376, 388);
            this.newRentalButton.Name = "newRentalButton";
            this.newRentalButton.Size = new System.Drawing.Size(75, 23);
            this.newRentalButton.TabIndex = 0;
            this.newRentalButton.Text = "New Rental";
            this.newRentalButton.UseVisualStyleBackColor = true;
            this.newRentalButton.Click += new System.EventHandler(this.NewRentalButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.ReturnRentalButton);
            this.mainPanel.Controls.Add(this.newRentalButton);
            this.mainPanel.Controls.Add(this.rentalLog);
            this.mainPanel.Location = new System.Drawing.Point(57, 56);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(615, 424);
            this.mainPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rentals";
            // 
            // ReturnRentalButton
            // 
            this.ReturnRentalButton.Location = new System.Drawing.Point(102, 388);
            this.ReturnRentalButton.Name = "ReturnRentalButton";
            this.ReturnRentalButton.Size = new System.Drawing.Size(80, 23);
            this.ReturnRentalButton.TabIndex = 1;
            this.ReturnRentalButton.Text = "Return rental";
            this.ReturnRentalButton.UseVisualStyleBackColor = true;
            this.ReturnRentalButton.Click += new System.EventHandler(this.ReturnRentalButton_Click);
            // 
            // rentalLog
            // 
            this.rentalLog.AllowUserToAddRows = false;
            this.rentalLog.AllowUserToDeleteRows = false;
            this.rentalLog.AllowUserToResizeRows = false;
            this.rentalLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rentalLog.DefaultCellStyle = dataGridViewCellStyle1;
            this.rentalLog.Location = new System.Drawing.Point(0, 40);
            this.rentalLog.MultiSelect = false;
            this.rentalLog.Name = "rentalLog";
            this.rentalLog.ReadOnly = true;
            this.rentalLog.RowHeadersVisible = false;
            this.rentalLog.RowTemplate.ReadOnly = true;
            this.rentalLog.ShowCellToolTips = false;
            this.rentalLog.ShowEditingIcon = false;
            this.rentalLog.Size = new System.Drawing.Size(615, 328);
            this.rentalLog.TabIndex = 2;
            // 
            // rentalPanel
            // 
            this.rentalPanel.Controls.Add(this.RentalBackButton);
            this.rentalPanel.Controls.Add(this.RentalConfirmButton);
            this.rentalPanel.Controls.Add(this.label7);
            this.rentalPanel.Controls.Add(this.label6);
            this.rentalPanel.Controls.Add(this.label5);
            this.rentalPanel.Controls.Add(this.label4);
            this.rentalPanel.Controls.Add(this.label3);
            this.rentalPanel.Controls.Add(this.label2);
            this.rentalPanel.Controls.Add(this.CarCategoryInput);
            this.rentalPanel.Controls.Add(this.CustomerBirthDateInput);
            this.rentalPanel.Controls.Add(this.MilageInput);
            this.rentalPanel.Controls.Add(this.RentalDateInput);
            this.rentalPanel.Controls.Add(this.BookingNumberInput);
            this.rentalPanel.Location = new System.Drawing.Point(57, 56);
            this.rentalPanel.Name = "rentalPanel";
            this.rentalPanel.Size = new System.Drawing.Size(615, 424);
            this.rentalPanel.TabIndex = 2;
            this.rentalPanel.Visible = false;
            // 
            // RentalBackButton
            // 
            this.RentalBackButton.Location = new System.Drawing.Point(376, 388);
            this.RentalBackButton.Name = "RentalBackButton";
            this.RentalBackButton.Size = new System.Drawing.Size(75, 23);
            this.RentalBackButton.TabIndex = 12;
            this.RentalBackButton.Text = "Back";
            this.RentalBackButton.UseVisualStyleBackColor = true;
            this.RentalBackButton.Click += new System.EventHandler(this.RentalBackButton_Click);
            // 
            // RentalConfirmButton
            // 
            this.RentalConfirmButton.Location = new System.Drawing.Point(102, 388);
            this.RentalConfirmButton.Name = "RentalConfirmButton";
            this.RentalConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.RentalConfirmButton.TabIndex = 11;
            this.RentalConfirmButton.Text = "Confirm";
            this.RentalConfirmButton.UseVisualStyleBackColor = true;
            this.RentalConfirmButton.Click += new System.EventHandler(this.RentalConfirmButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rental date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Current Milage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "CarCategory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer date of birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Booking number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Rental";
            // 
            // CarCategoryInput
            // 
            this.CarCategoryInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CarCategoryInput.FormattingEnabled = true;
            this.CarCategoryInput.Location = new System.Drawing.Point(452, 88);
            this.CarCategoryInput.Name = "CarCategoryInput";
            this.CarCategoryInput.Size = new System.Drawing.Size(121, 21);
            this.CarCategoryInput.TabIndex = 4;
            // 
            // CustomerBirthDateInput
            // 
            this.CustomerBirthDateInput.Location = new System.Drawing.Point(266, 88);
            this.CustomerBirthDateInput.Name = "CustomerBirthDateInput";
            this.CustomerBirthDateInput.Size = new System.Drawing.Size(124, 20);
            this.CustomerBirthDateInput.TabIndex = 3;
            // 
            // MilageInput
            // 
            this.MilageInput.Location = new System.Drawing.Point(273, 200);
            this.MilageInput.Name = "MilageInput";
            this.MilageInput.Size = new System.Drawing.Size(117, 20);
            this.MilageInput.TabIndex = 2;
            // 
            // RentalDateInput
            // 
            this.RentalDateInput.Location = new System.Drawing.Point(40, 200);
            this.RentalDateInput.Name = "RentalDateInput";
            this.RentalDateInput.Size = new System.Drawing.Size(124, 20);
            this.RentalDateInput.TabIndex = 1;
            // 
            // BookingNumberInput
            // 
            this.BookingNumberInput.Location = new System.Drawing.Point(40, 88);
            this.BookingNumberInput.Name = "BookingNumberInput";
            this.BookingNumberInput.Size = new System.Drawing.Size(124, 20);
            this.BookingNumberInput.TabIndex = 0;
            // 
            // returnPanel
            // 
            this.returnPanel.Controls.Add(this.ReturnBackButton);
            this.returnPanel.Controls.Add(this.ReturnConfimButton);
            this.returnPanel.Controls.Add(this.label11);
            this.returnPanel.Controls.Add(this.ReturnMilageInput);
            this.returnPanel.Controls.Add(this.ReturnDateInput);
            this.returnPanel.Controls.Add(this.label10);
            this.returnPanel.Controls.Add(this.label9);
            this.returnPanel.Controls.Add(this.priceLabel);
            this.returnPanel.Controls.Add(this.label8);
            this.returnPanel.Controls.Add(this.ReturnBookingNumberInput);
            this.returnPanel.Location = new System.Drawing.Point(57, 56);
            this.returnPanel.Name = "returnPanel";
            this.returnPanel.Size = new System.Drawing.Size(615, 424);
            this.returnPanel.TabIndex = 13;
            this.returnPanel.Visible = false;
            // 
            // ReturnBackButton
            // 
            this.ReturnBackButton.Location = new System.Drawing.Point(376, 388);
            this.ReturnBackButton.Name = "ReturnBackButton";
            this.ReturnBackButton.Size = new System.Drawing.Size(75, 23);
            this.ReturnBackButton.TabIndex = 14;
            this.ReturnBackButton.Text = "Back";
            this.ReturnBackButton.UseVisualStyleBackColor = true;
            this.ReturnBackButton.Click += new System.EventHandler(this.ReturnBackButton_Click);
            // 
            // ReturnConfimButton
            // 
            this.ReturnConfimButton.Location = new System.Drawing.Point(102, 388);
            this.ReturnConfimButton.Name = "ReturnConfimButton";
            this.ReturnConfimButton.Size = new System.Drawing.Size(92, 23);
            this.ReturnConfimButton.TabIndex = 13;
            this.ReturnConfimButton.Text = "Confirm return";
            this.ReturnConfimButton.UseVisualStyleBackColor = true;
            this.ReturnConfimButton.Click += new System.EventHandler(this.ReturnConfimButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Milage on return";
            // 
            // ReturnMilageInput
            // 
            this.ReturnMilageInput.Location = new System.Drawing.Point(229, 110);
            this.ReturnMilageInput.Name = "ReturnMilageInput";
            this.ReturnMilageInput.Size = new System.Drawing.Size(100, 20);
            this.ReturnMilageInput.TabIndex = 11;
            // 
            // ReturnDateInput
            // 
            this.ReturnDateInput.Location = new System.Drawing.Point(376, 114);
            this.ReturnDateInput.Name = "ReturnDateInput";
            this.ReturnDateInput.Size = new System.Drawing.Size(138, 20);
            this.ReturnDateInput.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Return date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Booking number";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(256, 238);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(0, 16);
            this.priceLabel.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(270, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Return Rental";
            // 
            // ReturnBookingNumberInput
            // 
            this.ReturnBookingNumberInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReturnBookingNumberInput.FormattingEnabled = true;
            this.ReturnBookingNumberInput.Location = new System.Drawing.Point(43, 114);
            this.ReturnBookingNumberInput.Name = "ReturnBookingNumberInput";
            this.ReturnBookingNumberInput.Size = new System.Drawing.Size(121, 21);
            this.ReturnBookingNumberInput.TabIndex = 5;
            this.ReturnBookingNumberInput.SelectedIndexChanged += new System.EventHandler(this.ReturnBookingNumberInput_SelectedIndexChanged);
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(746, 528);
            this.Controls.Add(this.rentalPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.returnPanel);
            this.Name = "GUI";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentalLog)).EndInit();
            this.rentalPanel.ResumeLayout(false);
            this.rentalPanel.PerformLayout();
            this.returnPanel.ResumeLayout(false);
            this.returnPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void BackToMain(Panel currentPanel)
        {
            if (currentPanel != null)
                currentPanel.Visible = false;
            this.mainPanel.Visible = true;
            this.rentalLog.DataSource = model.GetAllRentals();
        }

        private void NewRentalButton_Click(object sender, EventArgs e)
        {
            ResetRentalInputs();

            this.mainPanel.Visible = false;
            this.rentalPanel.Visible = true;

            
        }

        private void ReturnRentalButton_Click(object sender, EventArgs e)
        {
            ResetReturnInputs();

            mainPanel.Visible = false;
            returnPanel.Visible = true;
        }

        private void RentalConfirmButton_Click(object sender, EventArgs e)
        {
            int validationError = model.ValidateRentalData(BookingNumberInput.Text, CustomerBirthDateInput.Text, 
                CarCategoryInput.Text, RentalDateInput.Text, MilageInput.Text);
            this.BookingNumberInput.BackColor = Color.White;
            this.CustomerBirthDateInput.BackColor = Color.White;
            this.RentalDateInput.BackColor = Color.White;
            this.MilageInput.BackColor = Color.White;

            switch (validationError)
            {
                case 0:
                    model.SaveRental(BookingNumberInput.Text, CustomerBirthDateInput.Text,
                CarCategoryInput.Text, RentalDateInput.Text, MilageInput.Text);

                    BackToMain(rentalPanel);
                    break;
                case 1:
                    this.BookingNumberInput.Focus();
                    this.BookingNumberInput.BackColor = Color.Red;
                    break;
                case 2:
                    this.CustomerBirthDateInput.Focus();
                    this.CustomerBirthDateInput.BackColor = Color.Red;
                    break;
                case 3:
                    MessageBox.Show("Invalid car category");
                    break;
                case 4:
                    this.RentalDateInput.Focus();
                    this.RentalDateInput.BackColor = Color.Red;
                    break;
                case 5:
                    this.MilageInput.Focus();
                    this.MilageInput.BackColor = Color.Red;
                    break;
            }
        }

        private void RentalBackButton_Click(object sender, EventArgs e)
        {
            BackToMain(rentalPanel);
        }

        private void ResetRentalInputs()
        {
            this.BookingNumberInput.Text = string.Empty;
            this.CustomerBirthDateInput.Text = (DateTime.Now.Date.AddYears(-20)).ToString();
            this.CarCategoryInput.SelectedIndex = 0;
            this.MilageInput.Text = string.Empty;
            this.RentalDateInput.Text = DateTime.Now.ToString();

            this.BookingNumberInput.BackColor = Color.White;
            this.CustomerBirthDateInput.BackColor = Color.White;
            this.RentalDateInput.BackColor = Color.White;
            this.MilageInput.BackColor = Color.White;
        }

        private void ReturnConfimButton_Click(object sender, EventArgs e)
        {
            int validationError = model.ValidateReturnData(this.ReturnBookingNumberInput.Text, this.ReturnMilageInput.Text, this.ReturnDateInput.Text);
            this.ReturnMilageInput.BackColor = Color.White;
            this.ReturnDateInput.BackColor = Color.White;

            switch (validationError)
            {
                case 0:
                    double price = model.CalculatePrice(this.BookingNumberInput.Text, this.ReturnDateInput.Text, this.ReturnMilageInput.Text);
                    model.SaveReturnDate(this.ReturnBookingNumberInput.Text, this.ReturnDateInput.Text);
                    ResetReturnInputs();
                    this.priceLabel.Text = "Cost: " + price.ToString();
                    break;
                case 1:
                    MessageBox.Show("Invalid booking number");
                    break;
                case 2:
                    this.ReturnMilageInput.Focus();
                    this.ReturnMilageInput.BackColor = Color.Red;
                    break;
                case 3:
                    this.ReturnDateInput.Focus();
                    this.ReturnDateInput.BackColor = Color.Red;
                    break;
            }
        }

        private void ReturnBackButton_Click(object sender, EventArgs e)
        {
            BackToMain(returnPanel);
        }

        private void ReturnBookingNumberInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnConfimButton.Enabled = ReturnBookingNumberInput.SelectedIndex != -1;
           this.priceLabel.Text = string.Empty;
        }

        private void ResetReturnInputs()
        {
            this.ReturnBookingNumberInput.Items.Clear();
            this.ReturnBookingNumberInput.Items.AddRange(model.GetBookingNumberForActiveRentalsAsArray());
            this.ReturnBookingNumberInput.SelectedIndex = -1;
            this.ReturnDateInput.Text = DateTime.Now.ToString();
            this.ReturnMilageInput.Text = string.Empty;
            this.priceLabel.Text = string.Empty;
            ReturnConfimButton.Enabled = false;

            this.ReturnMilageInput.BackColor = Color.White;
            this.ReturnDateInput.BackColor = Color.White;
        }
    }
}
