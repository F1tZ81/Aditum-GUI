using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aditum.ElementInterfaces;
using Microsoft.Xna.Framework;

namespace Aditum.BaseElements
{
    public class BasePanel : InteractiveImage, IInnerRaster
    {
        public Texture2D InnerImage { get; set; }

        private float innerScale = 0;
        private Point relativeInnnerPos;

        public float InnerImageScale
        {
            get
            {
                return innerScale;
            }
        }

        public Point RelativePosition
        {
            get
            {
                return relativeInnnerPos;
            }
        }

        public BasePanel (int index, Texture2D sheet, ControlDefination baseImage, ControlDefination selectedImage) : 
            base(index, sheet, baseImage, selectedImage)
        {
            //this.ParentContainer.ParentScreen.
        }

        public BasePanel (int index) : this(index, null, null, null)
        {

        }

        public GuiElement SetInnerImage(Texture2D innerImage)
        {
            InnerImage = innerImage;
            return this;
        }

        public override void SetContainer(IContainer conRef)
        {
            base.SetContainer(conRef);

            if (BaseImage == null || BaseImage.Name == "base") BaseImage = conRef.ParentScreen.GetControlDef("panel"); 
        }

        public IInnerRaster SetInnerScale(float scale)
        {
            innerScale = scale;
            return this;
        }

        public IInnerRaster SetRelativePosition(Point pos)
        {
            relativeInnnerPos = pos;
            return this;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            base.Draw(sb, gameTime);

            if(InnerImage != null)
            {
                sb.Draw(InnerImage, this.RelativePostion.ToVector2() + relativeInnnerPos.ToVector2(), null, Color.White, 0f, Vector2.Zero, InnerImageScale, SpriteEffects.None, 0f);
            }
        }
    }
}
