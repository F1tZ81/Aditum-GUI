using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum.ElementInterfaces
{
    public interface IRaster
    {
        Texture2D BaseImage { get; set; }
        Texture2D SelectedImage { get; set; }
        Texture2D ActivatedGUI { get; set; }

        void Draw(SpriteBatch sb, GameTime gameTime);
    }
}
