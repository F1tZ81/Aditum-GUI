using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.ElementInterfaces
{
    public interface IInnerRaster : IRaster
    {
        Texture2D InnerImage { get; set; }

        void SetInnerImage(Texture2D innerImage);
    }
}
