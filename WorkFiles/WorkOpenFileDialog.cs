using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SDK;

namespace WorkFiles
{
   public class WorkOpenFileDialog : IWorkFile
    {
        private string _stringLoad;

        public string ReadFile()
        {
            Stream MyStream = null;
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            OpenFileDialog1.Filter = "text files (*.xml)|*.xml";
            OpenFileDialog1.FilterIndex = 2;
            OpenFileDialog1.RestoreDirectory = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((MyStream = OpenFileDialog1.OpenFile()) != null)
                    {
                        using (MyStream)
                        {
                            MyStream.Close();
                           FileStream stream = new FileStream(OpenFileDialog1.FileName, FileMode.Open);
                           StreamReader reader = new StreamReader(stream);
                            _stringLoad = reader.ReadToEnd();
                           stream.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка. Файл не может быть считан: " + ex.Message);
                }
            }

            return _stringLoad;
        }


        public void WriteFile(string WriteString)
        {
            Stream MyStream;
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

            SaveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            SaveFileDialog1.Filter = "text files (*.json)|*.json";
            SaveFileDialog1.FilterIndex = 2;
            SaveFileDialog1.RestoreDirectory = true;

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((MyStream = SaveFileDialog1.OpenFile()) != null)
                {
                    MyStream.Close();
   
                    File.WriteAllText(SaveFileDialog1.FileName, WriteString, Encoding.UTF8);

                    MessageBox.Show("Данные успешно записанны в файл");
                }
            }
        }
    }
}
