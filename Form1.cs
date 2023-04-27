using System.Text.RegularExpressions;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace hak
{
    public partial class Form1 : Form
    {
        string file = "Doc.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string serverName = "localhost";
            //string userName = "root";
            //string dbName = "hakaton";
            //string port = "3306";
            //string password = "1234";
            //string connectionStr = "server" + serverName + ";user=" + userName + ";database" + dbName + ";port" + port + ";password=" + password; 
            //asdg

            
            string firstPattern = @"~!(.*?)!~"; // –егул€рное выражение дл€ поиска текста между "!"


            using (StreamReader sr = new StreamReader(file))
            {
                //штука котора€ будет копировать выведенный текст в буфер обмена
                string line;
                string[] box;
                while ((line = sr.ReadLine()) != null)
                {
                    MatchCollection matches = Regex.Matches(line, firstPattern);
                    if (matches.Count != 0)
                    {
                        comboBox1.Items.Add(matches[0]);
                    }
                    foreach (Match match in matches)
                    {
                        textBox1.Text += match.Groups[1].Value; // ¬ывод содержимого между "!" на консоль
                        textBox1.Text += Environment.NewLine;
                    }
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void открыть‘айлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt (.txt)|*.txt; *.docx; *.doc;";
            ofd.InitialDirectory = "C:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = ofd.FileName;
            }

        }
    }
}