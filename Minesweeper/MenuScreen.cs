using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace Minesweeper;

public class MenuScreen(MinesweeperGame game) : GameScreen(game)
{

    private new MinesweeperGame Game => (MinesweeperGame) base.Game;

    public override void Draw(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }
}