//using EvanDangol.Core;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.IO;
//using System.Linq;
//using System.Windows.Forms;

//namespace EvanDangol.Controls
//{
//    public enum Evanchoice : byte { Font, Color, Size, HatchStyle, SystemProgram,EvanDataProvider };

//    public static class EvanControl
//    {
//        public static void GetMainScreenSize(this Control c)
//        {
//            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
//            c.Size = new System.Drawing.Size(workingRectangle.Width - 40, workingRectangle.Height - 40);
//        }

//        #region colors

//        public static void ChangeBackColor(this Control c)
//        {
//            ColorDialog cd = new ColorDialog();
//            if (cd.ShowDialog() != DialogResult.Cancel)
//            {
//                c.BackColor = cd.Color;
//            }
//        }

//        public static void ChangeBackColor(this Control c, string ColorName)
//        {
//            c.BackColor = Color.FromName(ColorName);
//        }

//        public static void ChangeBackColor(this Control c, KnownColor ColorName)
//        {
//            c.BackColor = Color.FromKnownColor(ColorName);
//        }

//        public static void ChangeForeColor(this Control c)
//        {
//            ColorDialog cd = new ColorDialog();
//            if (cd.ShowDialog() != DialogResult.Cancel)
//            {
//                c.ForeColor = cd.Color;
//            }
//        }

//        public static void ChangeForeColor(this Control c, string ColorName)
//        {
//            c.ForeColor = Color.FromName(ColorName);
//        }

//        public static void ChangeForeColor(this Control c, KnownColor ColorName)
//        {
//            c.ForeColor = Color.FromKnownColor(ColorName);
//        }

//        #endregion colors

//        #region Fonts

//        public static void ChangeFont(this Control c)
//        {
//            FontDialog cd = new FontDialog();
//            if (cd.ShowDialog() != DialogResult.Cancel)
//            {
//                c.Font = cd.Font;
//            }
//        }

//        public static void ChangeFont(this Control c, string FontName)
//        {
//            float FontSize = 8.25f;
//            ChangeFont(c, FontName, FontSize);
//        }

//        public static void ChangeFont(this Control c, string FontName, float FontSize = 8.5f)
//        {
//            c.Font = new Font(FontName, FontSize);
//        }

//        #endregion Fonts

//        #region Dialogs

//        public static void ShowSaveDialog()
//        {
//            EvanDangol.SaveDialog sd = new SaveDialog();
//            sd.ShowDialog();
//        }

//        public static void ShowAboutBox()
//        {
//            EvanDangol.EvanAboutBox ab = new EvanAboutBox();
//            ab.ShowDialog();
//        }

//        #endregion Dialogs

//        #region Fill

        

//        private static void GetControl(Control c, string Evanchoice)
//        {
//            if (c is ComboBox)
//            {
//                ComboBox cc = (ComboBox)c;
//                FillMeWith(cc, (Evanchoice)TypeDescriptor.GetConverter(typeof(Evanchoice)).ConvertFrom(Evanchoice));
//            }
//            else
//                if (c is ListBox)
//                {
//                    ListBox ll = (ListBox)c;
//                    FillMeWith(ll, (Evanchoice)TypeDescriptor.GetConverter(typeof(Evanchoice)).ConvertFrom(Evanchoice));
//                }
//                else
//                {
//                    throw new EvanException("Only ComboBox or ListBox can be filled");
//                }
//        }

//        private static void GetControl(Control c, Evanchoice echoice)
//        {
//            if (c is ComboBox)
//            {
//                ComboBox cc = (ComboBox)c;
//                FillMeWith(cc, echoice);
//            }
//            else
//                if (c is ListBox)
//                {
//                    ListBox ll = (ListBox)c;
//                    FillMeWith(ll, echoice);
//                }
//                else
//                {
//                    throw new EvanException("Only ComboBox or ListBox can be filled");
//                }
//        }

//        public static void FillMeWith(this Control c, string Evanchoice)
//        {
//            GetControl(c, Evanchoice);
//        }

//        public static void FillMeWith(this  Control c, Evanchoice echoice)
//        {
//            GetControl(c, echoice);
//        }

//        private static void FillMeWith(this ListBox c, Evanchoice t)
//        {
//            //c.DataSource = null;
//            switch (t)
//            {
//                case Evanchoice.Font:
//                    if (c.Text == "")
//                    {
//                        c.Text = "Arial";
//                    }
//                    FontFamily[] fs = GetAllFonts();
//                    foreach (FontFamily ff in fs)
//                    {
//                        if (ff.IsStyleAvailable(FontStyle.Regular))
//                        {
//                            c.Items.Add(ff.Name);
//                        }
//                    }
//                    break;

//                case Evanchoice.Color:
//                    if (c.Text == "")
//                    {
//                        c.Text = "Black";
//                    }
//                    foreach (KnownColor cname in GetAllColors())
//                    {
//                        Color color = Color.FromKnownColor(cname);
//                        c.Items.Add(color);
//                    }
//                    break;

//                case Evanchoice.Size:
//                    if (c.Text == "")
//                    {
//                        c.Text = "8";
//                    }
//                    for (int i = 1; i <= 50; i++)
//                    {
//                        c.Items.Add(i);
//                    }
//                    break;

//                case Evanchoice.SystemProgram:
//                    string[] dir = Directory.GetFiles(@"c:\Windows\System32").Where(a => a.EndsWith(".exe")).ToArray();
//                    foreach (string s in dir)
//                    {
//                        c.Items.Add(Path.GetFileNameWithoutExtension(s) + ".exe");
//                    }
//                    break;

//                case Evanchoice.HatchStyle:
//                    List<HatchStyle> harry = GetAllHatchStyles().AsEnumerable().Select(x => x).ToList();
//                    BindingSource bs = new BindingSource();
//                    bs.DataSource = harry;
//                    c.DataSource = bs;
//                    break;
//                case Evanchoice.EvanDataProvider:
//                    BindingSource bs1 = new BindingSource();
//                    bs1.DataSource = GetAllEvanDataProvider().AsEnumerable().Select(x => x);
//                    c.DataSource = bs1;
//                    break;
//            }
//            c.EndUpdate();
//        }

//        private static void FillMeWith(this ComboBox c, Evanchoice t)
//        {
//            switch (t)
//            {
//                case Evanchoice.Font:
//                    if (c.Text == "")
//                    {
//                        c.Text = "Arial";
//                    }
//                    FontFamily[] fs = FontFamily.Families;
//                    foreach (FontFamily ff in fs)
//                    {
//                        if (ff.IsStyleAvailable(FontStyle.Regular))
//                        {
//                            c.Items.Add(ff.Name);
//                        }
//                    }
//                    break;

//                case Evanchoice.Color:
//                    if (c.Text == "")
//                    {
//                        c.Text = "Black";
//                    }
//                    foreach (string cname in Enum.GetNames(typeof(KnownColor)))
//                    {
//                        if (cname != "ActiveCaptionText" && cname != "AppWorkspace")
//                        {
//                            c.Items.Add(cname);
//                        }
//                    }
//                    break;

//                case Evanchoice.Size:
//                    if (c.Text == "")
//                    {
//                        c.Text = "8";
//                    }
//                    for (int i = 1; i <= 50; i++)
//                    {
//                        c.Items.Add(i);
//                    }
//                    break;

//                case Evanchoice.SystemProgram:
//                    string[] dir = Directory.GetFiles(@"c:\Windows\System32").Where(a => a.EndsWith(".exe")).ToArray();
//                    foreach (string s in dir)
//                    {
//                        c.Items.Add(Path.GetFileNameWithoutExtension(s) + ".exe");
//                    }
//                    break;

//                case Evanchoice.HatchStyle:
//                    List<HatchStyle> harry = GetAllHatchStyles().AsEnumerable().Select(x => x).ToList();
//                    BindingSource bs = new BindingSource();
//                    bs.DataSource = harry;
//                    c.DataSource = bs;
//                    break;
//                case Evanchoice.EvanDataProvider:
//                    BindingSource bs1 = new BindingSource();
//                    bs1.DataSource = GetAllEvanDataProvider().AsEnumerable().Select(x => x);
//                    c.DataSource = bs1;
//                    break;
//            }
//        }

//        #endregion Fill

//        #region Process

//        public static void RunProgram(this object ob, string OpenFileDialogFileName)
//        {
//            Process.Start(Path.GetFullPath(OpenFileDialogFileName));
//        }

//        public static void RunSystemProgram(this ListBox l)
//        {
//            Process.Start(l.SelectedItem.ToString());
//        }

//        public static void RunSystemProgram(string Program)
//        {
//            try
//            {
//                Process.Start(Program);
//            }
//            catch (Exception run)
//            {
//                throw run;
//            }
//        }

//        public static void RunSystemProgram(this ComboBox c)
//        {
//            try
//            {
//                Process.Start(c.Text);
//            }
//            catch (Exception run)
//            {
//                throw run;
//            }
//        }

//        public static void FillMeWithSystemPrograms(this ListBox cc)
//        {
//            string[] dir = Directory.GetFiles(@"c:\Windows\System32").Where(a => a.EndsWith(".exe")).ToArray();
//            foreach (string c in dir)
//            {
//                cc.Items.Add(Path.GetFileNameWithoutExtension(c) + ".exe");
//            }
//        }

//        public static void FillMeWithSystemPrograms(this ComboBox cc)
//        {
//            string[] dir = Directory.GetFiles(@"c:\Windows\System32").Where(a => a.EndsWith(".exe")).ToArray();
//            foreach (string c in dir)
//            {
//                cc.Items.Add(Path.GetFileNameWithoutExtension(c) + ".exe");
//            }
//        }

//        #endregion Process

//        #region UtilitiyFunctions

//        public static List<KnownColor> GetAllColors()
//        {
//            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
//            return colors.ToList();
//        }

//        public static FontFamily[] GetAllFonts()
//        {
//            FontFamily[] fs = FontFamily.Families;
//            return fs;
//        }

//        public static List<HatchStyle> GetAllHatchStyles()
//        {
//            List<HatchStyle> hatchstyles = new List<HatchStyle>();
//            foreach (HatchStyle v in Enum.GetValues(typeof(HatchStyle)))
//            {
//                hatchstyles.Add(v);
//            }
//            return hatchstyles;
//        }
//        public static List<EvanDataProvider> GetAllEvanDataProvider() 
//        {
//         List<EvanDataProvider>    evandataproviders = new List<EvanDataProvider>();
//            foreach (EvanDataProvider v in Enum.GetValues(typeof(EvanDataProvider)))
//            {
//                evandataproviders.Add(v);
//            }
//            return evandataproviders;
//        }

//        #endregion UtilitiyFunctions
//    }
//}