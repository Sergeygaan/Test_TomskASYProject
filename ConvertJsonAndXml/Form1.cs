using Convert;
using System;
using System.Windows.Forms;
using WorkFiles;


namespace ConvertJsonAndXml
{
    public partial class Form1 : Form
    {
        private string _stringXML;
        private string _stringJson;

        private WorkOpenFileDialog _worckFileClass;
        private ConvertXMtoJSON _convertTextXMtoJSON;

        public Form1()
        {
            InitializeComponent();
            _worckFileClass = new WorkOpenFileDialog();
            _convertTextXMtoJSON = new ConvertXMtoJSON();
    }

        private void button1_Click(object sender, EventArgs e)
        {
            _stringXML = _worckFileClass.ReadFile();
    
            PrintList(_stringXML, listBox1);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _stringJson = _convertTextXMtoJSON.Convert(_stringXML);

            PrintList(_stringJson, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _worckFileClass.WriteFile(_stringJson);
        }

        public void PrintList(string StringPrint,ListBox ListBoxPrint)
        {
            ListBoxPrint.Items.Clear();

            string stringSumm = "";

            if (StringPrint != null)
            {
                foreach (char str in StringPrint)
                {
                    stringSumm += str;

                    if (str == '\n')
                    {
                        ListBoxPrint.Items.Add(stringSumm);
                        stringSumm = "";
                    }
                }
            }
        }


    }
}
