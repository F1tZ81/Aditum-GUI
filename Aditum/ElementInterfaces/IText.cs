using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.ElementInterfaces
{
    public interface IText
    {
        SpriteFont Font { get; set; }

        Color Base { get; set; }
        Color Selected { get; set; }
        Color Activated { get; set; }
    }
}
