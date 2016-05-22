using Microsoft.Xna.Framework;

namespace Aditum.ElementInterfaces
{
    /// <summary>
    /// Item can be activated via gamepad button or keyboard press
    /// </summary>
    public interface IActivatable
    {

        void OnActivate(GameTime time);
    }
}
