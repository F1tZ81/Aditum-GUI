﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Aditum
{
    public class Screen
    {
        public bool Transpaenrt { get; set; }
        public bool Active { get; set; }
        private bool CleanUp { get; set; }

        private int CurrentIndex { get; set; }

        public GuiElement ActiveElement
        {
            get
            {
                foreach (GuiElement currentEle in Elements)
                {
                    if (currentEle.Active) return currentEle;
                }

                return null;
            }
        }

        protected List<IContainer> Containers { get; set; }

        public Screen()
        {
            Transpaenrt = false;
            Active = true;
            CleanUp = false;

            CurrentIndex = 0;

            Elements = new List<GuiElement>();
        }

        public GuiElement GetElement (string id)
        {
            foreach(GuiElement currentElement in Elements)
            {
                if (currentElement.ID == id) return currentElement;
            }

            return null;
        }

        public void MarkForCleanUp()
        {
            CleanUp = true;
        }

        protected void ActivateElementViaIndex(int index)
        {
            foreach (GuiElement currentElemet in Elements)
            {
                if (currentElemet.Index == index) currentElemet.Active = true;
            }
        }

        protected string ReturnActiveElementID()
        {
            foreach (GuiElement currentElement in Elements)
            {
                if (currentElement.Active == true)
                {
                    return currentElement.ID;
                }
            }

            return "none";
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach(IContainer currentCon in Containers)
            {
                currentCon.Draw(batch, gameTime);
            }
        }
    }
}
