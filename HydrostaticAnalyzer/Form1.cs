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

        // "Veriyi Yükle" butonu tıklama olayı
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // OpenFileDialog nesnesi oluştur
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Txt Dosyasını Seç";

                // Kullanıcı dosya seçerse işlemi başlat
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName; // Seçilen dosya yolu

                    try
                    {
                        // Verileri txt dosyasından oku
                        var allData = ReadDataFromTxt(filePath);

                        // Veriyi matrise dönüştür
                        HydrostaticsAll = ConvertToMatrix(allData);

                        // DataGridView'e veriyi yükle
                        LoadDataToGridView(HydrostaticsAll);

                        MessageBox.Show("Veriler başarıyla yüklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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


                    if (values.Count == 17) // Her satır 17 değer içermeli
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

        // Veriyi DataGridView'e yükleme
        public void LoadDataToGridView(double[,] matrix)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Sütunlar ekleniyor
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                dataGridView1.Columns.Add($"Column{j + 1}", $"Column {j + 1}");
            }

            // Satırlar ekleniyor
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = new List<string>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.Add(matrix[i, j].ToString());
                }
                dataGridView1.Rows.Add(row.ToArray());
            }
        }
    }
}
