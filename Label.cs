using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using drw = System.Drawing;
using System.IO;
using Moonshine.gui.Misc;
using Moonshine.gui.Input;
using Moonshine.gui.Extensions;

namespace Moonshine.gui
{
    public class Label : Control
    {
        public Label (string rgb = "", string rgba = "", TextAlign align = TextAlign.undefined, string text = "") : base ()
        {
            Text = text;
            Priority = DrawPriority.Foreground;
            Color = Color.Black;
            _align = align;
            if (rgb != "")
                Color = ColorExtensions.FromRgbString (rgb);
            if (rgba != "")
                Color = ColorExtensions.FromRgbaString (rgba);
            GUI.onGraphicsDeviceReset (new EventHandler<EventArgs> ((o, e) => text_set = false));
        }

        private TextAlign _align;
        public void Align (TextAlign align)
        {
            _align = align;
        }

        public override string Text { get { return base.Text; } set { base.Text = value; text_set = false; } }
        public void SetText (string text)
        {
            Text = text;
        }

        public void SetTransparency (int a)
        {
            Color = Color.FromNonPremultiplied (Color.R, Color.G, Color.B, a);
        }

        public Color Color { get; set; }
        public void SetColor (Color color)
        {
            Color = color;
        }

        public void SetColor (int r, int g, int b)
        {
            Color = Color.FromNonPremultiplied (r, g, b, 255);
        }

        public void SetColor (int r, int g, int b, int a)
        {
            Color = Color.FromNonPremultiplied (r, g, b, a);
        }

        public void SetColorArgb (int a, int r, int g, int b)
        {
            SetColor (r, g, b, a);
        }

        public void SetColorRgba (int r, int g, int b, int a)
        {
            SetColor (r, g, b, a);
        }

        private SpriteFont font = null;
        public void SetFont (SpriteFont _font)
        {
            font = _font;
        }

        private bool text_set = false;
        public override void Update (GameTime t)
        {
            if (font != null && !text_set && _align != TextAlign.undefined)
            {
                Vector2 vect = font.MeasureString (Text);

                Width = (int)vect.X;
                Height = (int)vect.Y;

                text_set = true;

                int w = GraphicsDevice.Viewport.Width;
                int h = GraphicsDevice.Viewport.Height;

                switch (_align)
                {
                    case TextAlign.TopLeft:
                        Position = new Vector2 (6, 0);
                        break;
                    case TextAlign.TopCenter:
                        Position = new Vector2 (((float)w / 2f) - ((float)Width / 2f), 0);
                        break;
                    case TextAlign.TopRight:
                        Position = new Vector2 (w - Width - 6, 0);
                        break;
                    case TextAlign.MidLeft:
                        Position = new Vector2 (6, ((float)h / 2f) - ((float)Height / 2f));
                        break;
                    case TextAlign.MidCenter:
                        Position = new Vector2 (((float)w / 2f) - ((float)Width / 2f), ((float)h / 2f) - ((float)Height / 2f));
                        break;
                    case TextAlign.MidRight:
                        Position = new Vector2 (w - Width, ((float)h / 2f) - ((float)Height / 2f));
                        break;
                    case TextAlign.BotLeft:
                        Position = new Vector2 (6, h - Height);
                        break;
                    case TextAlign.BotCenter:
                        Position = new Vector2 (((float)w / 2f) - ((float)Width / 2f), h - Height);
                        break;
                    case TextAlign.BotRight:
                        Position = new Vector2 (w - Width - 6, h - Height);
                        break;
                }

                text_set = true;
            }

            base.Update (t);
        }

        public override void Render (GameTime t, SpriteBatch b)
        {
            if (font != null)
                b.DrawString (font, Text, Position, Color);

            base.Render (t, b);
        }
    }
}
