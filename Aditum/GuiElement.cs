﻿using Microsoft.Xna.Framework;

namespace Aditum
{
    public enum ScreenOrientation
    {
        LeftCenter, RightCenter, Center, Top, TopRight, TopLeft, Bottom, LeftBottom, RightBottom
    }

    public class GuiElement
    {
        /// <summary>
        /// The index of the current element
        /// </summary>
        protected int index = 0;

        /// <summary>
        /// A reference to the elements parent container 
        /// </summary>
        private IContainer ParentContainer;

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

        public GuiElement(IContainer ConRef)
        {
            Active = false;
            ID = "Unknown";
            RelativePostion = new Point(0, 0);
            Visable = true;
            Interactive = true;
            ParentContainer = ConRef;
            Orientation = ScreenOrientation.TopLeft;
        }

    }
}