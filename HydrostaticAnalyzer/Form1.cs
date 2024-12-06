using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HydrostaticAnalyzer
{
    public partial class Form1 : Form
    {
        // Tüm hidrostatikler
        public static double[,] HydrostaticsAll { get; set; }

        public Form1()
        {
            InitializeComponent();

            cmbTrimValues.SelectedIndexChanged += cmbTrimValues_SelectedIndexChanged;
        }

        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Txt Dosyasını Seç";

                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Trim değerlerini bul ve doldur
                        ExtractTrimValues(filePath);

                        // Veriyi yükle
                        var allData = ReadDataFromTxt(filePath);
                        HydrostaticsAll = ConvertToMatrix(allData);
                        LoadDataToGridView(HydrostaticsAll);

                        MessageBox.Show("Veriler başarıyla yüklendi ve Trim değerleri kaydedildi!",
                                        "Bilgi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}",
                                        "Hata",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExtractTrimValues(string filePath)
        {
            var trimValues = new HashSet<double>(); // Benzersiz değerler için HashSet
            var lines = File.ReadAllLines(filePath); // Txt dosyasını okur

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0 && double.TryParse(parts[0], out double trim))
                {
                    trimValues.Add(trim);
                }
            }

            HydrostaticsTrimDegerleri = trimValues.OrderBy(t => t).ToArray();

            // ComboBox'a trim değerleri eklendi
            cmbTrimValues.Items.Clear();
            cmbTrimValues.Items.AddRange(HydrostaticsTrimDegerleri.Select(t => t.ToString("F2")).ToArray());
            cmbTrimValues.SelectedIndex = 0;

        }


        // Txt dosyasını okuma
        public List<List<double>> ReadDataFromTxt(string filePath)
        {
            var data = new List<List<double>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var values = new List<double>();
                    foreach (var value in line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (double.TryParse(value, out double result))
                        {
                            values.Add(result);
                        }
                    }


                    if (values.Count == 17)
                        data.Add(values);
                }
            }

            return data;
        }

        // Listeyi matrise çevirme
        public double[,] ConvertToMatrix(List<List<double>> listData)
        {
            int rows = listData.Count;
            int columns = listData[0].Count;
            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = listData[i][j];
                }
            }

            return matrix;
        }

        private readonly string[] ColumnHeaders =
        {
            "Trim (m)", "Draft (m)", "Displt (t)", "LCB (m)", "TCB (m)", "VCB (m)",
            "WPA (m²)", "LCF (m)", "KML (m)", "KMT (m)", "BML (m)", "BMT (m)",
             "IL (m⁴)", "IT (m⁴)", "TPC (t/cm)", "MTC (t-m/cm)", "WSA (m²)"
        };

        // Veriyi DataGridView'e yükleme
        private void LoadDataToGridView(double[,] data)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Sütun ve başlıklar
            for (int i = 0; i < ColumnHeaders.Length; i++)
            {
                dataGridView1.Columns.Add($"Column{i}", ColumnHeaders[i]);
            }

            // Veri ekleme
            for (int i = 0; i < data.GetLength(0); i++)
            {
                var row = new List<string>();
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row.Add(data[i, j].ToString("F2"));
                }
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        public static double[] HydrostaticsTrimDegerleri { get; set; }

        private void btnShowTrimValues_Click(object sender, EventArgs e)
        {
            if (HydrostaticsTrimDegerleri != null && HydrostaticsTrimDegerleri.Length > 0)
            {
                // Trim değerlerini MessageBox ile göster
                MessageBox.Show($"Trim Değerleri: {string.Join(", ", HydrostaticsTrimDegerleri.Select(t => t.ToString("F2")))}",
                                "Trim Değerleri",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Henüz Trim değerleri bulunamadı. Önce bir dosya yükleyin!",
                                "Uyarı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void cmbTrimValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrimValues.SelectedItem == null || HydrostaticsAll == null) return;

            // Seçilen trim değeri
            if (double.TryParse(cmbTrimValues.SelectedItem.ToString(), out double selectedTrim))
            {
                // Filtrelenmiş veri
                var filteredRows = new List<double[]>();
                for (int i = 0; i < HydrostaticsAll.GetLength(0); i++)
                {
                    if (HydrostaticsAll[i, 0] == selectedTrim) // Trim sütunu: 0. indeks
                    {
                        double[] row = new double[HydrostaticsAll.GetLength(1)];
                        for (int j = 0; j < HydrostaticsAll.GetLength(1); j++)
                        {
                            row[j] = HydrostaticsAll[i, j];
                        }
                        filteredRows.Add(row);
                    }
                }

                // Filtrelenmiş veriyi DataGridView'e yükle
                LoadDataToGridViewFiltered(filteredRows.ToArray());
            }
        }

        private void LoadDataToGridViewFiltered(double[][] filteredData)
        {
            dataGridViewFiltered.Rows.Clear();
            dataGridViewFiltered.Columns.Clear();

            // Sütun ve başlıklar
            for (int i = 0; i < ColumnHeaders.Length; i++)
            {
                dataGridViewFiltered.Columns.Add($"Column{i}", ColumnHeaders[i]);
            }

            // Veri ekleme
            foreach (var row in filteredData)
            {
                dataGridViewFiltered.Rows.Add(row.Select(v => v.ToString("F2")).ToArray());
            }
        }


    }
}
