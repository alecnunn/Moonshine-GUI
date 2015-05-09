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

namespace Moonshine.gui.Misc
{
    public class Animator
    {
        private float val;

        private float min;
        private float max;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Animator (int a, int b)
        {
            min = Math.Min (a, b);
            max = Math.Max (a, b);
        }

        public Animator (uint a, uint b)
        {
            min = (float)(int)Math.Min (a, b);
            max = (float)(int)Math.Max (a, b);
        }

        public Animator (float a, float b)
        {
            min = (float)Math.Min (a, b);
            max = (float)Math.Max (a, b);
        }

        public Animator (double a, double b)
        {
            min = (float)Math.Min (a, b);
            max = (float)Math.Max (a, b);
        }

        public static KeyValuePair<string, Animator> Create (string name, int a, int b)
        {
            return new KeyValuePair<string, Animator> (name, new Animator (a, b));
        }

        public static KeyValuePair<string, Animator> Create (string name, uint a, uint b)
        {
            return new KeyValuePair<string, Animator> (name, new Animator (a, b));
        }

        public static KeyValuePair<string, Animator> Create (string name, float a, float b)
        {
            return new KeyValuePair<string, Animator> (name, new Animator (a, b));
        }

        public static KeyValuePair<string, Animator> Create (string name, double a, double b)
        {
            return new KeyValuePair<string, Animator> (name, new Animator (a, b));
        }

        public float Value
        {
            get
            {
                return val;
            }
            set
            {
                if (value >= min && value <= max)
                {
                    val = value;
                }
                else
                {
                    throw new Exception (string.Format ("The value:{0} must be between min:{1} and max:{2}", value, min, max));
                }
            }
        }

        public void SetValue (int value)
        {
            Value = (float)value;
        }

        public void SetValue (uint value)
        {
            Value = (float)(int)value;
        }

        public void SetValue (float value)
        {
            Value = value;
        }

        public void SetValue (double value)
        {
            Value = (float)value;
        }

        public int GetInt ()
        {
            return (int)val;
        }

        public uint GetUint ()
        {
            return (uint)val;
        }

        public float GetFloat ()
        {
            return (float)val;
        }

        public double GetDouble ()
        {
            return (double)val;
        }

        private GameTime gameTime = null;
        public void Update (GameTime t)
        {
            gameTime = t;
        }

        public void Increment ()
        {
            float tmp = val + 1f;
            if (tmp >= min && tmp <= max)
                val++;
            else
                throw new Exception (string.Format ("The value:{0} must be between min:{1} and max:{2}", val, min, max));
        }

        public void IncrementBy (int x)
        {
            while (x > 0)
            {
                Increment ();
                x--;
            }
        }

        public void IncrementIfTicks (Func<long, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Ticks))
                Increment ();
        }

        public void IncrementIfMilliseconds (Func<int, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Milliseconds))
                Increment ();
        }

        public void IncrementIfSeconds (Func<int, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Seconds))
                Increment ();
        }

        public void Decrement ()
        {
            float tmp = val - 1f;
            if (tmp >= min && tmp <= max)
                val--;
            else
                throw new Exception (string.Format ("The value:{0} must be between min:{1} and max:{2}", val, min, max));
        }

        public void DecrementBy (int x)
        {
            while (x > 0)
            {
                Decrement ();
                x--;
            }
        }

        public void DecrementIfTicks (Func<long, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Ticks))
                Decrement ();
        }

        public void DecrementIfMilliseconds (Func<int, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Milliseconds))
                Decrement ();
        }

        public void DecrementIfSeconds (Func<int, bool> predicate)
        {
            if (predicate (gameTime.ElapsedGameTime.Seconds))
                Decrement ();
        }
    }
}
