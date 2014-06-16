using System;
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

            _controller = controller;
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;   // hidden border
            this.TransparencyKey = this.BackColor = Color.Navy;                 // the color key to transparent, choose a color that you don't use
            //this.Opacity = 0.3;

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

        public void Adjust(Rectangle rect)
        {
            this.Location = rect.Location;
            this.Size = rect.Size;
        }

        public void CurrentTPUpdate(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);

                for (int i = 1; i < _controller.PartyMemberInfo.Count; i++)
                {
                    if (!string.IsNullOrEmpty(_controller.PartyMemberInfo[i].Name))
                    {
                        DrawBar(g, i, _controller.PartyMemberInfo[i].TP);
                        DrawValue(g, i, _controller.PartyMemberInfo[i].TP);
                    }
                }
                g.Dispose();
            }
        }

        private void DrawBar(Graphics g, int idx, int value)
        {
            //Brushオブジェクトの作成
            SolidBrush b = new SolidBrush(Color.FromArgb(0x8, 0x2c, 0x52));
            g.FillRectangle(b, new Rectangle(258, (40 * idx) + 60, 87, 6));

            //Penの作成
            int width = 1;
            Pen framePen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), width);

            //LineJoinをRoundに変更して四角を描く（角が丸められる）
            framePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawRectangle(framePen, new Rectangle(258, (40 * idx) + 60, 87, 6));

            // TP-Value
            Brush valueBrush = Brushes.White;
            int percentValue = ((88 - width) * value) / 1000;
            g.FillRectangle(valueBrush, new Rectangle(258 + 1, (40 * idx) + 61, percentValue - 1, 5));
        }

        private void DrawValue(Graphics g, int idx, int value)
        {
            // レイアウト枠
            Rectangle rect = new Rectangle(247, 0, 100, 8);
            rect.Y = (40 * idx) + 68;
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
            path.AddString(value.ToString(), f.FontFamily, (int)f.Style, f.Height, rect, sf); // 文字列のパスを追加

            // フチを描く
            Pen p = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), 1.0f);
            //p.Color = Color.White;
            p.LineJoin = LineJoin.Round;
            g.DrawPath(p, path);

            // 塗りつぶす
            g.FillPath(Brushes.White, path);
            // 後始末
            p.Dispose();
            path.Dispose();
        }
    }
}
