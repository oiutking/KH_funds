using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Keytool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cnstr = string.Format("server={0};database={1};uid={2};password={3};", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                string key_word = "";
                key_word = to64(listBox1.SelectedItem.ToString());
                SqlConnection cn = new SqlConnection(cnstr);
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("insert into [key] values('{0}',-1,0,'{1}')", key_word, textBox5.Text);
                cmd.Connection = cn;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string str in findkey.find())
            {
               listBox1.Items.Add(str);
            }
        }

        string to64(string str)
        {

            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            string a = Convert.ToBase64String(b);
            return (a);
        }
    }
}
