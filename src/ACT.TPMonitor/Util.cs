using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ACT.TPMonitor
{
    class Util
    {
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
                        int left = (int)uint.Parse(sr.ReadLine().Split('\t')[1].ToString());  //ScreenLeft
                        int top = (int)uint.Parse(sr.ReadLine().Split('\t')[1].ToString());   //ScreenTop
                        int width = int.Parse(sr.ReadLine().Split('\t')[1].ToString()); //ScreenWidth
                        int height = int.Parse(sr.ReadLine().Split('\t')[1].ToString());//ScreenHeight

                        //ScreenMode (0:Window, 1:FullScreen, 2:Virtual)
                        int mode = int.Parse(sr.ReadLine().Split('\t')[1].ToString());

                        switch (mode)
                        {
                            case 0:
                                // Window
                                break;
                            case 1:
                                // FullScreen
                                left = 0;
                                top = 0;
                                width = int.Parse(sr.ReadLine().Split('\t')[1].ToString()); //FullScreenWidth
                                height = int.Parse(sr.ReadLine().Split('\t')[1].ToString());//FullScreenHeight
                                break;
                            case 2:
                                // Virtual
                                left = 0;
                                top = 0;
                                width = Screen.PrimaryScreen.Bounds.Width;
                                height = Screen.PrimaryScreen.Bounds.Height;
                                break;
                        }

                        screenRect = new Rectangle(new Point(left, top), new Size(width, height));
                        break;
                    }
                }
            }
            return screenRect;
        }

        public static Rectangle GetPartyListLocation(string path)
        {
            if (_screenRect.IsEmpty)
                _screenRect = GetWindowSize(path);
            Rectangle uiRect = new Rectangle(new Point(0, 0), new Size(0, 0));

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
                        float zoom = float.Parse(textLine[i + 7].Substring(2));

                        int x;
                        if (widthPercent < 30)
                        {
                            x = (int)((_screenRect.Width * widthPercent / 100));
                        }
                        else if (widthPercent < 60)
                        {
                            x = (int)((_screenRect.Width * (widthPercent / 100)) - (width / 2));
                        }
                        else
                        {
                            x = (int)((_screenRect.Width * (widthPercent / 100)) - width);
                        }

                        int y;
                        if (heightPercent < 30)
                        {
                            y = (int)((_screenRect.Height * heightPercent / 100));
                        }
                        else if (heightPercent < 60)
                        {
                            y = (int)((_screenRect.Height * (heightPercent / 100)) - (height / 2));
                        }
                        else
                        {
                            y = (int)((_screenRect.Height * (heightPercent / 100)) - height);
                        }

                        uiRect = new Rectangle(new Point(x, y), new Size(width, height));
                        break;
                    }
                }
            }
            return uiRect;
        }
    }
}
