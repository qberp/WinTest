using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static string sMySQLServer = "localhost";
        public static string sMySQLUser = "root";
        public static string sMySQLPassword = "123";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog()== DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this.barCodeControl1.Render(
            //    e.Graphics,
            //    100,
            //    100);
            e.HasMorePages = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Restore(string sMySQLDatabase, string sFilePath)
        {
            string constring = "server=" + sMySQLServer + ";user=" + sMySQLUser + ";pwd=" + sMySQLPassword + ";database=" + sMySQLDatabase + ";";
            //string file = "C:tempbackup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    MySqlBackup mb = new MySqlBackup(cmd);
                    
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(sFilePath);
                        conn.Close();
                    
                }
            }
        }
    }
}
