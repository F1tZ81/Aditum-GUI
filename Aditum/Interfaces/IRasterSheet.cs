using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.ElementInterfaces
{
    public interface IRasterSheet : IAdvanceDrawable
    {
        Texture2D SheetImage { get; set; }
        ControlDefination BaseImage { get; set; }
        ControlDefination SelectedImage { get; set; }
        ControlDefination ActivatedGUI { get; set; }

        
    }
}
