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

        public TestElement(IContainer conf, Texture2D baseImage, Texture2D selectedImage) : base (conf, baseImage, selectedImage)
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
