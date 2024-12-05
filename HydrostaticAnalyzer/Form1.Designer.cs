namespace HydrostaticAnalyzer
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShowTrimValues = new System.Windows.Forms.Button();
            this.cmbTrimValues = new System.Windows.Forms.ComboBox();
            this.dataGridViewFiltered = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltered)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 460);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(148, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Tablo Yükle";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(506, 426);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnShowTrimValues
            // 
            this.btnShowTrimValues.Location = new System.Drawing.Point(12, 489);
            this.btnShowTrimValues.Name = "btnShowTrimValues";
            this.btnShowTrimValues.Size = new System.Drawing.Size(148, 23);
            this.btnShowTrimValues.TabIndex = 2;
            this.btnShowTrimValues.Text = "Trim Değerlerini Göster";
            this.btnShowTrimValues.UseVisualStyleBackColor = true;
            this.btnShowTrimValues.Click += new System.EventHandler(this.btnShowTrimValues_Click);
            // 
            // cmbTrimValues
            // 
            this.cmbTrimValues.FormattingEnabled = true;
            this.cmbTrimValues.Location = new System.Drawing.Point(557, 462);
            this.cmbTrimValues.Name = "cmbTrimValues";
            this.cmbTrimValues.Size = new System.Drawing.Size(160, 21);
            this.cmbTrimValues.TabIndex = 3;
            this.cmbTrimValues.Text = "Trimleri Filtrele";
            // 
            // dataGridViewFiltered
            // 
            this.dataGridViewFiltered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiltered.Location = new System.Drawing.Point(557, 12);
            this.dataGridViewFiltered.Name = "dataGridViewFiltered";
            this.dataGridViewFiltered.ReadOnly = true;
            this.dataGridViewFiltered.Size = new System.Drawing.Size(357, 426);
            this.dataGridViewFiltered.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 539);
            this.Controls.Add(this.dataGridViewFiltered);
            this.Controls.Add(this.cmbTrimValues);
            this.Controls.Add(this.btnShowTrimValues);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltered)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowTrimValues;
        private System.Windows.Forms.ComboBox cmbTrimValues;
        private System.Windows.Forms.DataGridView dataGridViewFiltered;
    }
}

