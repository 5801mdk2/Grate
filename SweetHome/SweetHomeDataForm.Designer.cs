using System.ComponentModel;
using System.Windows.Forms;

namespace SweetHome
{
    partial class SweetHomeDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.WidthFoundation = new System.Windows.Forms.TextBox();
            this.WidthFoundationPlate = new System.Windows.Forms.TextBox();
            this.HeightFoundationPlate = new System.Windows.Forms.TextBox();
            this.HeightFurnaceBlock = new System.Windows.Forms.TextBox();
            this.LengthFurnaceBlock = new System.Windows.Forms.TextBox();
            this.HeightFoundation = new System.Windows.Forms.TextBox();
            this.LengthFoundation = new System.Windows.Forms.TextBox();
            this.LengthFoundationPlate = new System.Windows.Forms.TextBox();
            this.WidthFurnaceBlock = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.YesRadioButton = new System.Windows.Forms.RadioButton();
            this.NoRadioButton = new System.Windows.Forms.RadioButton();
            this.PipeLalbel = new System.Windows.Forms.Label();
            this.PipeGroupBox = new System.Windows.Forms.GroupBox();
            this.HeightMantel = new System.Windows.Forms.TextBox();
            this.HeightPipe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.PipeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(86, 531);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Построить";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // WidthFoundation
            // 
            this.WidthFoundation.Location = new System.Drawing.Point(6, 51);
            this.WidthFoundation.Name = "WidthFoundation";
            this.WidthFoundation.Size = new System.Drawing.Size(100, 20);
            this.WidthFoundation.TabIndex = 2;
            this.WidthFoundation.Leave += new System.EventHandler(this.WidthFoundation_leave);
            // 
            // WidthFoundationPlate
            // 
            this.WidthFoundationPlate.Location = new System.Drawing.Point(6, 50);
            this.WidthFoundationPlate.Name = "WidthFoundationPlate";
            this.WidthFoundationPlate.Size = new System.Drawing.Size(100, 20);
            this.WidthFoundationPlate.TabIndex = 5;
            this.WidthFoundationPlate.Leave += new System.EventHandler(this.WidthFoundationPlate_leave);
            // 
            // HeightFoundationPlate
            // 
            this.HeightFoundationPlate.Location = new System.Drawing.Point(6, 24);
            this.HeightFoundationPlate.Name = "HeightFoundationPlate";
            this.HeightFoundationPlate.Size = new System.Drawing.Size(100, 20);
            this.HeightFoundationPlate.TabIndex = 4;
            this.HeightFoundationPlate.Leave += new System.EventHandler(this.HeightFoundationPlate_leave);
            // 
            // HeightFurnaceBlock
            // 
            this.HeightFurnaceBlock.Location = new System.Drawing.Point(6, 26);
            this.HeightFurnaceBlock.Name = "HeightFurnaceBlock";
            this.HeightFurnaceBlock.Size = new System.Drawing.Size(100, 20);
            this.HeightFurnaceBlock.TabIndex = 7;
            this.HeightFurnaceBlock.Leave += new System.EventHandler(this.HeightFurnaceBlock_leave);
            // 
            // LengthFurnaceBlock
            // 
            this.LengthFurnaceBlock.Location = new System.Drawing.Point(6, 80);
            this.LengthFurnaceBlock.Name = "LengthFurnaceBlock";
            this.LengthFurnaceBlock.Size = new System.Drawing.Size(100, 20);
            this.LengthFurnaceBlock.TabIndex = 9;
            this.LengthFurnaceBlock.Leave += new System.EventHandler(this.LengthFurnaceBlock_leave);
            // 
            // HeightFoundation
            // 
            this.HeightFoundation.Location = new System.Drawing.Point(6, 22);
            this.HeightFoundation.Name = "HeightFoundation";
            this.HeightFoundation.Size = new System.Drawing.Size(100, 20);
            this.HeightFoundation.TabIndex = 1;
            this.HeightFoundation.Leave += new System.EventHandler(this.HeightFoundation_leave);
            // 
            // LengthFoundation
            // 
            this.LengthFoundation.Location = new System.Drawing.Point(6, 77);
            this.LengthFoundation.Name = "LengthFoundation";
            this.LengthFoundation.Size = new System.Drawing.Size(100, 20);
            this.LengthFoundation.TabIndex = 3;
            this.LengthFoundation.Leave += new System.EventHandler(this.LengthFoundation_leave);
            // 
            // LengthFoundationPlate
            // 
            this.LengthFoundationPlate.Location = new System.Drawing.Point(6, 76);
            this.LengthFoundationPlate.Name = "LengthFoundationPlate";
            this.LengthFoundationPlate.Size = new System.Drawing.Size(100, 20);
            this.LengthFoundationPlate.TabIndex = 6;
            this.LengthFoundationPlate.Leave += new System.EventHandler(this.LengthFoundationPlate_leave);
            // 
            // WidthFurnaceBlock
            // 
            this.WidthFurnaceBlock.Location = new System.Drawing.Point(6, 52);
            this.WidthFurnaceBlock.Name = "WidthFurnaceBlock";
            this.WidthFurnaceBlock.Size = new System.Drawing.Size(100, 20);
            this.WidthFurnaceBlock.TabIndex = 8;
            this.WidthFurnaceBlock.Leave += new System.EventHandler(this.WidthFurnaceBlock_leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WidthFoundation);
            this.groupBox1.Controls.Add(this.LengthFoundation);
            this.groupBox1.Controls.Add(this.HeightFoundation);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры фундамента";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Высота [15-20]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина [60-80]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Длина   [45-60]";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.HeightFoundationPlate);
            this.groupBox2.Controls.Add(this.LengthFoundationPlate);
            this.groupBox2.Controls.Add(this.WidthFoundationPlate);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 104);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры надфундаментной плиты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Высота [7,5-10]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ширина [80-100]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Длина [65-80]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.LengthFurnaceBlock);
            this.groupBox3.Controls.Add(this.HeightFurnaceBlock);
            this.groupBox3.Controls.Add(this.WidthFurnaceBlock);
            this.groupBox3.Location = new System.Drawing.Point(12, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 120);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры печного блока";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(113, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Длина [40-55]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ширина [50-70]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Высота [40-50]";
            // 
            // YesRadioButton
            // 
            this.YesRadioButton.AutoSize = true;
            this.YesRadioButton.Location = new System.Drawing.Point(33, 382);
            this.YesRadioButton.Name = "YesRadioButton";
            this.YesRadioButton.Size = new System.Drawing.Size(40, 17);
            this.YesRadioButton.TabIndex = 10;
            this.YesRadioButton.TabStop = true;
            this.YesRadioButton.Text = "Да";
            this.YesRadioButton.UseVisualStyleBackColor = true;
            this.YesRadioButton.CheckedChanged += new System.EventHandler(this.YesRadioButton_CheckedChanged);
            // 
            // NoRadioButton
            // 
            this.NoRadioButton.AutoSize = true;
            this.NoRadioButton.Location = new System.Drawing.Point(167, 382);
            this.NoRadioButton.Name = "NoRadioButton";
            this.NoRadioButton.Size = new System.Drawing.Size(44, 17);
            this.NoRadioButton.TabIndex = 11;
            this.NoRadioButton.TabStop = true;
            this.NoRadioButton.Text = "Нет";
            this.NoRadioButton.UseVisualStyleBackColor = true;
            this.NoRadioButton.CheckedChanged += new System.EventHandler(this.NoRadioButton_CheckedChanged);
            // 
            // PipeLalbel
            // 
            this.PipeLalbel.AutoSize = true;
            this.PipeLalbel.Location = new System.Drawing.Point(72, 366);
            this.PipeLalbel.Name = "PipeLalbel";
            this.PipeLalbel.Size = new System.Drawing.Size(97, 13);
            this.PipeLalbel.TabIndex = 4;
            this.PipeLalbel.Text = "Построить трубу?";
            // 
            // PipeGroupBox
            // 
            this.PipeGroupBox.Controls.Add(this.HeightMantel);
            this.PipeGroupBox.Controls.Add(this.HeightPipe);
            this.PipeGroupBox.Controls.Add(this.label11);
            this.PipeGroupBox.Controls.Add(this.label4);
            this.PipeGroupBox.Location = new System.Drawing.Point(18, 405);
            this.PipeGroupBox.Name = "PipeGroupBox";
            this.PipeGroupBox.Size = new System.Drawing.Size(213, 112);
            this.PipeGroupBox.TabIndex = 4;
            this.PipeGroupBox.TabStop = false;
            this.PipeGroupBox.Text = "Параметры трубы";
            // 
            // HeightMantel
            // 
            this.HeightMantel.Location = new System.Drawing.Point(6, 74);
            this.HeightMantel.Name = "HeightMantel";
            this.HeightMantel.Size = new System.Drawing.Size(100, 20);
            this.HeightMantel.TabIndex = 13;
            this.HeightMantel.Leave += new System.EventHandler(this.HeightMantel_leave);
            // 
            // HeightPipe
            // 
            this.HeightPipe.Location = new System.Drawing.Point(6, 31);
            this.HeightPipe.Name = "HeightPipe";
            this.HeightPipe.Size = new System.Drawing.Size(100, 20);
            this.HeightPipe.TabIndex = 12;
            this.HeightPipe.Leave += new System.EventHandler(this.HeightPipe_leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(115, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 26);
            this.label11.TabIndex = 1;
            this.label11.Text = "Высота огранки\r\n[15-30]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Высота трубы\r\n[80-100]";
            // 
            // SweetHomeDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 566);
            this.Controls.Add(this.PipeGroupBox);
            this.Controls.Add(this.PipeLalbel);
            this.Controls.Add(this.NoRadioButton);
            this.Controls.Add(this.YesRadioButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonCreate);
            this.Name = "SweetHomeDataForm";
            this.Text = "Sweet Home";
            this.Load += new System.EventHandler(this.SweetHomeDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.PipeGroupBox.ResumeLayout(false);
            this.PipeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonCreate;
        private TextBox WidthFoundation;
        private TextBox WidthFoundationPlate;
        private TextBox HeightFoundationPlate;
        private TextBox HeightFurnaceBlock;
        private TextBox LengthFurnaceBlock;
        private TextBox HeightFoundation;
        private TextBox LengthFoundation;
        private TextBox LengthFoundationPlate;
        private TextBox WidthFurnaceBlock;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label10;
        private RadioButton YesRadioButton;
        private RadioButton NoRadioButton;
        private Label PipeLalbel;
        private GroupBox PipeGroupBox;
        private TextBox HeightMantel;
        private TextBox HeightPipe;
        private Label label11;
        private Label label4;
    }
}

