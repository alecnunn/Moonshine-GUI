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

namespace Moonshine.gui.Misc
{
    /// <summary>
    /// Pure awesomeness.
    /// </summary>
    public static class KeyHelper
    {
        private static SortedList<Keys, bool> locked;
        private static KeyboardState ks;

        /// <summary>
        /// Instantiates the needed variables
        /// </summary>
        static KeyHelper ()
        {
            locked = new SortedList<Keys, bool> ();
            ks = new KeyboardState ();
        }

        /// <summary>
        /// Watches a specific key
        /// </summary>
        /// <param name="key"></param>
        public static void WatchKey (Keys key)
        {
            locked.Add (key, false);
        }

        /// <summary>
        /// Updates the key states
        /// </summary>
        public static void Update ()
        {
            ks = Keyboard.GetState ();

            for (int i = 0; i < locked.Count; i++)
            {
                Keys key = locked.Keys[i];
                if (ks.IsKeyDown (key))
                {
                    if (locked[key] == false)
                        locked[key] = true;
                }
                else
                {
                    if (locked[key] == true)
                        locked[key] = false;
                }
            }
        }

        /// <summary>
        /// Checks if the specific key is pressed
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyPressed (Keys key)
        {
            if (ks.IsKeyDown (key) && locked.ContainsKey (key) && !locked[key])
                return true;
            return false;
        }
    }
}
