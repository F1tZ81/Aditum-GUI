using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aditum.Interfaces
{
    /// <summary>
    /// A drawable item
    /// </summary>
    public interface IAdvanceDrawable
    {
        void Draw(SpriteBatch sb, GameTime gameTime);
    }
}
