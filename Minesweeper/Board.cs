using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper;

public class Board : IUpdateable
{

    private List<Tile> _tiles;

    private Vector2 _size;
    private int _mineCount;
    private int _flagCount;

    public void Draw(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }


}