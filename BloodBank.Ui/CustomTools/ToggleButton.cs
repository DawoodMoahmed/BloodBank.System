﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace BloodBank.Ui
{
    public class ToggleButton : Control
    {
        #region variables
        FileInfo f;
        Rectangle contentRectangle = Rectangle.Empty;
        Point[] pts2 = new Point[4];
        Rectangle controlBounds = Rectangle.Empty;


        #endregion

        public ToggleButton()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
            f = FindApplicationFile("screw.png");
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            controlBounds = e.ClipRectangle;
            e.Graphics.ResetClip();
            switch (ToggleStyle)
            {
                case ToggleButtonStyle.Android:
                    this.MinimumSize = new Size(75, 23);
                    this.MaximumSize = new Size(119, 32);
                    contentRectangle = e.ClipRectangle;
                    this.BackColor = Color.FromArgb(32, 32, 32);
                    DrawAndroidStyle(e);
                    break;
                case ToggleButtonStyle.Windows:
                    this.MinimumSize = new Size(65, 23);
                    this.MaximumSize = new Size(119, 32);
                    contentRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, this.Width - 1, this.Height - 1);
                    DrawWindowsStyle(e);
                    break;
                case ToggleButtonStyle.IOS:
                    this.MinimumSize = new Size(93, 30);
                    this.MaximumSize = new Size(135, 51);
                    Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
                    contentRectangle = r;
                    DrawIOSStyle(e);
                    break;
            }
            base.OnPaint(e);
        }

        #region AndroidStyle
        Point[] andPoints = new Point[4]; Point p1, p2, p3, p4;
        private Point[] AndroidPoints()
        {
            p1 = new Point(padx, contentRectangle.Y);
            if (padx == 0)
                p2 = new Point(padx, contentRectangle.Bottom);
            else
                p2 = new Point(padx - SlidingAngle, contentRectangle.Bottom);

            p4 = new Point(p1.X + (contentRectangle.Width / 2), contentRectangle.Y);

            p3 = new Point(p4.X - SlidingAngle, contentRectangle.Bottom);
            if (p4.X == contentRectangle.Right)
                p3 = new Point(p4.X, contentRectangle.Bottom);

            andPoints[0] = p1;
            andPoints[1] = p2;
            andPoints[2] = p3;
            andPoints[3] = p4;
            return andPoints;

            ///p1 -  p4
            ///|     |
            ///p2 -  p3


        }

        private void DrawAndroidStyle(PaintEventArgs e)
        {
            e.Graphics.ResetClip();
            float val = 7f;
            Font f = new Font("Microsoft Sans Serif", val);
            contentRectangle = e.ClipRectangle;
            if (!isMouseMoved)
            {
                if (this.ToggleState == ToggleButtonState.ON)
                    padx = this.contentRectangle.Right - (this.contentRectangle.Width / 2);
                else
                    padx = 0;
            }
            using (SolidBrush sb = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(sb, e.ClipRectangle);
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color clr;
            if (padx == 0)
                clr = this.InActiveColor;
            else
                clr = this.ActiveColor;
            using (SolidBrush sb = new SolidBrush(clr))
            {
                e.Graphics.FillPolygon(sb, AndroidPoints());
            }
            if (padx == 0)
            {
                e.Graphics.DrawString(this.InActiveText, f, Brushes.White, new PointF(padx + ((contentRectangle.Width / 2) / 6), contentRectangle.Y + (contentRectangle.Height / 4)));
            }
            else
            {
                e.Graphics.DrawString(this.ActiveText, f, Brushes.White, new PointF(padx + ((contentRectangle.Width / 2) / 4), contentRectangle.Y + (contentRectangle.Height / 4)));
            }
        }

        #endregion

        #region Windows style
        private Rectangle WindowSliderBounds
        {
            get
            {
                Rectangle rect = Rectangle.Empty;
                if (sliderPoint.X > controlBounds.Right - 15)
                    sliderPoint.X = controlBounds.Right - 15;
                if (sliderPoint.X < controlBounds.Left)
                    sliderPoint.X = controlBounds.Left;
                rect = new Rectangle(sliderPoint.X, controlBounds.Y, 15, this.Height);
                return rect;
            }
        }


        /// <summary>
        /// make sure the diff in rect is acceptable
        /// </summary>
        /// <param name="e"></param>
        private void DrawWindowsStyle(PaintEventArgs e)
        {
            contentRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, this.Width - 1, this.Height - 1);
            if (!isMouseMoved)
            {
                if (this.ToggleState == ToggleButtonState.ON)
                    sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                else
                    sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
            }
            Pen p = new Pen(Color.FromArgb(159, 159, 159));

            p.Width = 1.9f;
            e.Graphics.DrawRectangle(p, contentRectangle);
            e.Graphics.DrawRectangle(p, Rectangle.Inflate(contentRectangle, -3, -3));
            Rectangle r1 = new Rectangle(Rectangle.Inflate(contentRectangle, -3, -3).Left, Rectangle.Inflate(contentRectangle, -3, -3).Y, WindowSliderBounds.Left - Rectangle.Inflate(contentRectangle, -3, -3).Left, Rectangle.Inflate(contentRectangle, -3, -3).Height);
            Rectangle r2 = new Rectangle(WindowSliderBounds.Right, r1.Y, Rectangle.Inflate(contentRectangle, -3, -3).Right - WindowSliderBounds.Right, r1.Height);

            using (SolidBrush sb = new SolidBrush(this.ActiveColor))
            {
                e.Graphics.FillRectangle(sb, r1);
            }
            using (SolidBrush sb = new SolidBrush(this.SliderColor))
            {
                e.Graphics.FillRectangle(sb, WindowSliderBounds);
            }
            using (SolidBrush sb = new SolidBrush(this.InActiveColor))
            {
                e.Graphics.FillRectangle(sb, r2);
            }

            this.BackColor = Color.White;
        }

        #endregion

        #region IOS Style
        private void DrawIOSStyle(PaintEventArgs e)
        {

            this.BackColor = Color.Transparent;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            contentRectangle = r;
            if (!isMouseMoved)
            {
                if (this.ToggleState == ToggleButtonState.ON)
                    ipadx = this.contentRectangle.Right - (this.contentRectangle.Height - 3);
                else
                    ipadx = 2;
            }
            Rectangle rect = new Rectangle(ipadx, r.Y, r.Height - 5, r.Height);
            Rectangle r2 = new Rectangle(this.Width / 6 - 10, this.Height / 2, (this.Width / 6 - 10) + (rect.X + rect.Width / 2), this.Height / 2);

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = this.Height;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            this.Region = new Region(gp);
            #region inner Rounded Rectangle

            System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            d = this.Height / 2;
            gp2.AddArc(r2.X, r2.Y, d, d, 180, 90);
            gp2.AddArc(r2.X + r2.Width - d, r2.Y, d, d, 270, 90);
            gp2.AddArc(r2.X + r2.Width - d, r2.Y + r2.Height - d, d, d, 0, 90);
            gp2.AddArc(r2.X, r2.Y + r2.Height - d, d, d, 90, 90);

            #endregion

            if (ipadx < contentRectangle.Width / 2)
                iosSelected = false;
            else if (ipadx == contentRectangle.Right - (contentRectangle.Height - 3) || ipadx > contentRectangle.Width / 2)
                iosSelected = true;


            Rectangle ar1 = new Rectangle(r.X, r.Y, r.X + rect.Right, r.Height);
            Rectangle ar2 = new Rectangle(rect.X + rect.Width / 2, r.Y, (rect.X + rect.Width / 2) + r.Right, r.Height);

            // br3 - inner rect
            LinearGradientBrush br3 = new LinearGradientBrush(ar1, this.InActiveColor, this.ActiveColor, LinearGradientMode.Vertical);

            //br - outer rect
            LinearGradientBrush br = new LinearGradientBrush(ar1, this.ActiveColor, this.ActiveColor, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(br, ar1);

            e.Graphics.FillPath(br3, gp2);


            #region Inactive path

            #region inner Rounded Rectangle

            r2 = new Rectangle((rect.X + rect.Width / 2), this.Height / 2, (((this.Width / 2) + (this.Width / 4)) - (rect.X + rect.Width / 2)) + this.Height / 2, this.Height / 2); //4 * (this.Width / 6) + 20
            gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            d = this.Height / 2;
            gp2.AddArc(r2.X, r2.Y, d, d, 180, 90);
            gp2.AddArc(r2.X + r2.Width - d, r2.Y, d, d, 270, 90);
            gp2.AddArc(r2.X + r2.Width - d, r2.Y + r2.Height - d, d, d, 0, 90);
            gp2.AddArc(r2.X, r2.Y + r2.Height - d, d, d, 90, 90);
            #endregion

            ////br - outer rect
            br3 = new LinearGradientBrush(ar2, Color.FromArgb(238, 238, 238), Color.LightGray, LinearGradientMode.Vertical);

            //br - outer rect
            br = new LinearGradientBrush(ar2, Color.FromArgb(238, 238, 238), Color.Silver, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(br, ar2);

            e.Graphics.FillPath(br3, gp2);


            #endregion

            if (iosSelected)
                e.Graphics.DrawString(this.ActiveText, Font, Brushes.White, new PointF(r.Width / 4, contentRectangle.Y + (contentRectangle.Height / 4)));
            else
                e.Graphics.DrawString(this.InActiveText, Font, new SolidBrush(Color.FromArgb(123, 123, 123)), new PointF(r.Width / 2, contentRectangle.Y + (contentRectangle.Height / 4)));



            #region Center Ellipse
            Color c = this.Parent != null ? this.Parent.BackColor : Color.White;
            e.Graphics.DrawEllipse(new Pen(Color.LightGray, 2f), rect);
            LinearGradientBrush br2 = new LinearGradientBrush(rect, Color.White, Color.Silver, LinearGradientMode.Vertical);
            e.Graphics.FillEllipse(br2, rect);
            #endregion

            e.Graphics.DrawPath(new Pen(c, 2f), gp);

            e.Graphics.ResetClip();
        }

        protected virtual void FillShape(Graphics g, Object brush, GraphicsPath path)
        {
            if (brush.GetType().ToString() == "System.Drawing.Drawing2D.LinearGradientBrush")
            {
                g.FillPath((LinearGradientBrush)brush, path);
            }
            else if (brush.GetType().ToString() == "System.Drawing.Drawing2D.PathGradientBrush")
            {
                g.FillPath((PathGradientBrush)brush, path);
            }
        }
        #endregion



        #region Event Handlers
        int tPadx; RectangleF staticInnerRect;


        bool iosSelected = false;

        bool dblclick = false;



        public event ToggleButtonStateChanged ButtonStateChanged;

        protected void RaiseButtonStateChanged()
        {
            if (this.ButtonStateChanged != null)
                ButtonStateChanged(this, new ToggleButtonStateEventArgs(this.ToggleState));
        }


        public delegate void ToggleButtonStateChanged(object sender, ToggleButtonStateEventArgs e);

        public class ToggleButtonStateEventArgs : EventArgs
        {
            public ToggleButtonStateEventArgs(ToggleButtonState ButtonState)
            {

            }

            //Arguements Can be Included
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            sliderPoint = downpos;
            dblclick = !dblclick;
            switchrec = !switchrec;
            if (this.ToggleStyle == ToggleButtonStyle.Windows)
            {
                if (WindowSliderBounds.X < (controlBounds.Width / 2))
                {
                    sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
                    this.ToggleState = ToggleButtonState.OFF;
                }
                else
                {
                    sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                    this.ToggleState = ToggleButtonState.ON;

                }
            }
            else if (this.ToggleStyle == ToggleButtonStyle.Android)
            {
                if (downpos.X <= contentRectangle.Width / 4)
                {
                    padx = contentRectangle.Left;
                    this.ToggleState = ToggleButtonState.OFF;
                }
                else
                {
                    padx = contentRectangle.Right - (contentRectangle.Width / 2);
                    this.ToggleState = ToggleButtonState.ON;
                }
            }
            else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
            {
                if (downpos.X <= contentRectangle.Width / 4)
                {
                    ipadx = 2;
                    this.ToggleState = ToggleButtonState.OFF;
                }
                else
                {
                    ipadx = ipadx = contentRectangle.Right - (contentRectangle.Height - 3);
                    this.ToggleState = ToggleButtonState.ON;
                }
            }
            else if (this.ToggleStyle == ToggleButtonStyle.Custom)
            {
                tPadx = downpos.X;
                if (tPadx <= (staticInnerRect.X + staticInnerRect.Width / 2))
                {
                    tPadx = (int)staticInnerRect.X;
                    this.ToggleState = ToggleButtonState.OFF;
                }
                else if (tPadx >= (staticInnerRect.X + staticInnerRect.Width / 2))
                {
                    tPadx = (int)staticInnerRect.Right - 20;
                    this.ToggleState = ToggleButtonState.ON;
                }
            }
            this.Refresh();
        }



        private Rectangle GetRectangle()
        {
            return new Rectangle(2, 2, this.Width - 5, this.Height - 5); ;
        }

        Point downpos = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.DesignMode)
            {
                downpos = e.Location;
            }
            this.Invalidate();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                if (this.ToggleState == ToggleButtonState.ON)
                    this.ToggleState = ToggleButtonState.OFF;
                else
                    this.ToggleState = ToggleButtonState.ON;
            }
        }
        bool isMouseMoved = false; Point sliderPoint = Point.Empty; int padx = 0; int ipadx = 2;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left && !this.DesignMode)
            {
                sliderPoint = e.Location;
                isMouseMoved = true;
                if (this.ToggleStyle == ToggleButtonStyle.Android)
                {

                    padx = e.X;
                    if (padx <= contentRectangle.Left + SlidingAngle)
                    {
                        padx = contentRectangle.Left;
                        this.ToggleState = ToggleButtonState.OFF;
                    }

                    if (padx >= contentRectangle.Right - (contentRectangle.Width / 2))
                    {
                        padx = contentRectangle.Right - (contentRectangle.Width / 2);
                        this.ToggleState = ToggleButtonState.ON;
                    }
                }
                else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
                {
                    ipadx = e.X;
                    if (ipadx <= 2)
                    {
                        ipadx = 2;
                        this.ToggleState = ToggleButtonState.OFF;
                    }

                    if (ipadx >= contentRectangle.Right - (contentRectangle.Height - 3))
                    {
                        ipadx = contentRectangle.Right - (contentRectangle.Height - 3);
                        this.ToggleState = ToggleButtonState.ON;
                    }
                }
                else if (this.ToggleStyle == ToggleButtonStyle.Custom)
                {
                    tPadx = e.X;
                    if (tPadx <= staticInnerRect.X)
                    {
                        tPadx = (int)staticInnerRect.X;
                        this.ToggleState = ToggleButtonState.OFF;
                    }

                    if (tPadx >= staticInnerRect.Right - 20)
                    {
                        tPadx = (int)staticInnerRect.Right - 20;
                        this.ToggleState = ToggleButtonState.ON;
                    }
                }
                Refresh();
            }
        }
        bool switchrec = false;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!this.DesignMode)
            {
                this.Invalidate();
                if (isMouseMoved)
                {
                    if (this.ToggleStyle == ToggleButtonStyle.Windows)
                    {
                        sliderPoint = e.Location;

                        if (WindowSliderBounds.X < (controlBounds.Width / 2))
                        {
                            sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
                            this.ToggleState = ToggleButtonState.OFF;
                        }
                        else
                        {
                            sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                            this.ToggleState = ToggleButtonState.ON;

                        }
                    }
                    else if (this.ToggleStyle == ToggleButtonStyle.Android)
                    {
                        padx = e.Location.X;
                        if (padx < contentRectangle.Width / 4)
                        {
                            padx = contentRectangle.Left;
                            this.ToggleState = ToggleButtonState.OFF;
                        }
                        else
                        {
                            padx = contentRectangle.Right - (contentRectangle.Width / 2);
                            this.ToggleState = ToggleButtonState.ON;
                        }
                    }
                    else if (this.ToggleStyle == ToggleButtonStyle.IOS || this.ToggleStyle == ToggleButtonStyle.Metallic)
                    {
                        ipadx = e.Location.X;
                        if (ipadx < contentRectangle.Width / 2)
                        {
                            ipadx = 2;
                            this.ToggleState = ToggleButtonState.OFF;
                        }
                        else
                        {
                            ipadx = contentRectangle.Right - (contentRectangle.Height - 3);
                            this.ToggleState = ToggleButtonState.ON;
                        }
                    }
                    else if (this.ToggleStyle == ToggleButtonStyle.Custom)
                    {
                        tPadx = e.Location.X;
                        if (tPadx <= (staticInnerRect.X + staticInnerRect.Width / 2))
                        {
                            tPadx = (int)staticInnerRect.X;//
                            this.ToggleState = ToggleButtonState.OFF;
                        }
                        else if (tPadx >= (staticInnerRect.X + staticInnerRect.Width / 2))
                        {
                            tPadx = (int)staticInnerRect.Right - 20;
                            this.ToggleState = ToggleButtonState.ON;
                        }
                    }
                    Invalidate();
                    Update();

                }

                isMouseMoved = false;
            }
        }
        #endregion

        #region properties
        private string activeText = "ON";
        public string ActiveText
        {
            get
            {
                return activeText;
            }
            set
            {
                activeText = value;
            }
        }

        private string inActiveText = "OFF";
        public string InActiveText
        {
            get
            {
                return inActiveText;
            }
            set
            {
                inActiveText = value;
            }
        }

        private int slidingAngle = 5;
        public int SlidingAngle
        {
            get
            {
                return slidingAngle;
            }
            set
            {
                slidingAngle = value;
                this.Refresh();
            }
        }


        private Color activeColor = Color.FromArgb(27, 161, 226);
        public Color ActiveColor
        {
            get
            {
                return activeColor;
            }
            set
            {
                activeColor = value;
                this.Refresh();
            }
        }

        private Color sliderColor = Color.Black;
        public Color SliderColor
        {
            get
            {
                return sliderColor;
            }
            set
            {
                sliderColor = value;
                this.Refresh();
            }
        }
        private Color textColor = Color.White;
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                this.Refresh();
            }
        }
        private Color inActiveColor = Color.FromArgb(70, 70, 70);
        public Color InActiveColor
        {
            get
            {
                return inActiveColor;
            }
            set
            {
                inActiveColor = value;
                this.Refresh();
            }
        }

        private ToggleButtonStyle toggleStyle = ToggleButtonStyle.Android;
        public ToggleButtonStyle ToggleStyle
        {
            get
            {
                return toggleStyle;
            }
            set
            {
                toggleStyle = value;
                switch (value)
                {
                    case ToggleButtonStyle.Android:
                        this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
                        this.BackColor = Color.FromArgb(32, 32, 32);
                        this.InActiveColor = Color.FromArgb(70, 70, 70);
                        this.SlidingAngle = 8;
                        break;
                    case ToggleButtonStyle.IOS:
                        this.InActiveColor = Color.WhiteSmoke;
                        break;
                }

                Invalidate(true);
                Update();
                this.Refresh();
            }

        }

        private ToggleButtonState toggleState = ToggleButtonState.OFF;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ToggleButtonState ToggleState
        {
            get
            {
                return toggleState;
            }
            set
            {
                if (toggleState != value)
                {
                    RaiseButtonStateChanged();
                    toggleState = value;
                    Invalidate();
                    this.Refresh();
                }
            }

        }

        private void RefreshToggleState(ToggleButtonState state)
        {
            this.ToggleState = state;
        }
        public enum ToggleButtonState
        {
            ON,
            OFF
        }


        public enum ToggleButtonStyle
        {
            Android,
            Windows,
            IOS,
            Custom,
            Metallic
        }
        #endregion

        #region Other
        public static FileInfo FindApplicationFile(string fileName)
        {
            string startPath = Path.Combine(Application.StartupPath, fileName);
            FileInfo file = new FileInfo(startPath);
            while (!file.Exists)
            {
                if (file.Directory.Parent == null)
                {
                    return null;
                }
                DirectoryInfo parentDir = file.Directory.Parent;
                file = new FileInfo(Path.Combine(parentDir.FullName, file.Name));
            }
            return file;
        }

        #endregion
    }

}
