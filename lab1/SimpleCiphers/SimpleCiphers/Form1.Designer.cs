namespace SimpleCiphers
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbM = new System.Windows.Forms.TextBox();
            this.tbC = new System.Windows.Forms.TextBox();
            this.lbM = new System.Windows.Forms.Label();
            this.lbC = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.cbCipherName = new System.Windows.Forms.ComboBox();
            this.lblCipherName = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.rbEncrypt = new System.Windows.Forms.RadioButton();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.btnDo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbM
            // 
            this.tbM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbM.Location = new System.Drawing.Point(87, 367);
            this.tbM.Multiline = true;
            this.tbM.Name = "tbM";
            this.tbM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbM.Size = new System.Drawing.Size(1400, 301);
            this.tbM.TabIndex = 2;
            this.tbM.TextChanged += new System.EventHandler(this.tbM_TextChanged);
            // 
            // tbC
            // 
            this.tbC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbC.Location = new System.Drawing.Point(87, 749);
            this.tbC.Multiline = true;
            this.tbC.Name = "tbC";
            this.tbC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbC.Size = new System.Drawing.Size(1400, 301);
            this.tbC.TabIndex = 4;
            // 
            // lbM
            // 
            this.lbM.AutoSize = true;
            this.lbM.BackColor = System.Drawing.Color.Transparent;
            this.lbM.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbM.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbM.Location = new System.Drawing.Point(87, 319);
            this.lbM.Name = "lbM";
            this.lbM.Size = new System.Drawing.Size(175, 45);
            this.lbM.TabIndex = 2;
            this.lbM.Text = "File text:";
            // 
            // lbC
            // 
            this.lbC.AutoSize = true;
            this.lbC.BackColor = System.Drawing.Color.Transparent;
            this.lbC.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbC.Location = new System.Drawing.Point(87, 701);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(222, 45);
            this.lbC.TabIndex = 3;
            this.lbC.Text = "Result text:";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenFile.Location = new System.Drawing.Point(1261, 675);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(226, 62);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = " \"Text files(*.txt)|*.txt|All files(*.*)|*.*\"";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = " \"Text files(*.txt)|*.txt|All files(*.*)|*.*\"";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveFile.Location = new System.Drawing.Point(1021, 1055);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(226, 62);
            this.btnSaveFile.TabIndex = 5;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // cbCipherName
            // 
            this.cbCipherName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbCipherName.FormattingEnabled = true;
            this.cbCipherName.Items.AddRange(new object[] {
            "Столбцовый метод(us)",
            "Алгоритм Виженера(ru) (прогрессивный) "});
            this.cbCipherName.Location = new System.Drawing.Point(95, 84);
            this.cbCipherName.Name = "cbCipherName";
            this.cbCipherName.Size = new System.Drawing.Size(605, 45);
            this.cbCipherName.TabIndex = 0;
            this.cbCipherName.Text = "Choose algorithm";
            this.cbCipherName.DropDownClosed += new System.EventHandler(this.cbCipherName_DropDownClosed);
            // 
            // lblCipherName
            // 
            this.lblCipherName.AutoSize = true;
            this.lblCipherName.BackColor = System.Drawing.Color.Transparent;
            this.lblCipherName.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCipherName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCipherName.Location = new System.Drawing.Point(95, 36);
            this.lblCipherName.Name = "lblCipherName";
            this.lblCipherName.Size = new System.Drawing.Size(325, 45);
            this.lblCipherName.TabIndex = 7;
            this.lblCipherName.Text = "Cipher Algorithm:";
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Arial Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbKey.Location = new System.Drawing.Point(200, 177);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(500, 60);
            this.tbKey.TabIndex = 1;
            this.tbKey.TextChanged += new System.EventHandler(this.tbKey_TextChanged);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.BackColor = System.Drawing.Color.Transparent;
            this.lblKey.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKey.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKey.Location = new System.Drawing.Point(87, 177);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(98, 45);
            this.lblKey.TabIndex = 9;
            this.lblKey.Text = "Key:";
            // 
            // rbEncrypt
            // 
            this.rbEncrypt.AutoSize = true;
            this.rbEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.rbEncrypt.Checked = true;
            this.rbEncrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbEncrypt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbEncrypt.Location = new System.Drawing.Point(65, 39);
            this.rbEncrypt.Name = "rbEncrypt";
            this.rbEncrypt.Size = new System.Drawing.Size(233, 41);
            this.rbEncrypt.TabIndex = 10;
            this.rbEncrypt.TabStop = true;
            this.rbEncrypt.Text = "Encrypt text";
            this.rbEncrypt.UseVisualStyleBackColor = false;
            this.rbEncrypt.Click += new System.EventHandler(this.rbEncrypt_Click);
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.BackColor = System.Drawing.Color.Transparent;
            this.rbDecrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbDecrypt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbDecrypt.Location = new System.Drawing.Point(65, 110);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(234, 41);
            this.rbDecrypt.TabIndex = 11;
            this.rbDecrypt.Text = "Decrypt text";
            this.rbDecrypt.UseVisualStyleBackColor = false;
            this.rbDecrypt.Click += new System.EventHandler(this.rbDecrypt_Click);
            // 
            // btnDo
            // 
            this.btnDo.BackColor = System.Drawing.Color.Transparent;
            this.btnDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDo.Location = new System.Drawing.Point(1261, 1055);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(226, 62);
            this.btnDo.TabIndex = 6;
            this.btnDo.Text = "Encript";
            this.btnDo.UseVisualStyleBackColor = false;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rbEncrypt);
            this.panel1.Controls.Add(this.rbDecrypt);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(1021, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 200);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(1052, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 45);
            this.label1.TabIndex = 13;
            this.label1.Text = "Options:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1574, 1129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblCipherName);
            this.Controls.Add(this.cbCipherName);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lbC);
            this.Controls.Add(this.lbM);
            this.Controls.Add(this.tbC);
            this.Controls.Add(this.tbM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "SimpleCipher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbM;
        private TextBox tbC;
        private Label lbM;
        private Label lbC;
        private Button btnOpenFile;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button btnSaveFile;
        private ComboBox cbCipherName;
        private Label lblCipherName;
        private TextBox tbKey;
        private Label lblKey;
        private RadioButton rbEncrypt;
        private RadioButton rbDecrypt;
        private Button btnDo;
        private Panel panel1;
        private Label label1;
    }
}