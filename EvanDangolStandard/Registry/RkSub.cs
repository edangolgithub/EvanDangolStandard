//using Microsoft.Win32;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EvanDangol.RK
//{
//    public static class RkSub
//    {
//        public static RegistryKey GetInfo()
//        {
//            try
//            {
//                RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Default); //here you specify where exactly you want your entry

//                var reg = localMachine.OpenSubKey("Software\\Evan Dangol Softwares\\Rms", true);
//                if (reg == null)
//                {
//                    reg = localMachine.CreateSubKey("Software\\Evan Dangol Softwares\\Rms");

//                }
//                FileInfo file = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Tn1\\TMSetp.dbf"));

//                //var st = EvanDangol.FileReadWrite.ReadFile("c:\\windows\\tn1\\TMSetp.dbf").Split(';');
//                //DateTime dt = new DateTime(Convert.ToInt64(st[0]));
//                if (file == null)
//                {
//                    throw new Exception("Software Not installed Properly");
//                }
//                var date = file.CreationTime;
               

//                if (reg.GetValue("idt") == null)
//                {
//                    reg.SetValue("idt", date);
//                }
//                if (reg.GetValue("idt") != (object)date)
//                {
//                    reg.SetValue("idt", date);
//                }
//                if (reg.GetValue("sdt") == null)
//                {
//                    reg.SetValue("sdt", DateTime.Now.ToUniversalTime());
//                }
//                return reg;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
