using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aditum.ElementInterfaces;

namespace Aditum.BaseContainer
{
    public class BasicContainer : IContainer
    {
        protected List<GuiElement> elements;

        public SpriteBatch Batch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GuiElement ActiveElement
        {
            get
            {
                foreach (GuiElement currentEle in elements)
                {
                    if (currentEle.Active) return currentEle;
                }

                return null;
            }
        }

        public Screen ParentScreen { get; set; }

        public Point Postion { get; set; }

        public GuiElement GetElement(string id)
        {
            foreach (GuiElement currentElement in elements)
            {
                if (currentElement.ID == id) return currentElement;
            }

            return null;
        }

        public void ActivateElementViaIndex(int index)
        {
            foreach (GuiElement currentElemet in elements)
            {
                if (currentElemet.Index == index) currentElemet.Active = true;
            }
        }

        public string ReturnActiveElementID()
        {
            foreach (GuiElement currentElement in elements)
            {
                if (currentElement.Active == true)
                {
                    return currentElement.ID;
                }
            }

            return "none";
        }

        public virtual void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach(GuiElement currentElement in elements)
            {
                if(currentElement is IRaster)
                {
                    ((IRaster)currentElement).Draw(batch, gameTime);
                }

                if(currentElement is IText)
                {
                    ((IText)currentElement).Draw(batch, gameTime);
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(GuiElement currentEle in elements)
            {
                currentEle.Update(gameTime);
            }
        }
    }
}
