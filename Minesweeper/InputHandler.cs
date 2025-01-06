using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Minesweeper;

public class InputHandler //: IUpdateable
{

    /// <summary>
    /// The minesweeper board the handler monitors.
    /// </summary>
    public Board MinesweeperBoard {get; private set;}

    public InputHandler(Board board) => MinesweeperBoard = board;
    public void Draw(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        MouseState m = Mouse.GetState();
        Vector2 mouseLocation = new Vector2(m.X, m.Y);
        Tile? currentTile = MinesweeperBoard.GetTileAt(mouseLocation);
        //if(m.LeftButton == ButtonState.Pressed) currentTile.();

        
    }


}