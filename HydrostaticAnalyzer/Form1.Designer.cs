﻿namespace HydrostaticAnalyzer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrimInput = new System.Windows.Forms.TextBox();
            this.txtDraftInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiltered)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 272);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(148, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Tabloyu Yükle";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(731, 234);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnShowTrimValues
            // 
            this.btnShowTrimValues.Location = new System.Drawing.Point(12, 301);
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
            this.cmbTrimValues.Location = new System.Drawing.Point(138, 559);
            this.cmbTrimValues.Name = "cmbTrimValues";
            this.cmbTrimValues.Size = new System.Drawing.Size(160, 21);
            this.cmbTrimValues.TabIndex = 3;
            // 
            // dataGridViewFiltered
            // 
            this.dataGridViewFiltered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiltered.Location = new System.Drawing.Point(12, 405);
            this.dataGridViewFiltered.Name = "dataGridViewFiltered";
            this.dataGridViewFiltered.ReadOnly = true;
            this.dataGridViewFiltered.Size = new System.Drawing.Size(731, 148);
            this.dataGridViewFiltered.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Trim Değeri";
            // 
            // txtTrimInput
            // 
            this.txtTrimInput.Location = new System.Drawing.Point(643, 274);
            this.txtTrimInput.Name = "txtTrimInput";
            this.txtTrimInput.Size = new System.Drawing.Size(100, 20);
            this.txtTrimInput.TabIndex = 6;
            // 
            // txtDraftInput
            // 
            this.txtDraftInput.Location = new System.Drawing.Point(643, 303);
            this.txtDraftInput.Name = "txtDraftInput";
            this.txtDraftInput.Size = new System.Drawing.Size(100, 20);
            this.txtDraftInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Draft Değeri";
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(628, 329);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(115, 23);
            this.btnAddData.TabIndex = 9;
            this.btnAddData.Text = "Veri Ekle";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tablo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Filtrelenmiş Tablo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 567);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Filtrelemek istediğin trim:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 608);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDraftInput);
            this.Controls.Add(this.txtTrimInput);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShowTrimValues;
        private System.Windows.Forms.ComboBox cmbTrimValues;
        private System.Windows.Forms.DataGridView dataGridViewFiltered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrimInput;
        private System.Windows.Forms.TextBox txtDraftInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

