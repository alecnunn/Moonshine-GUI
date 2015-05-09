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
using System.Reflection;
using Moonshine.gui.Input;

namespace Moonshine.gui
{
    /// <summary>
    /// The GUI Manager
    /// You should only keep a single instance of this class.
    /// Use the reset method to delete all <see cref="Moonshine.gui.Control"/>s
    /// </summary>
    public static class GUI
    {
        /// <summary>
        /// A List of all <see cref="Moonshine.gui.Control"/>s
        /// </summary>
        public static List<IControl> ControlCollection;

        /// <summary>
        /// Creates a new instance of the GUI
        /// </summary>
        static GUI ()
        {
            ControlCollection = new List<IControl> ();
            // UserControlCollection = new List<UserControl> ();
        }

        public static GraphicsDevice graphicsDevice;

        public static void Init (GraphicsDevice gd)
        {
            graphicsDevice = gd;
            MouseHandler.Initialize (gd);
        }

        public static void onGraphicsDeviceReset (EventHandler<EventArgs> action)
        {
            graphicsDevice.DeviceReset += action;
        }

        public static void RequestGraphicsDevice (Control c)
        {
            c.GraphicsDevice = graphicsDevice;
        }

        public static void RequestGraphicsDevice (UserControl c)
        {
            c.GraphicsDevice = graphicsDevice;
        }

        public static void Add (IControl c)
        {
            ControlCollection.Add (c);
            ControlCollection = ControlCollection.OrderBy ((ctrl) => ctrl.Priority).ToList ();
        }

        public static void Add (params IControl[] controls)
        {
            //Removed 
            controls.All ((c) => { Add (c); return true; });
        }

        /// <summary>
        /// Removes a <see cref="Moonshine.gui.Control"/> from the <see cref="ControlCollection"/>
        /// </summary>
        /// <param name="c"></param>
        public static void Remove (Control c)
        {
            for (int i = 0; i < ControlCollection.Count; i++)
            {
                if (ControlCollection[i] == c)
                {
                    ControlCollection.RemoveAt (i);
                }
            }
        }

        /// <summary>
        /// This version of the Update function will prevent animations from working!
        /// You should use Update (GameTime t)
        /// </summary>
        public static void Update ()
        {
            Update (new GameTime ());
        }

        /// <summary>
        /// Updates all <see cref="Moonshine.gui.Control"/>s.
        /// This function must be called in the Update function of your game.
        /// </summary>
        /// <param name="t"></param>
        public static void Update (GameTime t)
        {
            MouseHandler.Update ();
            KeyboardHandler.Update (t);

            for (int i = 0; i < ControlCollection.Count; i++)
            {
                ControlCollection[i].Update (t);
            }
        }

        /// <summary>
        /// This version of the Render function will prevent animations from working!
        /// You should use Render (GameTime t, SpriteBatch b)
        /// </summary>
        /// <param name="b"></param>
        public static void Render (SpriteBatch b)
        {
            Render (new GameTime (), b);
        }

        /// <summary>
        /// Draws all <see cref="Moonshine.gui.Control"/>s on the screen
        /// This function must be called in the Render function of your game.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="b"></param>
        public static void Render (GameTime t, SpriteBatch b)
        {
            for (int i = 0; i < ControlCollection.Count; i++)
            {
                ControlCollection[i].Render (t, b);
            }
        }

        /// <summary>
        /// Removes all <see cref="Moonshine.gui.Control"/>s
        /// </summary>
        public static void Reset ()
        {
            ControlCollection.Clear ();
        }
    }
}
