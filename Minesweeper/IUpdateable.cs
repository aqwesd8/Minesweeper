using Microsoft.Xna.Framework;

namespace Minesweeper;

public interface IUpdateable {
    public void Draw(GameTime gameTime);
    public void Update(GameTime gameTime);
}