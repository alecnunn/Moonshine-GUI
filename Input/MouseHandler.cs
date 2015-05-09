using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonshine.gui.Input
{
    public static class MouseHandler
    {
        public static MouseState state;
        public static bool LockMouse;

        public static Point Hotspot;
        public static Point Position;
        public static Point Size;

        private static Point speed;
        public static Point Speed
        {
            get 
            { 
                return speed; 
            }
            set
            {
                speed = value; realSpeed = value;
            }
        }

        private static Point center;
        private static Point delta;
        private static Point current;
        private static Point previous;
        private static Point realSpeed;
        private static bool speedset;

        private static GraphicsDevice device;

        static MouseHandler ()
        {
            state = new MouseState ();
            LockMouse = false;

            Hotspot = new Point (0, 0);
            Position = new Point (0, 0);
            Size = new Point (1, 1);
            center = new Point (0, 0);
            delta = new Point (0, 0);
            current = new Point (0, 0);

            Speed = new Point (100, 100);
            speedset = false;
        }

        /// <summary>
        /// Initializes the static <see cref="Moonshine.gui.Input.MouseHandler"/> class
        /// </summary>
        /// <param name="dev"></param>
        public static void Initialize (GraphicsDevice dev)
        {
            device = dev;

            center = new Point (device.Viewport.Width / 2, device.Viewport.Height / 2);
            Mouse.SetPosition (center.X, center.Y);

            previous = center;
            Position = center;
        }

        /// <summary>
        /// Updates the position of the mouse
        /// </summary>
        public static void Update ()
        {
            state = Mouse.GetState ();

            if (LockMouse)
            {
                center = new Point (device.Viewport.Width / 2, device.Viewport.Height / 2);

                current = new Point (state.X, state.Y);
                delta = new Point (center.X - state.X, center.Y - state.Y);

                float speedX = (float)Speed.X / 100f;
                float speedY = (float)Speed.Y / 100f;
                delta = new Point ((int)(delta.X * speedX), (int)(delta.Y * speedY));

                Position = new Point (Position.X - delta.X, Position.Y - delta.Y);
                Mouse.SetPosition (center.X, center.Y);

                if (Position.X < 0)
                    Position.X = 0;

                else if (Position.X > device.Viewport.Width - Size.X)
                    Position.X = device.Viewport.Width - Size.X;

                if (Position.Y < 0)
                    Position.Y = 0;

                else if (Position.Y > device.Viewport.Height - Size.Y)
                    Position.Y = device.Viewport.Height - Size.Y;
            }
            else
            {
                if (speedset)
                {
                    delta = new Point (previous.X - state.X, previous.Y - state.Y);

                    float speedX = (float)speed.X / 100f;
                    float speedY = (float)speed.Y / 100f;
                    delta = new Point ((int)(delta.X * speedX), (int)(delta.Y * speedY));

                    Position = new Point (Position.X - delta.X, Position.Y - delta.Y);
                    previous = new Point (state.X, state.Y);
                }
                else
                {
                    previous = Position;
                    Position = new Point (state.X, state.Y);
                }

                if (speedset && (Position.X < 0 || Position.Y < 0 || Position.X > device.Viewport.Width - Size.X || Position.Y > device.Viewport.Height - Size.Y))
                {
                    speedset = false;
                }
                if (!speedset && (state.X > 0 && state.Y > 0 && state.X < device.Viewport.Width - Size.X && state.Y < device.Viewport.Height - Size.Y))
                {
                    speedset = true;
                }
                else if (state.X > 0 && state.Y > 0 && state.X < device.Viewport.Width && state.Y < device.Viewport.Height)
                {
                    speedset = true;
                }
            }
        }
    }
}
