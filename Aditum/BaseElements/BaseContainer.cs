using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Aditum.ElementInterfaces;
using Aditum.Interfaces;

namespace Aditum.BaseElements
{
    public class BaseContainer : IContainer
    {
        #region Properties
        List<GuiElement> Elements { get; set; }

        public string ID { get; set; }

        public Screen ParentScreen { get; set; }

        public Point Postion { get; set; }

        public ContentManager Contnet
        {
            get
            {
                return ParentScreen.Content;
            }
        }

        public SpriteBatch Batch
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public BaseContainer(Screen parentScreen, string iD)
        {
            ParentScreen = parentScreen;
            Elements = new List<GuiElement>();
        }

        #region ElementHandling
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

        public GuiElement AddElement(GuiElement element)
        {
            element.SetContainer(this);
            Elements.Add(element);
            return element;
        }
        #endregion

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            // If we have a contior with a background draw it
            if(this is IBackground)
            {
                batch.Draw(((IBackground)this).SheetImage, new Vector2(Postion.X, Postion.Y), ((IBackground)this).BackImage.Bounds,
                    Color.White, 0f, Vector2.Zero, ((IBackground)this).BackImage.Scale, SpriteEffects.None, 0f);
            }

            // iterate though the elements and draw them
            foreach (GuiElement currentElement in Elements)
            {
                if (currentElement is IAdvanceDrawable) ((IAdvanceDrawable)currentElement).Draw(batch, gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
