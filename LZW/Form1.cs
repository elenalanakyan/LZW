using System;
using System.IO;
using System.Windows.Forms;

namespace LZW
{
    public partial class LZW : Form
    {
        public LZW()
        {
            InitializeComponent();
            encodeButton.Enabled = false;
            decodeButton.Enabled = false;
        }

        private void ClearAll()
        {
            filePathTextBox.Text = String.Empty;
            encodeButton.Enabled = false;
            decodeButton.Enabled = false;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
                if (new FileInfo(openFileDialog.FileName).Extension == ".lzw")
                    decodeButton.Enabled = true;
                else
                    encodeButton.Enabled = true;
            }

        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = $"{folderBrowserDialog.SelectedPath}\\{Path.GetFileName(filePathTextBox.Text)}.lzw";
                try
                {
                    using FileStream inputStream = new FileStream(filePathTextBox.Text, FileMode.Open);
                    using BinaryReader inputReader = new BinaryReader(inputStream);
                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
                    {
                        using BinaryWriter outputWriter = new BinaryWriter(outputStream);
                        LZWProvider.Compress(inputReader, outputWriter);
                    };

                    long inputFileSize = new FileInfo(filePathTextBox.Text).Length;
                    long outputFileSize = new FileInfo(outputPath).Length;
                    double ratio = (1 - (double)outputFileSize / inputFileSize) * 100;

                    MessageBox.Show($"Кодирование завершено\nРазмер начального файла: {inputFileSize} байт\nРазмер закодированного файла: {outputFileSize} байт\nСтепень сжатия: {ratio:N2}%", "Успешное кодирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(outputPath);
                }
            }
            ClearAll();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = $"{folderBrowserDialog.SelectedPath}\\{Path.GetFileNameWithoutExtension(filePathTextBox.Text)}";
                try
                {
                    using FileStream inputStream = new FileStream(filePathTextBox.Text, FileMode.Open);
                    using BinaryReader inputReader = new BinaryReader(inputStream);
                    using FileStream outputStream = new FileStream(outputPath, FileMode.Create);
                    using BinaryWriter outputWriter = new BinaryWriter(outputStream);

                    LZWProvider.Decompress(inputReader, outputWriter);

                    MessageBox.Show("Декодирование завершено", "Успешное декодирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(outputPath);
                }
            }
            ClearAll();
        }
    }
}
