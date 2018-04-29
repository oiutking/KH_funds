using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

namespace findusb
{
    [Guid("6F8300B7-59C4-41D8-BA4F-F3D10DD5E8A9")]
    [System.Security.SecuritySafeCritical]
    public partial class uc : UserControl
    {
        public string outstr = "123";
        public uc()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            MessageBox.Show(find());
            
        }

        public string find()
        {
            string ou = "";
            try
            {
                
                ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                
                foreach (ManagementObject disk in disks.Get())
                {
                    
                    string a = disk["PNPDeviceID"].ToString();
                    string[] arr = a.Split('\\');
                    string[] arr2 = arr[arr.Length - 1].Split('&');
                    if (disk["InterfaceType"].ToString() == "USB")
                    {

                        ou +=","+ arr2[0];

                    }

                }
            }
            catch(Exception ex)
            {
                ou = ex.Message;
            }

            return ou;
        }
    }
}
