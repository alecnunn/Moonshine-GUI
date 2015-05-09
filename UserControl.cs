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
    /// <summary>
    /// All user controls should be derived from this class
    /// </summary>
    public class UserControl : IControl
    {
        public GraphicsDevice GraphicsDevice { get; set; }

        public DrawPriority Priority { get; set; }

        /// <summary>
        /// A List of all <see cref="Moonshine.gui.Control"/>s
        /// </summary>
        public List<IControl> ControlCollection;

        public UserControl ()
        {
            GUI.RequestGraphicsDevice (this);
            ControlCollection = new List<IControl> ();
            Priority = DrawPriority.Normal;
        }

        public void Add (IControl c)
        {
            ControlCollection.Add (c);
            ControlCollection = ControlCollection.OrderBy ((ctrl) => ctrl.Priority).ToList ();
        }

        public void Add (params IControl[] controls)
        {
            controls.All ((c) => { Add (c); return true; });
        }

        /// <summary>
        /// Get or set the Visibility of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Enable or disable the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Returns if the <see cref="Moonshine.gui.Control"/> is currently focused
        /// </summary>
        public bool Focused
        {
            get { throw new NotImplementedException (); }
        }

        /// <summary>
        /// Gets or sets the position of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the width of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets the bounds of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle ((int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        public virtual void Center ()
        {
            float x = (float)((float)((float)GraphicsDevice.Viewport.Width / 2f) - (float)(Width / 2));
            float y = (float)((float)((float)GraphicsDevice.Viewport.Height / 2f) - (float)(Height / 2));
            Position = new Vector2 (x, y);
        }

        public virtual void HCenter ()
        {
            float x = (float)((float)((float)GraphicsDevice.Viewport.Width / 2f) - (float)(Width / 2));
            Position = new Vector2 (x, Position.Y);
        }

        public virtual void VCenter ()
        {
            float y = (float)((float)((float)GraphicsDevice.Viewport.Height / 2f) - (float)(Height / 2));
            Position = new Vector2 (Position.X, y);
        }

        /// <summary>
        /// Gets or sets the text of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Updates the relevant variables
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        public virtual void Update (GameTime t)
        {
            for (int i = 0; i < ControlCollection.Count; i++)
            {
                ControlCollection[i].Update (t);
            }
        }

        /// <summary>
        /// Draws the <see cref="Moonshine.gui.Control"/> on the screen
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        /// <param name="b">The SpriteBatch, which will be used to draw the <see cref="Moonshine.gui.Control"/></param>
        public virtual void Render (GameTime t, SpriteBatch b)
        {
            for (int i = 0; i < ControlCollection.Count; i++)
            {
                ControlCollection[i].Render (t, b);
            }
        }
    }
}
