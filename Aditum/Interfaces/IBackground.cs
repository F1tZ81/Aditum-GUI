using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.Interfaces
{
    public interface IBackground : IAdvanceDrawable
    {
        ControlDefination BackImage { get; set; }
        Texture2D SheetImage { get; set; }
    }
}
