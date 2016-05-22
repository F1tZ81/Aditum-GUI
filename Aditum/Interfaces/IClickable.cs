using Microsoft.Xna.Framework;

namespace Aditum.ElementInterfaces
{
    /// <summary>
    /// Item can be clicked on
    /// </summary>
    public interface IClickable
    {
        Rectangle BoundingBox { get; set; }

        void OnClick(GameTime time);
    }
}
