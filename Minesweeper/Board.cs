using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper;

public class Board : IUpdateable
{
    /// <summary>
    /// A list of minesweeper tiles.
    /// </summary>
    private List<Tile> _tiles;
    /// <summary>
    /// The board's dimensions.
    /// </summary>
    private Vector2 _size;
    /// <summary>
    /// The total number of mines in the board.
    /// </summary>
    private int _mineCount;
    /// <summary>
    /// The total number of placed flags.
    /// </summary>
    private int _flagCount;

    public void Draw(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Produces the board tile at the spot where the mouse is. Or null if there isn't one.
    /// </summary>
    /// <param name="mouseLocation"></param>
    /// <returns>The tile at the specified location.</returns>
    public Tile? GetTileAt(Vector2 mouseLocation){
        
        foreach(Tile tile in _tiles){
            bool inColumn = mouseLocation.X >= tile.X && mouseLocation.X <= tile.X+tile.Width;
            bool inRow = mouseLocation.Y >= tile.Y && mouseLocation.X <= tile.Y+tile.Height;

            if(inColumn && inRow) return tile;
        }
        
        return null;
    }

}