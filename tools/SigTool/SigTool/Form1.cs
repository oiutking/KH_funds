using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SigTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.openFileDialog1.ShowDialog();
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cnstr = string.Format("server={0};database={1};uid={2};password={3};", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                string imgstr = "";
                imgstr = ToBase64(this.pictureBox1.Image);
                SqlConnection cn = new SqlConnection(cnstr);
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("insert into sig values(-1,0,'{0}',-1,1,'{1}')", imgstr,textBox5.Text);
                cmd.Connection = cn;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string ToBase64(Image img)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, img);
            byte[] bytes = memStream.GetBuffer();
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }


        private Image ToImage(string imgstr)
        {
            string base64 = imgstr;
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream memStream = new MemoryStream(bytes);
            BinaryFormatter binFormatter = new BinaryFormatter();
            Image img = (Image)binFormatter.Deserialize(memStream);
            return img;
        }
    }
}
