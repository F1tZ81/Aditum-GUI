using Aditum.BaseElements;
using Aditum.ElementInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Aditum
{
    public class Screen
    {
        #region Properties
        public bool Transpaenrt { get; set; }
        public bool Active { get; set; }
        private bool CleanUp { get; set; }

        public int CurrentIndex { get; set; }

        public GuiElement ActiveElement
        {
            get
            {
                GuiElement tempEle = null;
                foreach(IContainer currentCon in Containers)
                {
                    tempEle = currentCon.GetElement(CurrentIndex);
                    if (tempEle != null) return tempEle;
                }
                return tempEle;
            }
        }
        public ContentManager Content;

        protected List<IContainer> Containers { get; set; }
        protected List<ControlDefination> ControlDefinations { get; set; }

        // control states
        protected KeyboardState LastKeyState { get; set; }
        protected MouseState LastMosueState { get; set; }
        protected GamePadState LastPadState { get; set; }
        #endregion

        public Screen(IServiceProvider service)
        {
            Content = new ContentManager(service);

            ControlDefinations = new List<ControlDefination>();

            Transpaenrt = false;
            Active = true;
            CleanUp = false;

            CurrentIndex = 0;
            Containers = new List<IContainer>();

            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(4, 56, 68, 17), Name = "base", Scale = 2f });
            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(4, 40, 65, 16), Name = "selected", Scale = 2f });
            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(0, 0, 10, 10), Name = "activated" });
        }

        #region AddGetSetRemove
        public virtual ControlDefination GetControlDef(string name)
        {
            foreach (ControlDefination currentDef in ControlDefinations)
            {
                if (currentDef.Name == name) return currentDef;
            }

            return null;
        }

        public GuiElement GetElement(string name)
        {
            foreach (IContainer currentCon in Containers)
            {
                GuiElement tempEle = currentCon.GetElement(name);
                if (tempEle != null) return tempEle;
            }

            return null;
        }

        public GuiElement GetElement(int index)
        {
            foreach (IContainer currentCon in Containers)
            {
                GuiElement tempEle = currentCon.GetElement(index);
                if (tempEle != null) return tempEle;
            }

            return null;
        }

        public virtual IContainer AddContainer(string iD)
        {
            IContainer tempBase = new BaseContainer(this, iD);
            Containers.Add(tempBase);
            return tempBase;
        }
        #endregion

        public void MarkForCleanUp()
        {
            CleanUp = true;
        }

        public void ActivateElementViaIndex(int index)
        {

        }

        /// <summary>
        /// Load a UI Map from an xml file
        /// </summary>
        /// <param name="path"></param>
        public virtual void UIMap(string path)
        {

            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(path);
            
            foreach(XmlNode currentNode in xmlFile.DocumentElement.ChildNodes)
            {
                ControlDefination tempControl = new ControlDefination();
                tempControl.Name = currentNode.Attributes["Name"].Value;
                tempControl.Bounds = new Rectangle(int.Parse(currentNode.Attributes["Width"].Value), 
                    int.Parse(currentNode.Attributes["Height"].Value), 
                    int.Parse(currentNode.Attributes["PositionX"].Value), 
                    int.Parse(currentNode.Attributes["PositionX"].Value));
                tempControl.Scale = float.Parse((currentNode.Attributes["Scale"].Value));
            }
        }

        protected void NextIndex(SiblingDirection direction)
        {
            if (CurrentIndex == 0)
            {
                CurrentIndex = 1;
                return;
            }

            GuiElement currentElement = GetElement(CurrentIndex);
               
            switch (direction)
            {
                case SiblingDirection.Up:
                    if (currentElement.SiblingUp != 0)
                    {
                        CurrentIndex = currentElement.SiblingUp;
                        currentElement.Active = false;
                        ActivateElementViaIndex(CurrentIndex);
                        return;
                    }
                    else
                    {
                        return;
                    }

                case SiblingDirection.Down:
                    if (currentElement.SiblingDown != 0)
                    {
                        CurrentIndex = currentElement.SiblingDown;
                        currentElement.Active = false;
                        ActivateElementViaIndex(CurrentIndex);
                        return;
                    }
                    else
                    {
                        return;
                    }

                case SiblingDirection.Right:
                    if (currentElement.SiblingRight != 0)
                    {
                        CurrentIndex = currentElement.SiblingRight;
                        currentElement.Active = false;
                        ActivateElementViaIndex(CurrentIndex);
                        return;
                    }
                    else
                    {
                        return;
                    }

                case SiblingDirection.Left:
                    if (currentElement.SiblingLeft != 0)
                    {
                        CurrentIndex = currentElement.SiblingLeft;
                        currentElement.Active = false;
                        ActivateElementViaIndex(CurrentIndex);
                        return;
                    }
                    else
                    {
                        return;
                    }
            }
        }

        /// <summary>
        /// Base implantation of a screen draw
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="gameTime"></param>
        public virtual void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach (IContainer currentCon in Containers)
            {
                currentCon.Draw(batch, gameTime);
            }
        }

        /// <summary>
        /// Base implantation of a screen update
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            // Update the Active element based on the currentindex
            if (CurrentIndex != 0 && !GetElement(CurrentIndex).Active) GetElement(CurrentIndex).Active = true;

            // run all container updates (should not directly interact with elements
            foreach (IContainer currentContainer in Containers)
            {
                currentContainer.Update(gameTime);
            }

            // Get all states
            KeyboardState currentKeyState = Keyboard.GetState();
            GamePadState currentPadState = GamePad.GetState(PlayerIndex.One);
            MouseState currentMouseState = Mouse.GetState();

            // Check if either the enter keyboard button was hit or the 'A' button the 
            // game pad was hit
            if ((currentKeyState.IsKeyDown(Keys.Enter) && !LastKeyState.IsKeyDown(Keys.Enter)) ||
                (currentPadState.IsButtonDown(Buttons.A) && !LastPadState.IsButtonDown(Buttons.A)))
            {
                // Make sure the element in question supports this type of interaction
                if (GetElement(CurrentIndex) is IActivatable)
                {
                    ((IActivatable)GetElement(CurrentIndex)).OnActivate(gameTime);
                }
            }

            // check if the left mouse button was clicked
            if (currentMouseState.LeftButton == ButtonState.Pressed && LastMosueState.LeftButton != ButtonState.Pressed)
            {
                // make sure this element supports that type of interaction
                if (GetElement(CurrentIndex) is IClickable)
                {
                    // check if the mouse is over the bounding box of the control
                    if (((IClickable)GetElement(CurrentIndex)).BoundingBox.Contains(currentMouseState.X, currentMouseState.Y))
                    {
                        ((IClickable)GetElement(CurrentIndex)).OnClick(gameTime);
                    }
                }
            }

            // Check for movement to new element
            if((currentKeyState.IsKeyDown(Keys.Up) && !LastKeyState.IsKeyDown(Keys.Up)) ||
                (currentPadState.IsButtonDown(Buttons.DPadUp) && !LastPadState.IsButtonDown(Buttons.DPadUp)))
            {
                NextIndex(SiblingDirection.Up);
            }

            if ((currentKeyState.IsKeyDown(Keys.Down) && !LastKeyState.IsKeyDown(Keys.Down)) ||
                (currentPadState.IsButtonDown(Buttons.DPadDown) && !LastPadState.IsButtonDown(Buttons.DPadDown)))
            {
                NextIndex(SiblingDirection.Down);
            }

            if ((currentKeyState.IsKeyDown(Keys.Left) && !LastKeyState.IsKeyDown(Keys.Left)) ||
                (currentPadState.IsButtonDown(Buttons.DPadLeft) && !LastPadState.IsButtonDown(Buttons.DPadLeft)))
            {
                NextIndex(SiblingDirection.Left);
            }

            if ((currentKeyState.IsKeyDown(Keys.Right) && !LastKeyState.IsKeyDown(Keys.Right)) ||
                (currentPadState.IsButtonDown(Buttons.DPadRight) && !LastPadState.IsButtonDown(Buttons.DPadRight)))
            {
                NextIndex(SiblingDirection.Right);
            }

            LastKeyState = currentKeyState;
            LastPadState = currentPadState;
            LastMosueState = currentMouseState;
        }
    }

    /// <summary>
    /// Control definitions are support objects for sprite sheets
    /// these items define where the pixels are in the sprite sheet via Bounds
    /// and controls the scale of resulting pixels
    /// </summary>
    public class ControlDefination
    {
        public string Name { get; set; }
        public Rectangle Bounds { get; set; }
        public float Scale { get; set; }
    }

    public enum SiblingDirection
    {
        Up, Down, Left, Right
    }

}
