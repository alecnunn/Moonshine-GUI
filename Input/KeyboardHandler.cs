using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonshine.gui.Input
{
    public static class KeyboardHandler
    {
        public static KeyboardState state;
        private static Keys lastKey;
        private static Dictionary<Keys,bool> dictionary = new Dictionary<Keys, bool>();
        public static void Update (GameTime gt)
        {
            state = Keyboard.GetState();
        }
        public static string KeyPressedStr(Keys k)
        {
            if(state.IsKeyUp(k))
            {
                dictionary[k] = false;
            }
            if(state.IsKeyDown(k))
            {
                if(dictionary[k] == false)
                {
                    dictionary[k] = true;
                    if(state.IsKeyDown(Keys.LeftShift))
                    {
                        return k.ToString().ToUpper();
                    }
                    else
                    {
                        switch(k)
                        {
                            case(Keys.D1):
                                return "1";
                                break;
                        }
                        return k.ToString().ToLower();
                    }
                }
            }
            return "";
        }
    }
}