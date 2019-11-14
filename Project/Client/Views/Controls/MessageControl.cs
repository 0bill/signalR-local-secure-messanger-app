﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client.Views.Controls
{
    public partial class MessageControl : FlowLayoutPanel
    {
        private List<MessageShape> Messages { get; set; }

        private Color _leftBoxColor = Color.FromArgb(217, 217, 217);
        private Color _rightBoxColor = Color.FromArgb(192, 206, 215);
        private Color _leftBoxTextColor = Color.FromArgb(52, 52, 52);
        private Color _rightBoxTextColor = Color.FromArgb(52, 52, 52);
        private int _boxIndent = 60;

        public enum BoxPositionEnum
        {
            Left,
            Right
        }

        public Color LeftBoxColor
        {
            get { return _leftBoxColor; }
            set { _leftBoxColor = value; }
        }

        public Color RightBoxColor
        {
            get { return _rightBoxColor; }
            set { _rightBoxColor = value; }
        }

        public Color LeftBoxTextColor
        {
            get { return _leftBoxTextColor; }
            set { _leftBoxTextColor = value; }
        }

        public Color RightBoxTextColor
        {
            get { return _rightBoxTextColor; }
            set { _rightBoxTextColor = value; }
        }

        public int BoxIndent
        {
            get { return _boxIndent; }
            set { _boxIndent = value; }
        }



        public MessageControl()
        {
            InitializeComponent();

            this.Messages = new List<MessageShape>();
            this.SetStyle(
               ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.BackColor = Color.Green;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.AutoScroll = true; 
        }

        public void Add(string message, DateTime dateTime, BoxPositionEnum position)
        {
            MessageShape b = new MessageShape(this, message, dateTime, position);
            b.Width = this.ClientSize.Width;
            Messages.Add(b);
            this.Controls.Add(b);
            b.Select();
            b.Refresh();
            this.ScrollControlIntoView(b);
        }
        
        protected override void OnLayout(LayoutEventArgs levent)
        {
            this.ResizeMessages();
            base.OnLayout(levent);
        }

        protected override void OnResize(System.EventArgs e)
        {
            this.ResizeMessages();
            base.OnResize(e);
        }

        private void ResizeMessages()
        {
            this.SuspendLayout();
            foreach (MessageShape m in this.Messages)
            {
                m.Width = this.ClientSize.Width - 9;
            }
            this.ResumeLayout();
        }

        public sealed class MessageShape : Control
        {
            private MessageControl _mc;
            private GraphicsPath Shape;
            private Color _TextColor = Color.FromArgb(52, 52, 52);
            private Color _BoxColor = Color.FromArgb(217, 217, 217);
            private BoxPositionEnum _BoxPosition = BoxPositionEnum.Left;
            private DateTime dateTime;

            public override Color ForeColor
            {
                get { return this._TextColor; }
                set
                {
                    this._TextColor = value;
                    this.Invalidate();
                }
            }

            public BoxPositionEnum BoxPosition
            {
                get { return this._BoxPosition; }
                set
                {
                    this._BoxPosition = value;
                    this.Invalidate();
                }
            }

            public Color BoxColor
            {
                get { return this._BoxColor; }
                set
                {
                    this._BoxColor = value;
                    this.Invalidate();
                }
            }

            private MessageShape()
            {
            }

            public MessageShape(MessageControl mc, string Message, DateTime dateTime, BoxPositionEnum Position)
            {
                if (mc == null) throw new ArgumentNullException(nameof(mc));
                this.SetStyle(
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint,
                    true);
                this.UpdateStyles();

                this._mc = mc;
                this.dateTime = dateTime;
                this._BoxPosition = Position;
                this.Text = Message;
                this.BoxColor = (Position == BoxPositionEnum.Right ? mc.RightBoxColor : mc.LeftBoxColor);
                this.BackColor = this.BoxColor;
                this.ForeColor = (Position == BoxPositionEnum.Right ? mc.RightBoxTextColor : mc.LeftBoxTextColor);
                this.Font = new Font("Segoe UI", 10);

                this.Size = new Size(152, 5);
                this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
              
            }

            protected override void OnResize(System.EventArgs e)
            {
                base.OnResize(e);

                Shape = new GraphicsPath();
                if (BoxPosition == BoxPositionEnum.Left)
                {
                    //x,y => x,y

                    var space = this._mc.BoxIndent - this._mc.BoxIndent + 5;
                    var boxWidth = Width - this._mc.BoxIndent;
                    Shape.AddLine(space, 0, boxWidth, 0); //top
                    Shape.AddLine(boxWidth, 0, boxWidth, Height); // right
                    Shape.AddLine(boxWidth, Height, space, Height); // bottom
                    Shape.AddLine(space, Height, space, 0); // left
                }
                else
                {
                    var boxWidth = Width - 18;
                    var space = this._mc.BoxIndent;

                    Shape.AddLine(space, 0, boxWidth, 0); //top
                    Shape.AddLine(boxWidth, 0, boxWidth, Height); // right
                    Shape.AddLine(boxWidth, Height, space, Height); // bottom
                    Shape.AddLine(space, Height, space, 0); // left
                }


                Shape.CloseAllFigures();
                this.Region = new Region(Shape);

                this.Invalidate();
                this.Refresh();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                
                var graphics = e.Graphics;
                int renderWidth = Width - 10 - _mc.BoxIndent;
                SizeF s = graphics.MeasureString(Text, Font, renderWidth);
                this.Height = (int) (Math.Floor(s.Height) * 2 + 10);
                
                

                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    if (_BoxPosition == BoxPositionEnum.Left)
                    {
                        graphics.DrawString(dateTime.ToString(), Font, brush, new Rectangle(20, 4, renderWidth - 5, Height / 2 - 5));
                        
                    }
                    else
                    {
                        StringFormat format = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Far
                        };
                        graphics.DrawString(dateTime.ToString(), Font, brush,
                            new Rectangle(_mc.BoxIndent - 10 , 4, renderWidth - 5, Height / 2 -5),format);
                    }
                }

                //Text Rectangle
                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    if (_BoxPosition == BoxPositionEnum.Left)
                    {
                        
                        graphics.DrawString(Text, Font, brush, new Rectangle(20 , Height / 2, renderWidth - 5, Height / 2 - 5));
                    }
                    else
                    {
                        StringFormat format = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Far
                        };
                        graphics.DrawString(Text, Font, brush,
                            new Rectangle(_mc.BoxIndent - 10 , Height / 2, renderWidth - 5, Height / 2 - 5),format);
                        
                    }
                }
                

            }
        }
    }
}