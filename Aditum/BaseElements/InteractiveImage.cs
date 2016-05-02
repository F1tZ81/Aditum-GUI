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

        public InteractiveImage(IContainer conRef)
            : base(conRef)
        {

        }

        public void Draw(SpriteBatch sb, GameTime gameTime)
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

        public void OnActivate()
        {
            throw new NotImplementedException();
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
