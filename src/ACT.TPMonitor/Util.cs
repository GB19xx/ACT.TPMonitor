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

        public static IntPtr FFXIVProcessId { private get; set; }

        private static Rectangle _screenRect;

        private static Rectangle GetWindowSize(string path)
        {
            Rectangle screenRect = new Rectangle(new Point(0, 0), new Size(0, 0));

            string confFile = Path.Combine(Path.GetDirectoryName(path), @"FFXIV.cfg");
            using (StreamReader sr = new StreamReader(confFile, System.Text.Encoding.GetEncoding("shift_jis")))
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

                                    int borderWidth = ((windowRect.right - windowRect.left) - clientRect.right) / 2;
                                    left = windowRect.left + borderWidth;
                                    top = windowRect.bottom - clientRect.bottom - borderWidth;
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
            _screenRect = GetWindowSize(path);
            Widget widget = new Widget();
            widget.Rect = new Rectangle(new Point(0, 0), new Size(0, 0));
            widget.Scale = 1.0f;

            string textFile = Path.Combine(path, @"ADDON.DAT");
            using (System.IO.StreamReader sr = new System.IO.StreamReader(textFile, System.Text.Encoding.GetEncoding("shift_jis")))
            {
                string s = sr.ReadToEnd();
                string[] textLine = s.Split('\n');
                for (int i = 0; i < textLine.Length; i++)
                {
                    if (textLine[i].Equals("n:_PartyList_a"))
                    {
                        float widthPercent = float.Parse(textLine[i + 2].Substring(2));
                        float heightPercent = float.Parse(textLine[i + 3].Substring(2));
                        int width = int.Parse(textLine[i + 4].Substring(2));
                        int height = int.Parse(textLine[i + 5].Substring(2));
                        float widgetScale = scale == 0f ? float.Parse(textLine[i + 7].Substring(2)) : scale;

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
            return widget;
        }
    }
}
