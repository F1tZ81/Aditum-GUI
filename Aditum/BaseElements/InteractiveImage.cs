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
    public class InteractiveImage : GuiElement, IClickable, IActivatable, IRasterSheet
    {
        public Texture2D SheetImage { get; set; }
        public ControlDefination ActivatedGUI { get; set; }
        public ControlDefination BaseImage { get; set; }
        public ControlDefination SelectedImage { get; set; }
        public Rectangle BoundingBox { get; set; }

        public InteractiveImage(IContainer conRef, Texture2D sheetTexture, ControlDefination baseImage)
            : base(conRef)
        {
            RelativePostion = new Point(0, 0);
            
            if(BaseImage != null) BaseImage = BaseImage;

            if (sheetTexture != null)
            {
                SheetImage = sheetTexture;
            }
            else
            {
                SheetImage = this.BaseSheet;
            }
        }

        public InteractiveImage(IContainer conRef, Texture2D sheetTexture, ControlDefination baseImage, ControlDefination selectedImage) : this(conRef, sheetTexture, baseImage)
        {
            this.SelectedImage = selectedImage;
        }

        public virtual void Draw(SpriteBatch sb, GameTime gameTime)
        {
            if(Visable)
            {
                if(!Active)
                {
                    sb.Draw(SheetImage, new Vector2(ActualPosition.X, ActualPosition.Y), BaseImage.Bounds, Color.White, 0f, Vector2.Zero, BaseImage.Scale, SpriteEffects.None, 0f);
                }
                else
                {
                    sb.Draw(SheetImage, new Vector2(ActualPosition.X, ActualPosition.Y), SelectedImage.Bounds, Color.White, 0f, Vector2.Zero, SelectedImage.Scale, SpriteEffects.None, 0f);
                
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

        public override void SetContainer(IContainer conRef)
        {
            base.SetContainer(conRef);

            if(BaseImage == null) BaseImage = conRef.ParentScreen.GetControlDef("base");
            if (SelectedImage == null) SelectedImage = conRef.ParentScreen.GetControlDef("selected");
            if (ActivatedGUI == null) ActivatedGUI = conRef.ParentScreen.GetControlDef("activated");
            if (SheetImage == null) SheetImage = BaseSheet;
            BoundingBox = new Rectangle(ActualPosition.X, ActualPosition.Y, BaseImage.Bounds.Width, BaseImage.Bounds.Height);
        }

    }
}
