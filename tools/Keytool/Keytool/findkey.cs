using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Keytool
{
    public static class findkey
    {
        public static string[] find()
        {
            List<string> ou = new List<string>();
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

                        ou.Add(arr2[0]);

                    }

                }
            }
            catch
            {

            }

            return ou.ToArray();
        }
    }
}
