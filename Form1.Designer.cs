namespace LabelPrinter
{
    partial class Form1
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
            this.comboBox_Printer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Resolution = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_Print = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.TabPage();
            this.textBox_Label = new System.Windows.Forms.TextBox();
            this.Product = new System.Windows.Forms.TabPage();
            this.textBox_BarCode = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_ShortDescription = new System.Windows.Forms.TextBox();
            this.textBox_ProductName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Customer = new System.Windows.Forms.TabPage();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_CustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Label.SuspendLayout();
            this.Product.SuspendLayout();
            this.Customer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Printer
            // 
            this.comboBox_Printer.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox_Printer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Printer.FormattingEnabled = true;
            this.comboBox_Printer.Location = new System.Drawing.Point(0, 0);
            this.comboBox_Printer.Name = "comboBox_Printer";
            this.comboBox_Printer.Size = new System.Drawing.Size(458, 21);
            this.comboBox_Printer.TabIndex = 0;
            this.comboBox_Printer.SelectedIndexChanged += new System.EventHandler(this.comboBox_Printer_SelectedIndexChanged);
            this.comboBox_Printer.SelectedValueChanged += new System.EventHandler(this.comboBox_Printer_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Resolution);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.button_Print);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 31);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Resolution
            // 
            this.textBox_Resolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Resolution.Location = new System.Drawing.Point(7, 6);
            this.textBox_Resolution.Name = "textBox_Resolution";
            this.textBox_Resolution.ReadOnly = true;
            this.textBox_Resolution.Size = new System.Drawing.Size(100, 13);
            this.textBox_Resolution.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(321, 6);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_Print
            // 
            this.button_Print.Location = new System.Drawing.Point(371, 5);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(75, 23);
            this.button_Print.TabIndex = 0;
            this.button_Print.Text = "Print";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click_1);
            // 
            // Label
            // 
            this.Label.Controls.Add(this.textBox_Label);
            this.Label.Location = new System.Drawing.Point(4, 22);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(450, 145);
            this.Label.TabIndex = 2;
            this.Label.Text = "Label";
            this.Label.UseVisualStyleBackColor = true;
            // 
            // textBox_Label
            // 
            this.textBox_Label.AcceptsReturn = true;
            this.textBox_Label.Location = new System.Drawing.Point(3, 3);
            this.textBox_Label.Multiline = true;
            this.textBox_Label.Name = "textBox_Label";
            this.textBox_Label.Size = new System.Drawing.Size(444, 139);
            this.textBox_Label.TabIndex = 0;
            // 
            // Product
            // 
            this.Product.Controls.Add(this.textBox_BarCode);
            this.Product.Controls.Add(this.textBox_Price);
            this.Product.Controls.Add(this.textBox_ShortDescription);
            this.Product.Controls.Add(this.textBox_ProductName);
            this.Product.Controls.Add(this.label6);
            this.Product.Controls.Add(this.label5);
            this.Product.Controls.Add(this.label4);
            this.Product.Controls.Add(this.label3);
            this.Product.Location = new System.Drawing.Point(4, 22);
            this.Product.Name = "Product";
            this.Product.Padding = new System.Windows.Forms.Padding(3);
            this.Product.Size = new System.Drawing.Size(450, 145);
            this.Product.TabIndex = 1;
            this.Product.Text = "Product Label";
            this.Product.UseVisualStyleBackColor = true;
            // 
            // textBox_BarCode
            // 
            this.textBox_BarCode.Location = new System.Drawing.Point(97, 58);
            this.textBox_BarCode.Name = "textBox_BarCode";
            this.textBox_BarCode.Size = new System.Drawing.Size(340, 20);
            this.textBox_BarCode.TabIndex = 5;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(97, 84);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(100, 20);
            this.textBox_Price.TabIndex = 6;
            // 
            // textBox_ShortDescription
            // 
            this.textBox_ShortDescription.Location = new System.Drawing.Point(97, 32);
            this.textBox_ShortDescription.Name = "textBox_ShortDescription";
            this.textBox_ShortDescription.Size = new System.Drawing.Size(340, 20);
            this.textBox_ShortDescription.TabIndex = 4;
            // 
            // textBox_ProductName
            // 
            this.textBox_ProductName.Location = new System.Drawing.Point(97, 6);
            this.textBox_ProductName.Name = "textBox_ProductName";
            this.textBox_ProductName.Size = new System.Drawing.Size(340, 20);
            this.textBox_ProductName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bar Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Short Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Product Name";
            // 
            // Customer
            // 
            this.Customer.Controls.Add(this.textBox_Phone);
            this.Customer.Controls.Add(this.textBox_CustomerName);
            this.Customer.Controls.Add(this.label2);
            this.Customer.Controls.Add(this.label1);
            this.Customer.Location = new System.Drawing.Point(4, 22);
            this.Customer.Name = "Customer";
            this.Customer.Padding = new System.Windows.Forms.Padding(3);
            this.Customer.Size = new System.Drawing.Size(450, 145);
            this.Customer.TabIndex = 0;
            this.Customer.Text = "Customer Label";
            this.Customer.UseVisualStyleBackColor = true;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(96, 32);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(346, 20);
            this.textBox_Phone.TabIndex = 3;
            // 
            // textBox_CustomerName
            // 
            this.textBox_CustomerName.Location = new System.Drawing.Point(96, 6);
            this.textBox_CustomerName.Name = "textBox_CustomerName";
            this.textBox_CustomerName.Size = new System.Drawing.Size(346, 20);
            this.textBox_CustomerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Customer);
            this.tabControl1.Controls.Add(this.Product);
            this.tabControl1.Controls.Add(this.Label);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 171);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AcceptButton = this.button_Print;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 223);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox_Printer);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Label Printer CODE128";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Label.ResumeLayout(false);
            this.Label.PerformLayout();
            this.Product.ResumeLayout(false);
            this.Product.PerformLayout();
            this.Customer.ResumeLayout(false);
            this.Customer.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Printer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox_Resolution;
        private System.Windows.Forms.TabPage Label;
        private System.Windows.Forms.TextBox textBox_Label;
        private System.Windows.Forms.TabPage Product;
        private System.Windows.Forms.TextBox textBox_BarCode;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.TextBox textBox_ShortDescription;
        private System.Windows.Forms.TextBox textBox_ProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage Customer;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_CustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

