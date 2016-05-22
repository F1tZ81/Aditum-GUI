using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aditum.ElementInterfaces;

namespace Aditum.BaseElements
{
    public class TestElement : InteractiveImage, IInnerRaster
    {
        public Texture2D InnerImage { get; set; }

        public TestElement(IContainer conf, int index, Texture2D sheet, ControlDefination baseImage, ControlDefination selectedImage) : 
            base (conf, index, sheet, baseImage, selectedImage)
        {
            ID = "Test";
        }

        public TestElement(IContainer conf, int index) : this (conf, index, null, null, null)
        {
            BaseImage = null;
            SelectedImage = null;
        }

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
