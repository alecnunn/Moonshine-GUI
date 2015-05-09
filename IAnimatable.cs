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
using Moonshine.gui.Misc;

namespace Moonshine.gui
{ 
    /// <summary>
    /// You should implement this interface if you want to create a control with animations
    /// </summary>
    public interface IAnimatableControl
    {
        /// <summary>
        /// A Sorted List of all <see cref="Moonshine.gui.Misc.Animator"/>s
        /// </summary>
        SortedList<string, Animator> animators { get; set; }
    }
}
