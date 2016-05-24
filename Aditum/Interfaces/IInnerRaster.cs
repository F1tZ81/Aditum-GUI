using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.ElementInterfaces
{
    public interface IInnerRaster
    {
        Texture2D InnerImage { get; set; }
        float InnerImageScale { get; }
        Point RelativePosition { get; }
        GuiElement SetInnerImage(Texture2D innerImage);
        IInnerRaster SetInnerScale(float scale);
        IInnerRaster SetRelativePosition(Point pos);

    }
}
