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

namespace Moonshine.gui
{
    public class VPanel : UserControl
    {
        public VPanel (bool center = false, int padding = 10, int margin = 20) : base ()
        {
            Padding = padding;
            Margin = margin;
            if (center)
                Center ();
        }

        public int Padding;
        public int Margin;
        public Texture2D Background = null;

        public void SetBackground (Texture2D tex)
        {
            Background = tex;
        }

        int _height = 0;
        public override void Update (GameTime t)
        {
            _height = Padding;
            for (int i = 0; i < ControlCollection.Count; i++)
            {
                ControlCollection[i].Width = Width;
                ControlCollection[i].Position = new Vector2 (Position.X, Position.Y + _height);
                _height += ControlCollection[i].Height;
                _height += Padding;
            }
            Height = _height;

            if (_center)
                base.Center ();

            base.Update (t);
        }

        public override void Render (GameTime t, SpriteBatch b)
        {
            if (Background != null)
            {
                Rectangle rect = Bounds;
                rect.Inflate (Padding + Margin, Margin);
                b.Draw (Background, rect, Color.White);
            }

            base.Render (t, b);
        }

        private bool _center = false;
        public override void Center ()
        {
            _center = true;
        }
    }
}
