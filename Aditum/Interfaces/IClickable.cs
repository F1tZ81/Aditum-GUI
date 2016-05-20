using Microsoft.Xna.Framework;

namespace Aditum.ElementInterfaces
{
    public interface IClickable
    {
        Rectangle BoundingBox { get; set; }

        void OnClick();
    }
}
