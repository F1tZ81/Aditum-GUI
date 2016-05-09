using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Aditum
{
    public class Screen
    {
        public bool Transpaenrt { get; set; }
        public bool Active { get; set; }
        private bool CleanUp { get; set; }

        public int CurrentIndex { get; set; }

        public GuiElement ActiveElement
        {
            get
            {
                GuiElement tempEle = null;
                foreach(IContainer currentCon in Containers)
                {
                    tempEle = currentCon.GetElement(CurrentIndex);
                    if (tempEle != null) return tempEle;
                }
                return tempEle;
            }
        }

        protected List<IContainer> Containers { get; set; }

        public Screen()
        {
            Transpaenrt = false;
            Active = true;
            CleanUp = false;

            CurrentIndex = 0;
            Containers = new List<IContainer>();
        }

        public void MarkForCleanUp()
        {
            CleanUp = true;
        }

        public void ActivateElementViaIndex(int index)
        {

        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach(IContainer currentCon in Containers)
            {
                currentCon.Draw(batch, gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(IContainer currentContainer in Containers)
            {
                currentContainer.Update(gameTime);
            }
        }

        public virtual IContainer AddContainer()
        {
            throw new NotImplementedException();
        }
    }
}
