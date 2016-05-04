using Aditum.ElementInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aditum.BaseElements
{
    public class InteractiveImage : GuiElement, IClickable, IActivatable, IRaster
    {
        public Texture2D ActivatedGUI { get; set; }
        public Texture2D BaseImage { get; set; }
        public Texture2D SelectedImage { get; set; }
        public Rectangle BoundingBox { get; set; }

        public InteractiveImage(IContainer conRef, Texture2D baseImage, Texture2D selectedImage)
            : base(conRef)
        {
            BaseImage = baseImage;
            SelectedImage = selectedImage;
            BoundingBox = new Rectangle(ActualPosition.X, ActualPosition.Y, BaseImage.Bounds.Width, BaseImage.Height);
        }

        public virtual void Draw(SpriteBatch sb, GameTime gameTime)
        {
            if(Visable)
            {
                if(!Active)
                {
                    sb.Draw(BaseImage, new Vector2(ActualPosition.X, ActualPosition.Y), Color.White);
                }
                else
                {
                    sb.Draw(SelectedImage, new Vector2(ActualPosition.X, ActualPosition.Y), Color.White);
                }
            }
        }

        public virtual void OnActivate()
        {
            throw new NotImplementedException();
        }

        public virtual void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
