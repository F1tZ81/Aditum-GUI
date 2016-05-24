using Aditum.ElementInterfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Aditum.Interfaces;

namespace Aditum.BaseElements
{
    public class InteractiveImage : GuiElement, IClickable, IActivatable, IRasterSheet
    {
        #region Properties
        public Texture2D SheetImage { get; set; }
        public ControlDefination ActivatedGUI { get; set; }
        public ControlDefination BaseImage { get; set; }
        public ControlDefination SelectedImage { get; set; }
        public Rectangle BoundingBox { get; set; }
        #endregion

        public InteractiveImage(int index, Texture2D sheetTexture, ControlDefination baseImage)
            : base(index)
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

        public InteractiveImage(int index, Texture2D sheetTexture, ControlDefination baseImage, ControlDefination selectedImage) : this(index, sheetTexture, baseImage)
        {
            this.SelectedImage = selectedImage;
        }

        public virtual void OnActivate(GameTime time)
        {
            OnAction(time);
        }

        public virtual void OnClick(GameTime time)
        {
            OnAction(time);
        }

        protected void OnAction(GameTime time)
        {
            Console.WriteLine("OnAction Call for " + ID + " @ index " + Index);
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

        public virtual void Draw(SpriteBatch sb, GameTime gameTime)
        {
            if (Visable)
            {
                if (!Active)
                {
                    sb.Draw(SheetImage, new Vector2(ActualPosition.X, ActualPosition.Y), BaseImage.Bounds, Color.White, 0f, Vector2.Zero, BaseImage.Scale, SpriteEffects.None, 0f);
                }
                else
                {
                    sb.Draw(SheetImage, new Vector2(ActualPosition.X, ActualPosition.Y), SelectedImage.Bounds, Color.White, 0f, Vector2.Zero, SelectedImage.Scale, SpriteEffects.None, 0f);

                }
            }
        }

    }
}
