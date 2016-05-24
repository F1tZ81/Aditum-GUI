using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aditum.ElementInterfaces;

namespace Aditum.BaseElements
{
    public class TestElement : InteractiveImage
    {
        /// <summary>
        /// Creates a fully rounded out element
        /// </summary>
        /// <param name="conf">the container</param>
        /// <param name="index">the index of the element with in the screen</param>
        /// <param name="sheet">the Texture to use as a sprite sheet</param>
        /// <param name="baseImage">the base control definition</param>
        /// <param name="selectedImage">the control definition for when the control is selected</param>
        public TestElement(int index, Texture2D sheet, ControlDefination baseImage, ControlDefination selectedImage) : 
            base (index, sheet, baseImage, selectedImage)
        {
            ID = "Test";
        }

        /// <summary>
        /// Creates a default Element with an assigned container
        /// </summary>
        /// <param name="conf"></param>
        /// <param name="index"></param>
        public TestElement(IContainer conf, int index) : this (index, null, null, null)
        {
            BaseImage = null;
            SelectedImage = null;
        }

        /// <summary>
        /// Creates a default Element with no assigned container
        /// </summary>
        /// <param name="index"></param>
        public TestElement(int index) : this(index, null, null, null)
        {

        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            base.Draw(sb, gameTime);
        }

    }
}
