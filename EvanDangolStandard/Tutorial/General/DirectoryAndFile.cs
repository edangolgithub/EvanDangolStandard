using System.IO;
using System;
using EvanDangol.Reflection;
using System.Collections.Generic;
namespace EvanDangol.Tutorial.General
{
    public class FileStreamClass
    {       
        public void FileStreamTypes()
        {
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.Open))
            {
                // read from file or write to file
            }
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.Open, FileAccess.Write))
            {
                // write to file
            }
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.Append))
            {
                // append to file
            }
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.Create))
            {
                // write to just created file
            }
            using (var fileStream = new FileStream(@"c:\file.txt", FileMode.CreateNew))
            {
                // write to just created file
            }
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read
                int c = 0;
                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                {
                    sum += count;  // sum is a buffer offset for next reading
                    c++;
                }
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        private static void ReadByte()
        {
            using (FileStream fs = new FileStream("abc.txt", FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                int offset = 0;
                //int a = fs.Read(buffer, offset, (int)fs.Length);
                int b;
                while ((b = fs.ReadByte()) > 0)
                {
                    buffer[offset] = (byte)b;
                    offset++;
                }
            }
        }
        public FileStream EvanFileStream { get; set; }
        public FileStreamClass(string filename)
        {
            EvanFileStream = new FileStream(filename, FileMode.Open);
        }
        public void CopyTo(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                EvanFileStream.CopyTo(fs);
            }
        }
        public void Copy(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                byte[] buffer;
                int length = (int)EvanFileStream.Length;  // get file length
                buffer = new byte[length];
                EvanFileStream.Read(buffer, 0, length);
                fs.Write(buffer, 0, length);
            }
        }
        public void CopyByte(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
              int b=  EvanFileStream.ReadByte();
              fs.WriteByte((byte)b);
            }
        }

       
        ~FileStreamClass()
        {
            EvanFileStream.Close();
        }
    }

    public class FileClass
    {
        public string FileName { get; set; }
        public FileClass()
        {
            FileName = "def.txt";
        }
       public IEnumerable<string> getnames()
        {

            return new List<string>()
           {
               "hello","bye","c Ya"
           };
        }
        public void AppendAllLines()
        {
            File.AppendAllLines(FileName, getnames());
            
        }
        public void AppendAllText()
        {
            File.AppendAllText(FileName, "hello");
        }
        public void AppendText()
        {
            File.AppendAllText(FileName, "hello");
        }
        public void abc()
        {
            File.Copy("abc.txt", "def.txt",true);
            File.Create("x.txt", 7);
        }
    }

    public class StreamWriterClass
    {
        StreamWriter writer = new StreamWriter("abc.txt");
        public void write()
        {
            writer.WriteLine();
        }
    }

    public class DirectoryAndFileInfo
    { 
        #region runDirectoryinfo

        public static void RunDriveInfo()
        {
            DriveInfo[] mydrives = DriveInfo.GetDrives(); 
            Console.WriteLine("runDirectoryinfo()");
            foreach (DriveInfo d in mydrives)

                try
                {  
                    Console.WriteLine("\nDirectory Name is {0}", d.Name);
                    if (d.IsReady)
                    {
                        Console.WriteLine("Volume Label : {0}", d.VolumeLabel);
                        Console.WriteLine( "Root Directory : {0}", d.RootDirectory);
                        Console.WriteLine("Total Size : {0} GB",d.TotalSize/1073741824);
                        Console.WriteLine("Free Space : {0} GB", d.AvailableFreeSpace / 1073741824);
                        Console.WriteLine("Drive Format : {0}", d.DriveFormat);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                catch (FormatException f)
                {
                    Console.WriteLine(f.Message);
                }
            //string path = Environment.GetEnvironmentVariable(@"c:\icons");
            //DirectoryInfo dir = new DirectoryInfo(path);
            //Console.WriteLine(dir.CreationTime)
        
        }
 #endregion

        #region runSearchDirectory
        static public void runSearchDirectory()
            {
                string st;
                Console.WriteLine("runSearchDirectory()");
                st = "c:\\";
                if (Directory.Exists(st))
                {
                    string[] s = Directory.GetDirectories(st);

                    for (int i = 0; i < s.Length; i++)
                        Console.WriteLine(s[i]);
                }
                else
                {
                    Console.WriteLine("No directory found");
                }
                Console.WriteLine();

            }
        #endregion

        #region rundirectoryinfo2
        public static void rundirectoryinfo2()
        {
            string path = @"C:\Evan";
            DirectoryInfo di = new DirectoryInfo(path);
            try
            {
               
                if (!di.Exists)
                {
            
                    di.Create(); 
                    di.CreateSubdirectory("Evan1"); 
                    di.CreateSubdirectory("Evan3"); 
                }

                Console.WriteLine(di.FullName);
                Console.WriteLine(di.CreationTime);
              
                DirectoryInfo[] subDirs = di.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                    Console.WriteLine(subDir.FullName);
              
                DirectoryInfo parent = di.Parent;
                if (parent.Exists)
                {
                 
                    Console.WriteLine(parent.FullName);
                }
      
                DirectoryInfo newlyCreatedFolder =
                di.CreateSubdirectory("Evan3");
         
                newlyCreatedFolder.Delete();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 
      
        #endregion

     public   static void DirSearch(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                    Console.WriteLine(f);
                foreach (string d in Directory.GetDirectories(dir))
                {
                    Console.WriteLine(d);
                    DirSearch(d);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
     public static void DirectorySearch(string dir)
     {
         try
         {
             foreach (string f in Directory.GetFiles(dir))
             {
                 Console.WriteLine(Path.GetFileName(f));
             }
             foreach (string d in Directory.GetDirectories(dir))
             {
                 Console.WriteLine(Path.GetFileName(d));
                 DirectorySearch(d);
             }

         }
         catch (System.Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
     }

      
    }
    public class DirectoryAndFile
    {
        [runnable]
        public static void Run()
        {
            DirectoryAndFileInfo.DirectorySearch(@"C:\Users\edangol\Documents\Visual Studio 2013\Projects\ConsoleApplication1");
        }

      
    }
}
  
