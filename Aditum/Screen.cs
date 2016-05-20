using Aditum.BaseElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Aditum
{
    public class Screen
    {
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

        public Screen(IServiceProvider service)
        {
            Content = new ContentManager(service);

            ControlDefinations = new List<ControlDefination>();

            Transpaenrt = false;
            Active = true;
            CleanUp = false;

            CurrentIndex = 0;
            Containers = new List<IContainer>();

            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(126, 162, 16, 16), Name = "base", Scale = 3.5f });
            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(0, 0, 10, 10), Name = "selected" });
            ControlDefinations.Add(new ControlDefination { Bounds = new Rectangle(0, 0, 10, 10), Name = "activated" });
        }

        public void MarkForCleanUp()
        {
            CleanUp = true;
        }

        public void ActivateElementViaIndex(int index)
        {

        }

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
            foreach(IContainer currentCon in Containers)
            {
                GuiElement tempEle = currentCon.GetElement(name);
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

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            foreach (IContainer currentCon in Containers)
            {
                currentCon.Draw(batch, gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IContainer currentContainer in Containers)
            {
                currentContainer.Update(gameTime);
            }
        }
    }

    public class ControlDefination
    {
        public string Name { get; set; }
        public Rectangle Bounds { get; set; }
        public float Scale { get; set; }
    }
}
