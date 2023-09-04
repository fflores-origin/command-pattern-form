using System.Drawing.Drawing2D;

namespace CP.Presentation.Custom
{
    public class RoundButton : Button
    {
        private float BorderRadius;
        private float BorderWidth;
        private Color BorderColor;

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    GraphicsPath grPath = new GraphicsPath();
        //    grPath.AddEllipse(new Rectangle(2, 2, this.Width - 5, this.Height - 5));
        //    this.Region = new Region(grPath);
        //    base.OnPaint(e);
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            Brush brush = new SolidBrush(this.BackColor);

            GraphicsPath GraphPath = GetRoundPath(Rect, 20, BorderRadius);

            this.Region = new Region(GraphPath);

            //Draw Back Color
            //if (IsMouseDown && !FlatAppearance.MouseDownBackColor.IsEmpty)
            //    using (Brush mouseDownBrush = new SolidBrush(FlatAppearance.MouseDownBackColor))
            //        e.Graphics.FillPath(mouseDownBrush, GraphPath);
            //else if (IsHovered && !FlatAppearance.MouseOverBackColor.IsEmpty)
            //    using (Brush overBrush = new SolidBrush(FlatAppearance.MouseOverBackColor))
            //        e.Graphics.FillPath(overBrush, GraphPath);
            //else
            e.Graphics.FillPath(brush, GraphPath);

            //Draw Border

            #region DrawBorder

            GraphicsPath GraphInnerPath;
            Pen pen;

            //if (IsMouseDown && !BorderDownColor.IsEmpty)
            //{
            //    GraphInnerPath = GetRoundPath(Rect, BorderRadius, BorderDownWidth);
            //    pen = new Pen(BorderDownColor, BorderDownWidth);
            //}
            //else if (IsHovered && !BorderOverColor.IsEmpty)
            //{
            //    GraphInnerPath = GetRoundPath(Rect, BorderRadius, BorderOverWidth);
            //    pen = new Pen(BorderOverColor, BorderOverWidth);
            //}
            //else
            //{
            GraphInnerPath = GetRoundPath(Rect, (int)BorderRadius, 0);
            pen = new Pen(BorderColor, 0);
            //}

            pen.Alignment = PenAlignment.Inset;
            if (pen.Width > 0)
                e.Graphics.DrawPath(pen, GraphInnerPath);

            #endregion DrawBorder

            //Draw Text
            DrawText(e.Graphics, Rect);
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius, float width)
        {
            //Fix radius to rect size
            radius = (int)Math.Max(
                     (Math.Min(radius,
                     Math.Min(Rect.Width, Rect.Height)) - width), 1);
            float r2 = radius / 2f;
            float w2 = width / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            //Top-Left Arc
            GraphPath.AddArc(Rect.X + w2, Rect.Y + w2, radius, radius, 180, 90);

            //Top-Right Arc
            GraphPath.AddArc(Rect.X + Rect.Width - radius - w2, Rect.Y + w2, radius,
                             radius, 270, 90);

            //Bottom-Right Arc
            GraphPath.AddArc(Rect.X + Rect.Width - w2 - radius,
                        Rect.Y + Rect.Height - w2 - radius, radius, radius, 0, 90);
            //Bottom-Left Arc
            GraphPath.AddArc(Rect.X + w2, Rect.Y - w2 + Rect.Height - radius, radius,
                             radius, 90, 90);

            //Close line ( Left)
            GraphPath.AddLine(Rect.X + w2, Rect.Y + Rect.Height - r2 - w2, Rect.X +
            w2, Rect.Y + r2 + w2);

            return GraphPath;
        }

        private void DrawText(Graphics g, RectangleF Rect)
        {
            float r2 = BorderRadius / 4f;
            float w2 = BorderWidth / 2f;
            Point point = new Point();
            StringFormat format = new StringFormat();

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                    point.X = (int)(Rect.X + r2 / 2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + r2 / 2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.TopCenter:
                    point.X = (int)(Rect.X + Rect.Width / 2f);
                    point.Y = (int)(Rect.Y + r2 / 2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.TopRight:
                    point.X = (int)(Rect.X + Rect.Width - r2 / 2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + r2 / 2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.MiddleLeft:
                    point.X = (int)(Rect.X + r2 / 2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + Rect.Height / 2);
                    format.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleCenter:
                    point.X = (int)(Rect.X + Rect.Width / 2);
                    point.Y = (int)(Rect.Y + Rect.Height / 2);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleRight:
                    point.X = (int)(Rect.X + Rect.Width - r2 / 2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + Rect.Height / 2);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomLeft:
                    point.X = (int)(Rect.X + r2 / 2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.BottomCenter:
                    point.X = (int)(Rect.X + Rect.Width / 2);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.BottomRight:
                    point.X = (int)(Rect.X + Rect.Width - r2 / 2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;

                default:
                    break;
            }

            /* Debug
            using (Pen pen = new Pen(Color.Black, 1))
            {
               g.DrawLine(pen, new Point(0, 0), point);
              g.DrawLine(pen, point.X, 0, point.X, point.Y);
              g.DrawLine(pen, 0, point.Y, point.X, point.Y);
            }
            */

            using (Brush brush = new SolidBrush(ForeColor))
                g.DrawString(Text, Font, brush, point, format);
        }
    }
}