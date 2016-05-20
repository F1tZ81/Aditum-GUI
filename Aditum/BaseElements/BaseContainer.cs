using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Aditum.ElementInterfaces;

namespace Aditum.BaseElements
{
    public class BaseContainer : IContainer
    {
       
        List<GuiElement> Elements { get; set; }
        public string ID { get; set; }

        public SpriteBatch Batch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Screen ParentScreen { get; set; }

        public Point Postion { get; set; }

        public ContentManager Contnet
        {
            get
            {
                return ParentScreen.Content;
            }
        }

        public BaseContainer(Screen parentScreen, string iD)
        {
            ParentScreen = parentScreen;
            Elements = new List<GuiElement>();
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach(GuiElement currentElement in Elements)
            {
                if (currentElement is IAdvanceDrawable) ((IAdvanceDrawable)currentElement).Draw(batch, gameTime);
            }
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

        public GuiElement AddElement(GuiElement element)
        {
            element.SetContainer(this);
            Elements.Add(element);
            return element;
        }
    }
}
