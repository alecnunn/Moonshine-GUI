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
    /// You should implement this interface if you want to create a container control
    /// </summary>
    public interface ITransparentControl
    {
        /// <summary>
        /// Transparency
        /// </summary>
        int Transparency { get; set; }
    }
}
