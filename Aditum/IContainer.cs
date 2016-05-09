using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditum
{
    public interface IContainer
    {
        Point Postion { get; set; }
        Screen ParentScreen { get; set; }
        

        SpriteBatch Batch { get; }
        GuiElement GetElement(string id);
        GuiElement GetElement(int index);
        
        string ReturnActiveElementID();

        void Draw(SpriteBatch batch, GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
