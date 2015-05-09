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

namespace Moonshine.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class Panel : Control, ITransparentControl
    {
        public Color BackColor;

        /// <summary>
        /// Gets or sets the transparency of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public int Transparency { get; set; }

        /// <summary>
        /// Creates a new instance of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public Panel (bool stretch = false) : base ()
        {
            Transparency = 255;
            BackColor = new Color (255, 255, 255);
            if (stretch)
            {
                Stretch ();
            }
        }

        public void SetBackground (Texture2D tex)
        {
            use_bitmap = false;
            background = tex;
        }

        public void UnsetBackground ()
        {
            use_bitmap = true;
            bmp.Dispose ();
            bmp = null;
            background = null;
        }

        public bool use_bitmap = true;
        private drw.Bitmap bmp = null;
        private Texture2D background;

        private int width;
        private int height;
        public override int Width { get { return width; } set { width = value; _stretch = false; } }
        public override int Height { get { return height; } set { height = value; _stretch = false; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public override void Update (GameTime t)
        {
            if (_stretch)
            {
                Position = new Vector2 (0, 0);
                width = GraphicsDevice.Viewport.Width;
                height = GraphicsDevice.Viewport.Height;
            }

            if (use_bitmap && bmp == null)
            {
                bmp = new drw.Bitmap (Width, Height);

                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        bmp.SetPixel (i, j, drw.Color.FromArgb (255, BackColor.R, BackColor.G, BackColor.B));
                    }
                }

                background = GetBackground ();
            }

            base.Update (t);
        }

        bool _stretch = false;
        /// <summary>
        /// Stretches the panel to fit the window
        /// </summary>
        public void Stretch ()
        {
            _stretch = true;
        }

        private Texture2D GetBackground ()
        {
            int bufsz = bmp.Width * bmp.Height * 4;

            Texture2D tmp;
            using (MemoryStream ms = new MemoryStream (bufsz))
            {
                bmp.Save (ms, drw.Imaging.ImageFormat.Png);
                tmp = Texture2D.FromStream (GraphicsDevice, ms);
            }

            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        public override void Render (GameTime t, SpriteBatch b)
        {
            if (background != null)
                b.Draw (background, Bounds, Color.FromNonPremultiplied (BackColor.R, BackColor.G, BackColor.B, Transparency));

            base.Render (t, b);
        }
    }
}