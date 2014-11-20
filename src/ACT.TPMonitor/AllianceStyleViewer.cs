using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ACT.TPMonitor
{
    public partial class AllianceStyleViewer : Form
    {
        private TPMonitorController _controller;

        public AllianceStyleViewer(TPMonitorController controller)
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle(Properties.Resources.army_s_paeon.GetHicon());

            _controller = controller;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;   // hidden border
            this.TransparencyKey = Color.Magenta;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            controller.CurrentTPUpdate += CurrentTPUpdate;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Set the form click-through
                cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
                return cp;
            }
        }

        public void Adjust()
        {
            this.Location = new Point((int)_controller.AllianceX, (int)_controller.AllianceY);
            float scale = _controller.IsUserScale ? _controller.UserScale:1.0f;
            this.Size = new Size((int)(320 * scale), (int)(72 * scale));
        }

        public void CurrentTPUpdate(object sender, EventArgs e)
        {            
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Visible)
            {
                if (_controller.DisappearsInActive && !Util.IsActive(FFXIVPluginHelper.GetFFXIVProcess.MainWindowHandle))
                {
                    // Disappears
                }
                else
                {
                    Graphics g = e.Graphics;

                    for (int i = 0; i < _controller.PartyMemberInfo.Count; i++)
                    {
                        DrawImg(g, i, _controller.IsUserScale ? _controller.UserScale : _controller.PartyListUI.Scale);

                        if (!string.IsNullOrEmpty(_controller.PartyMemberInfo[i].Name) &&
                            _controller.HideJob.IndexOf((JOB)_controller.PartyMemberInfo[i].Job) == -1)
                        {
                            // TP
                            DrawBar(g, i, _controller.PartyMemberInfo[i].CurrentTP, _controller.IsUserScale ? _controller.UserScale : _controller.PartyListUI.Scale);
                        }
                        else
                        {
                            // TP
                            DrawBar(g, i, 0, _controller.IsUserScale ? _controller.UserScale : _controller.PartyListUI.Scale);
                        }
                    }
                }
            }
        }

        private void DrawImg(Graphics g, int idx, float scale)
        {
            Rectangle rect = new Rectangle((int)(((78 * (idx % 4)) + 8) * scale), (int)(((32 * (idx / 4)) + 7) * scale), (int)(24 * scale), (int)(24 * scale));

            JOB job = JOB.Unknown;
            Enum.TryParse<JOB>(_controller.PartyMemberInfo[idx].Job.ToString(), out job);
            if (job != JOB.Unknown)
            {
                g.DrawImage(imageListJob.Images[(int)job], (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
            }
        }

        private void DrawBar(Graphics g, int idx, int value, float scale)
        {
            Rectangle rect = new Rectangle((int)(((78 * (idx % 4)) + 37) * scale), (int)(((32 * (idx / 4)) + 11) * scale), (int)(40 * scale), (int)(18 * scale));
            //Brushオブジェクトの作成
            SolidBrush b = new SolidBrush(Color.FromArgb(0x8, 0x2c, 0x52));
            g.FillRectangle(b, rect);

            // TP-Value
            Brush valueBrush = GetColor(value);
            g.FillRectangle(valueBrush, rect.X, rect.Y, value * rect.Width / 1000, rect.Height);
        }

        private Brush GetColor(int value)
        {
            var brush = Brushes.White;
            foreach (DataRow r in _controller.dtColor.Rows)
            {
                if (int.Parse(r[0].ToString()) <= value && value <= int.Parse(r[1].ToString()))
                {
                    string[] rgb = r[2].ToString().Split(',');
                    if (rgb.Length == 3)
                    {
                        brush = new SolidBrush(Color.FromArgb(255, int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2])));
                    }
                    else
                    {
                        brush = new SolidBrush(Color.FromName(r[2].ToString()));
                    }
                    break;
                }
            }
            return brush;
        }
    }
}
