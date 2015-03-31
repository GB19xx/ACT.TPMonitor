using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ACT.TPMonitor
{
    public partial class TPViewer : Form
    {
        private TPMonitorController _controller;

        public TPViewer(TPMonitorController controller)
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle(Properties.Resources.army_s_paeon.GetHicon());

            _controller = controller;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;   // hidden border
            this.TransparencyKey = this.BackColor = Color.Navy;                 // the color key to transparent, choose a color that you don't use
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
            Adjust(_controller.PartyListUI);
        }

        public void Adjust(Widget widget)
        {
            Point pos = widget.Rect.Location;
            if (_controller.IsFixedMode)
            {
                pos = new Point((int)_controller.FixedX, (int)_controller.FixedY);
            }
            else
            {
                pos.Offset((int)_controller.OffsetX, (int)_controller.OffsetY);
            }
            this.Location = pos;
            this.Size = widget.Rect.Size;
        }

        public void CurrentTPUpdate(object sender, EventArgs e)
        {            
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.Visible)
                return;
            // Disappears
            if (_controller.DisappearsInActive && !Util.IsActive(FFXIVPluginHelper.GetFFXIVProcess.MainWindowHandle))
                return;

            Graphics g = e.Graphics;
            g.Clear(this.BackColor);

            int s = _controller.IsFixedMode && _controller.ShowMyTP ? 0 : 1;
            for (int i = 0; i < _controller.PartyMemberInfo.Count; i++)
            {
                if (string.IsNullOrEmpty(_controller.PartyMemberInfo[i].Name) ||
                         _controller.HideJob.IndexOf((JOB)_controller.PartyMemberInfo[i].Job) != -1)
                    continue;

                float scale = _controller.IsUserScale ? _controller.UserScale : _controller.PartyListUI.Scale;
                bool showSelf = _controller.ShowMyTP && _controller.IsFixedMode;
                if (showSelf || i != 0)
                {
                    DrawBar(g, i, _controller.PartyMemberInfo[i].CurrentTP, scale);
                    DrawString(g, i,_controller.PartyMemberInfo[i].CurrentTP.ToString(), scale, 0, 0);
                }

                if (_controller.PartyMemberInfo[i].CooldownMap == null)
                    continue;

                int offsetAdjust = (int)(_controller.TPFont.Height * scale * 4);
                int offsetX = offsetAdjust;
                int font_unit = (int)(_controller.TPFont.Height * scale);
                int labelOffsetY = (int)(_controller.TPFont.Height * scale * -1.2);

                foreach (TPMonitorController.MonitoredAbility ability in _controller.Abilities)
                {
                    if (!_controller.PartyMemberInfo[i].CooldownMap.ContainsKey(ability.MatchName))
                        continue;
                    TimeSpan span = _controller.PartyMemberInfo[i].CooldownMap[ability.MatchName].Subtract(DateTime.Now);
                    int remaining = (int)Math.Ceiling(span.TotalSeconds);
                    if (remaining <= 0)
                        continue;

                    DrawString(g, i, remaining.ToString(), scale, offsetX, 0);
                    DrawString(g, i, ability.ShortName, scale, offsetX, labelOffsetY);

                    offsetX += offsetAdjust;
                }
            }
        }

        private void DrawBar(Graphics g, int idx, int value, float scale)
        {
            Rectangle rect = new Rectangle((int)(258 * scale), (int)(((40 * idx) + 60) * scale), (int)(87 * scale), (int)(6 * scale));
            //Brushオブジェクトの作成
            SolidBrush b = new SolidBrush(Color.FromArgb(0x8, 0x2c, 0x52));
            g.FillRectangle(b, rect.X, rect.Y, rect.Width, rect.Height);

            //Penの作成
            int width = 1;
            Pen framePen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), width);

            //LineJoinをRoundに変更して四角を描く（角が丸められる）
            framePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawRectangle(framePen, rect.X, rect.Y, rect.Width, rect.Height);

            // TP-Value
            Brush valueBrush = GetColor(value);
            g.FillRectangle(valueBrush, rect.X + width, rect.Y + width, (value * rect.Width / 1000) - width, rect.Height - width);
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

        private void DrawString(Graphics g, int idx, String str, float scale, int offsetX, int offsetY)
        {
            // レイアウト枠
            Rectangle rect = new Rectangle((int)(247 * scale) + offsetX, (int)(((40 * idx) + 60 + 8) * scale) + offsetY, (int)(100 * scale), (int)(8 * scale));
            rect.Inflate(0, 0); // ちょっと小さい枠内にレイアウト

            // 文字列位置の設定
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Far;

            // アンチエイリアス
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Font f = _controller.TPFont;

            // パスを作成
            GraphicsPath path = new GraphicsPath();
            path.AddString(str, f.FontFamily, (int)f.Style, f.Height * scale, rect, sf); // 文字列のパスを追加

            // フチを描く
            Pen p = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), 1.0f * scale);
            //p.Color = Color.White;
            p.LineJoin = LineJoin.Round;
            g.DrawPath(p, path);

            // 塗りつぶす
            g.FillPath(Brushes.White, path);
            // 後始末
            g.SmoothingMode = SmoothingMode.Default; 
            p.Dispose();
            path.Dispose();
        }
    }
}
