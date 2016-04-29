using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AditumGUI
{
    public class Screen
    {
        bool Transpaenrt { get; set; }
        bool Active { get; set; }
        bool CleanUp { get; set; }

        int CurrentIndex { get; set; }

        protected List<GuiElement> Elements { get; set; }

        public Screen()
        {
            Transpaenrt = false;
            Active = true;
            CleanUp = false;

            CurrentIndex = 0;

            Elements = new List<GuiElement>();
        }

        public GuiElement GetElement (string id)
        {
            foreach(GuiElement currentElement in Elements)
            {
                if (currentElement.ID == id) return currentElement;
            }

            return null;
        }

        public void MarkForCleanUp()
        {
            CleanUp = true;
        }

        protected void ActivateElementViaIndex(int index)
        {
            foreach (GuiElement currentElemet in Elements)
            {
                if (currentElemet.Index == index) currentElemet.Active = true;
            }
        }

        protected string ReturnActiveElementID()
        {
            foreach (GuiElement currentElement in Elements)
            {
                if (currentElement.Active == true)
                {
                    return currentElement.ID;
                }
            }

            return "none";
        }
    }
}
