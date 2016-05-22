﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aditum.ElementInterfaces;

namespace Aditum.BaseElements
{
    public class TestElement : InteractiveImage, IInnerRaster
    {
        public Texture2D InnerImage { get; set; }

        /// <summary>
        /// Creates a fully rounded out element
        /// </summary>
        /// <param name="conf">the container</param>
        /// <param name="index">the index of the element with in the screen</param>
        /// <param name="sheet">the Texture to use as a sprite sheet</param>
        /// <param name="baseImage">the base control definition</param>
        /// <param name="selectedImage">the control definition for when the control is selected</param>
        public TestElement(IContainer conf, int index, Texture2D sheet, ControlDefination baseImage, ControlDefination selectedImage) : 
            base (conf, index, sheet, baseImage, selectedImage)
        {
            ID = "Test";
        }

        /// <summary>
        /// Creates a default Element with an assigned container
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="index"></param>
        public TestElement(IContainer conf, int index) : this (conf, index, null, null, null)
        {
            BaseImage = null;
            SelectedImage = null;
        }

        /// <summary>
        /// Creates a default Element with no assigned container
        /// </summary>
        /// <param name="index"></param>
        public TestElement(int index) : this(null, index, null, null, null)
        {

        }

        public void SetInnerImage(Texture2D innerImage)
        {
            InnerImage = innerImage;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            base.Draw(sb, gameTime);

            if (InnerImage != null)
            {
                sb.Draw(InnerImage, new Vector2(ActualPosition.X, ActualPosition.Y), Color.White);
            }
        }

    }
}
