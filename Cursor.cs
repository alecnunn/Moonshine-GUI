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

using Moonshine.gui.Input;

namespace Moonshine.gui
{
    /// <summary>
    /// A control which acts as a cursor
    /// </summary>
    public class Cursor : Control
    {
        private Texture2D texture;
        private Texture2D texture_hot;

        private Color tinting;
        private Color hot_tinting;

        private bool hot;
        private bool use_hot_texture;

        /// <summary>
        /// Creates a new instance of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public Cursor () : base ()
        {
            texture = null;
            texture_hot = null;
            use_hot_texture = false;
            tinting = Color.White;
            hot_tinting = Color.White;
            hot = false;
            Priority = DrawPriority.CursorForeground;
        }

        public Cursor (Point hotspot) : this ()
        {
            SetHotspot (hotspot.X, hotspot.Y);
        }

        /// <summary>
        /// Specifies the texture to use as cursor
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="hot"></param>
        /// <param name="center_hotspot">Should the hotspot be set to the center of the texture? (Default: false)</param>
        public void SetTexture (Texture2D tex, bool hot = false, bool center_hotspot = false)
        {
            if (hot)
            {
                texture_hot = tex;
                use_hot_texture = true;
            }
            else
                texture = tex;

            if (texture == null || texture_hot == null)
            {
                MouseHandler.Size = new Point (tex.Width, tex.Height);
                Width = tex.Width;
                Height = tex.Height;
            }
            else
            {
                Width = Math.Max (texture.Width, texture_hot.Width);
                Height = Math.Max (texture.Height, texture_hot.Height);
            }

            if (center_hotspot)
                SetHotspot (tex.Width / 2, tex.Height / 2);
        }

        /// <summary>
        /// Unsets the cursor texture
        /// </summary>
        /// <param name="hot"></param>
        public void UnsetTexture (bool hot = false)
        {
            if (hot)
            {
                texture_hot = null;
                use_hot_texture = false;
            }
            else
                texture = null;
        }

        /// <summary>
        /// Changes the appearance of the cursor using tinting
        /// </summary>
        /// <param name="tint"></param>
        /// <param name="hot"></param>
        public void SetTinting (Color tint, bool hot = false)
        {
            if (hot)
                hot_tinting = tint;
            else
                tinting = tint;
        }

        /// <summary>
        /// Unsets the tinting
        /// </summary>
        public void UnsetTinting (bool hot = false)
        {
            if (hot)
                hot_tinting = Color.White;
            else
                tinting = Color.White;
        }

        /// <summary>
        /// Sets the hotspot to match the cursor texture
        /// </summary>
        /// <param name="x">The x corrdinate relative to the left</param>
        /// <param name="y">The y coordinate relative to the top</param>
        public void SetHotspot (int x, int y)
        {
            MouseHandler.Hotspot = new Point (x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public override void Update (GameTime t)
        {
            Position = new Vector2(MouseHandler.Position.X, MouseHandler.Position.Y);

            if (MouseHandler.state.LeftButton == ButtonState.Pressed)
                hot = true;
            else
                hot = false;

            base.Update (t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        public override void Render (GameTime t, SpriteBatch b)
        {
            Texture2D tex = use_hot_texture? hot? texture_hot == null? null : texture_hot : texture == null? null : texture : texture == null? null : texture;
            if (tex != null)
            {
                b.Draw (tex, Bounds, hot? hot_tinting : tinting);
            }

            base.Render (t, b);
        }
    }
}
