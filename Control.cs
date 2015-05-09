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
    /// All controls should be derived from this class
    /// </summary>
    public class Control : IControl
    {
        public GraphicsDevice GraphicsDevice { get; set; }

        public DrawPriority Priority { get; set; }

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
        public virtual int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public virtual int Height { get; set; }

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

        public Control ()
        {
            GUI.RequestGraphicsDevice (this);
            Priority = DrawPriority.Normal;
        }

        public void Center ()
        {
            float x = (float)((float)((float)GraphicsDevice.Viewport.Width / 2f) - (float)(Width / 2));
            float y = (float)((float)((float)GraphicsDevice.Viewport.Height / 2f) - (float)(Height / 2));
            Position = new Vector2 (x, y);
        }

        public void HCenter ()
        {
            float x = (float)((float)((float)GraphicsDevice.Viewport.Width / 2f) - (float)(Width / 2));
            Position = new Vector2 (x, Position.Y);
        }

        public void VCenter ()
        {
            float y = (float)((float)((float)GraphicsDevice.Viewport.Height / 2f) - (float)(Height / 2));
            Position = new Vector2 (Position.X, y);
        }

        public void SetPriority (DrawPriority priority)
        {
            Priority = priority;
        }

        /// <summary>
        /// Gets or sets the text of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Updates the relevant variables
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        public virtual void Update (GameTime t)
        {
            
        }

        /// <summary>
        /// Draws the <see cref="Moonshine.gui.Control"/> on the screen
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        /// <param name="b">The SpriteBatch, which will be used to draw the <see cref="Moonshine.gui.Control"/></param>
        public virtual void Render (GameTime t, SpriteBatch b)
        {
            
        }
    }
}
