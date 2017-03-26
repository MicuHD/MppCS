namespace labMpp.GUI
{
    partial class MeniuView
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
            this.components = new System.ComponentModel.Container();
            this.spectacolTable = new System.Windows.Forms.DataGridView();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.cautaTable = new System.Windows.Forms.DataGridView();
            this.cautaText = new System.Windows.Forms.TextBox();
            this.cautaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numeText = new System.Windows.Forms.TextBox();
            this.bileteText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vanzareBtn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spectacolTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cautaTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // spectacolTable
            // 
            this.spectacolTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spectacolTable.Location = new System.Drawing.Point(13, 13);
            this.spectacolTable.Name = "spectacolTable";
            this.spectacolTable.Size = new System.Drawing.Size(496, 160);
            this.spectacolTable.TabIndex = 0;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(515, 342);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 23);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // cautaTable
            // 
            this.cautaTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cautaTable.Location = new System.Drawing.Point(13, 205);
            this.cautaTable.Name = "cautaTable";
            this.cautaTable.Size = new System.Drawing.Size(496, 160);
            this.cautaTable.TabIndex = 2;
            // 
            // cautaText
            // 
            this.cautaText.Location = new System.Drawing.Point(80, 179);
            this.cautaText.Name = "cautaText";
            this.cautaText.Size = new System.Drawing.Size(150, 20);
            this.cautaText.TabIndex = 3;
            // 
            // cautaBtn
            // 
            this.cautaBtn.Location = new System.Drawing.Point(236, 176);
            this.cautaBtn.Name = "cautaBtn";
            this.cautaBtn.Size = new System.Drawing.Size(75, 23);
            this.cautaBtn.TabIndex = 4;
            this.cautaBtn.Text = "Cauta";
            this.cautaBtn.UseVisualStyleBackColor = true;
            this.cautaBtn.Click += new System.EventHandler(this.cautaBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vanzareBtn);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(515, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vanzare";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numeText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bileteText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(210, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numeText
            // 
            this.numeText.Location = new System.Drawing.Point(93, 3);
            this.numeText.Name = "numeText";
            this.numeText.Size = new System.Drawing.Size(100, 20);
            this.numeText.TabIndex = 0;
            // 
            // bileteText
            // 
            this.bileteText.Location = new System.Drawing.Point(93, 30);
            this.bileteText.Name = "bileteText";
            this.bileteText.Size = new System.Drawing.Size(100, 20);
            this.bileteText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nume: ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nr. bilete";
            // 
            // vanzareBtn
            // 
            this.vanzareBtn.Location = new System.Drawing.Point(119, 80);
            this.vanzareBtn.Name = "vanzareBtn";
            this.vanzareBtn.Size = new System.Drawing.Size(75, 23);
            this.vanzareBtn.TabIndex = 7;
            this.vanzareBtn.Text = "Vanzare";
            this.vanzareBtn.UseVisualStyleBackColor = true;
            this.vanzareBtn.Click += new System.EventHandler(this.vanzareBtn_Click);
            // 
            // MeniuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 384);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cautaBtn);
            this.Controls.Add(this.cautaText);
            this.Controls.Add(this.cautaTable);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.spectacolTable);
            this.Name = "MeniuView";
            this.Text = "MeniuView";
            ((System.ComponentModel.ISupportInitialize)(this.spectacolTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cautaTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView spectacolTable;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.DataGridView cautaTable;
        private System.Windows.Forms.TextBox cautaText;
        private System.Windows.Forms.Button cautaBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numeText;
        private System.Windows.Forms.TextBox bileteText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button vanzareBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}