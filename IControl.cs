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
    /// You should use the <see cref="Moonshine.gui.Control"/> class!
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Gets or sets the GraphicsDevice of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        GraphicsDevice GraphicsDevice { get; set; }

        /// <summary>
        /// Gets or sets the draw priority of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        DrawPriority Priority { get; set; }

        /// <summary>
        /// Get or set the visibility of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Enable or disable the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Returns if the <see cref="Moonshine.gui.Control"/> is currently focused
        /// </summary>
        bool Focused { get; }

        /// <summary>
        /// Gets or sets the Text of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the width of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets the position of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Gets the bounds of the <see cref="Moonshine.gui.Control"/>
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Updates the relevant variables
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        void Update (GameTime t);

        /// <summary>
        /// Draws the <see cref="Moonshine.gui.Control"/> on the screen
        /// </summary>
        /// <param name="t">The GameTime, which will be used for animation purposes</param>
        /// <param name="b">The SpriteBatch, which will be used to draw the <see cref="Moonshine.gui.Control"/></param>
        void Render (GameTime t, SpriteBatch b);
    }
}
