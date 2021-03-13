namespace GCFixer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.textBoxInstallDir = new System.Windows.Forms.TextBox();
            this.buttonFix = new System.Windows.Forms.Button();
            this.buttonUnfix = new System.Windows.Forms.Button();
            this.labelBy = new System.Windows.Forms.Label();
            this.linkLabelUmbranox = new System.Windows.Forms.LinkLabel();
            this.labelAnd = new System.Windows.Forms.Label();
            this.linkLabelAuros = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your installation directory: ";
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChange.Location = new System.Drawing.Point(461, 11);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 25);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // textBoxInstallDir
            // 
            this.textBoxInstallDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallDir.BackColor = System.Drawing.Color.White;
            this.textBoxInstallDir.Location = new System.Drawing.Point(162, 12);
            this.textBoxInstallDir.Name = "textBoxInstallDir";
            this.textBoxInstallDir.ReadOnly = true;
            this.textBoxInstallDir.Size = new System.Drawing.Size(293, 22);
            this.textBoxInstallDir.TabIndex = 2;
            // 
            // buttonFix
            // 
            this.buttonFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFix.Location = new System.Drawing.Point(12, 42);
            this.buttonFix.Name = "buttonFix";
            this.buttonFix.Size = new System.Drawing.Size(524, 23);
            this.buttonFix.TabIndex = 3;
            this.buttonFix.Text = "Fix";
            this.buttonFix.UseVisualStyleBackColor = true;
            this.buttonFix.Click += new System.EventHandler(this.ButtonFix_Click);
            // 
            // buttonUnfix
            // 
            this.buttonUnfix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnfix.Location = new System.Drawing.Point(12, 71);
            this.buttonUnfix.Name = "buttonUnfix";
            this.buttonUnfix.Size = new System.Drawing.Size(524, 23);
            this.buttonUnfix.TabIndex = 4;
            this.buttonUnfix.Text = "Unfix";
            this.buttonUnfix.UseVisualStyleBackColor = true;
            this.buttonUnfix.Click += new System.EventHandler(this.ButtonUnfix_Click);
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.Location = new System.Drawing.Point(9, 97);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(198, 13);
            this.labelBy.TabIndex = 5;
            this.labelBy.Text = "This banger application was made by";
            // 
            // linkLabelUmbranox
            // 
            this.linkLabelUmbranox.AutoSize = true;
            this.linkLabelUmbranox.Location = new System.Drawing.Point(205, 97);
            this.linkLabelUmbranox.Name = "linkLabelUmbranox";
            this.linkLabelUmbranox.Size = new System.Drawing.Size(60, 13);
            this.linkLabelUmbranox.TabIndex = 6;
            this.linkLabelUmbranox.TabStop = true;
            this.linkLabelUmbranox.Text = "Umbranox";
            this.linkLabelUmbranox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelUmbranox_LinkClicked);
            // 
            // labelAnd
            // 
            this.labelAnd.AutoSize = true;
            this.labelAnd.Location = new System.Drawing.Point(264, 97);
            this.labelAnd.Name = "labelAnd";
            this.labelAnd.Size = new System.Drawing.Size(27, 13);
            this.labelAnd.TabIndex = 7;
            this.labelAnd.Text = "and";
            // 
            // linkLabelAuros
            // 
            this.linkLabelAuros.AutoSize = true;
            this.linkLabelAuros.Location = new System.Drawing.Point(290, 97);
            this.linkLabelAuros.Name = "linkLabelAuros";
            this.linkLabelAuros.Size = new System.Drawing.Size(37, 13);
            this.linkLabelAuros.TabIndex = 8;
            this.linkLabelAuros.TabStop = true;
            this.linkLabelAuros.Text = "Auros";
            this.linkLabelAuros.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAuros_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 119);
            this.Controls.Add(this.linkLabelAuros);
            this.Controls.Add(this.labelAnd);
            this.Controls.Add(this.linkLabelUmbranox);
            this.Controls.Add(this.labelBy);
            this.Controls.Add(this.buttonUnfix);
            this.Controls.Add(this.buttonFix);
            this.Controls.Add(this.textBoxInstallDir);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beat Saber GC Fixer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox textBoxInstallDir;
        private System.Windows.Forms.Button buttonFix;
        private System.Windows.Forms.Button buttonUnfix;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.LinkLabel linkLabelUmbranox;
        private System.Windows.Forms.Label labelAnd;
        private System.Windows.Forms.LinkLabel linkLabelAuros;
    }
}

