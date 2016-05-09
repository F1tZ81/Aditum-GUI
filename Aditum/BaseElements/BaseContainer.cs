using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aditum.BaseElements
{
    public class BaseContainer : IContainer
    {
       
        List<GuiElement> Elements { get; set; }

        public SpriteBatch Batch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Screen ParentScreen { get; set; }

        public Point Postion { get; set; }


        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public GuiElement GetElement(int index)
        {
            foreach(GuiElement currentEle in Elements)
            {
                if (currentEle.Index == index) return currentEle;
            }

            return null;
        }

        public GuiElement GetElement(string id)
        {
            foreach (GuiElement currentEle in Elements)
            {
                if (currentEle.ID == id) return currentEle;
            }

            return null;
        }

        public string ReturnActiveElementID()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
