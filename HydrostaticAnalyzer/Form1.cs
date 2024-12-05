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
            "Trim", "Draft", "Displt", "LCB", "TCB", "VCB",
           "WPA", "LCF", "KML", "KMT", "BML", "BMT",
             "IL", "IT", "TPC", "MTC", "WSA"
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
                    row.Add(data[i, j].ToString());
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
                MessageBox.Show($"Trim Değerleri: {string.Join(", ", HydrostaticsTrimDegerleri)}",
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
    }
}
