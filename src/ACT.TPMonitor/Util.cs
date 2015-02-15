using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ACT.TPMonitor
{
    class Util
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        public static IntPtr FFXIVProcessId { private get; set; }
        public static Language GameLanguage { get; private set; }

        private static Rectangle _screenRect;
        private static string _cfgFile = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"My Games\FINAL FANTASY XIV - A Realm Reborn\FFXIV.cfg");
        public static Widget _partyListUI;
        private static DateTime _lastWriteTime = DateTime.MinValue;

        public static void InitializedAtLogin()
        {
            using (StreamReader sr = new StreamReader(_cfgFile, System.Text.Encoding.GetEncoding("shift_jis")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Equals("<Version>"))
                    {
                        // read skip
                        line = sr.ReadLine();   //GuidVersion
                        line = sr.ReadLine();   //ConfigVersion
                        line = sr.ReadLine();   //Language

                        GameLanguage = (Language)int.Parse(line.Split('\t')[1].ToString());
                    }
                    else if (line.Equals("<Network Settings>"))
                    {
                        // read skip
                        sr.ReadLine();  //UPnP
                        sr.ReadLine();  //Port
                        sr.ReadLine();  //LastLogin0
                        sr.ReadLine();  //LastLogin1
                    }
                }
            }
            _lastWriteTime = DateTime.MinValue;
        }

        private static Rectangle GetWindowSize(string path)
        {
            Rectangle screenRect = new Rectangle(new Point(0, 0), new Size(0, 0));

            using (StreamReader sr = new StreamReader(_cfgFile, System.Text.Encoding.GetEncoding("shift_jis")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Equals("<Display Settings>"))
                    {
                        // read skip
                        sr.ReadLine();  //MainAdapter

                        // Location, ScreenSize
                        int left = (int)uint.Parse(sr.ReadLine().Split('\t')[1].ToString());    //ScreenLeft
                        int top = (int)uint.Parse(sr.ReadLine().Split('\t')[1].ToString());     //ScreenTop
                        int width = int.Parse(sr.ReadLine().Split('\t')[1].ToString());         //ScreenWidth
                        int height = int.Parse(sr.ReadLine().Split('\t')[1].ToString());        //ScreenHeight

                        //ScreenMode (0:Window, 1:FullScreen, 2:Virtual)
                        int mode = int.Parse(sr.ReadLine().Split('\t')[1].ToString());

                        switch (mode)
                        {
                            case 0:
                                // Window
                                if (FFXIVProcessId != IntPtr.Zero)
                                {
                                    RECT windowRect = new RECT();
                                    GetWindowRect(FFXIVProcessId, ref windowRect);
                                    
                                    RECT clientRect = new RECT();
                                    GetClientRect(FFXIVProcessId, ref clientRect);

                                    left = windowRect.left + SystemInformation.FrameBorderSize.Width;
                                    top = windowRect.bottom - clientRect.bottom - SystemInformation.FrameBorderSize.Height;
                                    width = clientRect.right;
                                    height = clientRect.bottom;
                                }
                                break;
                            case 1:
                                // FullScreen
                                left = 0;
                                top = 0;
                                width = int.Parse(sr.ReadLine().Split('\t')[1].ToString());     //FullScreenWidth
                                height = int.Parse(sr.ReadLine().Split('\t')[1].ToString());    //FullScreenHeight
                                break;
                            case 2:
                                // Virtual
                                left = 0;
                                top = 0;
                                width = Screen.PrimaryScreen.Bounds.Width;
                                height = Screen.PrimaryScreen.Bounds.Height;
                                break;
                            default:
                                break;
                        }

                        screenRect = new Rectangle(new Point(left, top), new Size(width, height));
                        break;
                    }
                }
            }
            return screenRect;
        }

        public static Widget GetPartyListLocation(string path)
        {
            return GetPartyListLocation(path, 0f);
        }

        public static Widget GetPartyListLocation(string path, float scale)
        {
            string textFile = Path.Combine(path, @"ADDON.DAT");
            if (_lastWriteTime != File.GetLastWriteTime(textFile))
            {
                _screenRect = GetWindowSize(path);
                Widget widget = new Widget();
                widget.Rect = new Rectangle(new Point(0, 0), new Size(0, 0));
                widget.Scale = 1.0f;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(textFile, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    string s = sr.ReadToEnd();
                    string[] textLine = s.Split('\n');
                    for (int i = 0; i < textLine.Length; i++)
                    {
                        if (textLine[i].Equals("n:_PartyList_a"))
                        {
                            float widthPercent = GetFloat(textLine[i + 2].Substring(2));
                            float heightPercent = GetFloat(textLine[i + 3].Substring(2));
                            int width = int.Parse(textLine[i + 4].Substring(2));
                            int height = int.Parse(textLine[i + 5].Substring(2));
                            float widgetScale = scale == 0f ? GetFloat(textLine[i + 7].Substring(2)) : scale;

                            width = (int)(width * widgetScale);
                            height = (int)(height * widgetScale);

                            int x;
                            if (widthPercent < 30)
                            {
                                x = (int)((_screenRect.Width * widthPercent / 100));
                            }
                            else if (widthPercent < 70)
                            {
                                x = (int)((_screenRect.Width * (widthPercent / 100)) - (width / 2));
                            }
                            else
                            {
                                x = (int)((_screenRect.Width * (widthPercent / 100)) - width);
                            }
                            x += _screenRect.Left;

                            int y;
                            if (heightPercent < 30)
                            {
                                y = (int)((_screenRect.Height * heightPercent / 100));
                            }
                            else if (heightPercent < 80)
                            {
                                y = (int)((_screenRect.Height * (heightPercent / 100)) - (height / 2));
                            }
                            else
                            {
                                y = (int)((_screenRect.Height * (heightPercent / 100)) - height);
                            }
                            y += _screenRect.Top;


                            widget.Rect = new Rectangle(new Point(x, y), new Size(width, height));
                            widget.Scale = widgetScale;
                            break;
                        }
                    }
                }
                _partyListUI = widget;
                _lastWriteTime = File.GetLastWriteTime(textFile);
            }
            return _partyListUI;
        }

        private static float GetFloat(string v)
        {
            return float.Parse(v, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool IsActive(IntPtr hWnd)
        {
            return hWnd == GetForegroundWindow();
        }
    }
}
