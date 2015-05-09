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

namespace Moonshine.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class Button : Control, ITransparentControl, IAnimatableControl
    {
        /// <summary>
        /// Gets or sets the transparency of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public int Transparency { get; set; }

        public SortedList<string, Animator> animators { get; set; }

        public delegate void ButtonClicked ();
        public event ButtonClicked onButtonClicked;

        /// <summary>
        /// Creates a new instance of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public Button () : base ()
        {
            Transparency = 255;
            animators = new SortedList<string, Animator> ();
            Text = "";
            onButtonClicked += new ButtonClicked (() => { });
        }

        private Texture2D background = null;
        private Texture2D background_active = null;
        public void SetTexture (Texture2D _background)
        {
            background = _background;
            if (background_active == null)
                background_active = _background;
        }

        public void SetTexture (Texture2D _background, Texture2D _background_active)
        {
            background = _background;
            background_active = _background_active;
        }

        private SpriteFont font = null;
        public void SetFont (SpriteFont _font)
        {
            font = _font;
        }

        public bool MouseIntersects
        {
            get
            {
                return (Bounds.Intersects (new Rectangle (MouseHandler.Position.X + MouseHandler.Hotspot.X, MouseHandler.Position.Y + MouseHandler.Hotspot.Y, 1, 1)));
            }
        }

        private string _text;
        private bool _textlocked;
        private bool _hot = false;

        public override void Update (GameTime t)
        {
            if (MouseIntersects)
            {
                _hot = true;

                if (!_textlocked)
                {
                    _text = Text;
                    Text = "[" + Text + "]";
                    _textlocked = true;
                }

                if (MouseHandler.state.LeftButton == ButtonState.Pressed)
                {
                    onButtonClicked ();
                }
            }
            else
            {
                _hot = false;

                if (_textlocked)
                {
                    Text = _text;
                    _textlocked = false;
                }
            }

            base.Update (t);
        }

        public Vector2 TextPosition
        {
            get
            {
                Vector2 vect = font.MeasureString (Text);
                float w = Position.X + (float)((float)Width / 2f) - (float)((float)vect.X / 2f);
                float h = Position.Y + (float)((float)Height / 2f) - (float)((float)vect.Y / 2f);
                return new Vector2 (w, h);
            }
        }
        
        public void SetSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void Render (GameTime t, SpriteBatch b)
        {
            if (!_hot && background != null)
                b.Draw (background, Bounds, Color.White);
            else if (_hot && background_active != null)
                b.Draw (background_active, Bounds, Color.White);
            else if (_hot && background != null)
                b.Draw (background, Bounds, Color.White);

            if (font != null)
                b.DrawString (font, Text, TextPosition, Color.White);

            base.Render (t, b);
        }
    }
}