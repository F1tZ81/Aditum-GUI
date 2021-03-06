﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Aditum
{
    /// <summary>
    /// Orientation of the elements and containers with in a screen
    /// </summary>
    public enum ScreenOrientation
    {
        LeftCenter, RightCenter, Center, Top, TopRight, TopLeft, Bottom, LeftBottom, RightBottom
    }

    public class GuiElement
    {
        #region Properties
        /// <summary>
        /// The path in content for the base ui sheet
        /// </summary>
        protected string BaseUIImagePath = "UIpack";

        /// <summary>
        /// The default UI Sprite sheet
        /// </summary>
        protected Texture2D BaseSheet;

        /// <summary>
        /// The index of the current element
        /// </summary>
        protected int index = 0;

        /// <summary>
        /// A reference to the elements parent container 
        /// </summary>
        protected IContainer ParentContainer;

        /// <summary>
        /// Set if the element is set to active (currently selected element)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Simple ID used to find an element
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Returns the elements Index with in the screen
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }
        }

        // Siblings
        // these simple indexes are used to 
        // navigate to the next control on
        // a screen in any of the basic 
        // 4 directions
        public int SiblingUp { get { return SibUp; } }
        private int SibUp;
        public int SiblingDown { get { return SibDown; } }
        private int SibDown;
        public int SiblingRight { get { return SibRight; } }
        private int SibRight;
        public int SiblingLeft { get { return SibLeft; } }
        private int SibLeft;

        /// <summary>
        /// The relative location of the element from the parent container 
        /// </summary>
        public Point RelativePostion { get; set; }

        /// <summary>
        /// The actual screen position of the element
        /// </summary>
        public Point ActualPosition
        {
            get
            {
                return ParentContainer.Postion + RelativePostion;
            }
        }

        /// <summary>
        /// The snapped to orientation of the element with in parent container 
        /// </summary>
        public ScreenOrientation Orientation { get; set; }

        /// <summary>
        /// Denotes the visibility of the element on the screen
        /// </summary>
        public bool Visable { get; set; }

        /// <summary>
        /// Denotes the interactivity of the element
        /// If it is not interactive than it can not be manipulated by input.
        /// </summary>
        protected bool Interactive { get; set; }
        #endregion

        /// <summary>
        /// Creates a Gui element object
        /// </summary>
        /// <param name="index">the index with in the screen</param>
        public GuiElement(int index)
        {
            Active = false;
            ID = "Unknown";
            RelativePostion = new Point(0, 0);
            Visable = true;
            Interactive = true;
            Orientation = ScreenOrientation.TopLeft;
            this.index = index;
        }

        /// <summary>
        /// Sets the sibling elements of the current element
        /// </summary>
        /// <param name="up">index of the element above</param>
        /// <param name="down">index of the element below</param>
        /// <param name="left">index of the element to the left</param>
        /// <param name="right">index of the element to the right</param>
        /// <returns></returns>
        public GuiElement Siblings(int up, int down, int left, int right)
        {
            SibUp = up;
            SibDown = down;
            SibLeft = left;
            SibRight = right;
            return this;
        }

        /// <summary>
        /// Sets the relative Position of the element 
        /// This is an offset of the container position 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GuiElement RealtivePOS(int x, int y)
        {
            RelativePostion = new Point(x, y);
            return this;
        }

        /// <summary>
        /// This is a simple call back used by the container to set the parent 
        /// container and set a any dependent defaults
        /// </summary>
        /// <param name="conRef"></param>
        public virtual void SetContainer (IContainer conRef)
        {
            ParentContainer = conRef;
            if(BaseSheet == null) BaseSheet = conRef.Contnet.Load<Texture2D>(BaseUIImagePath);
        }

        public virtual void Update(GameTime gameTime)
        {
            //throw 
        }
    }
}
