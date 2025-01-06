using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper;

public class Board : DrawableGameComponent {
    
    
    public float X {get; private set;}
    public float Y {get; private set;}
    
    /// <summary>
    /// A list of minesweeper tiles.
    /// </summary>
    private Dictionary<Vector2, Tile> _tiles;
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

    private static readonly Vector2 DEFAULT_SIZE = new Vector2(10,10);
    private const int DEFAULT_MINECOUNT = 30;
    private const int DEFAULT_FLAGCOUNT = 30;

    public Board(MinesweeperGame game, Vector2? size = null, int mineCount = DEFAULT_MINECOUNT, int flagCount = DEFAULT_FLAGCOUNT): base(game){
        
        
        _tiles = new Dictionary<Vector2, Tile>();
        _size = size ?? DEFAULT_SIZE;
        _mineCount = mineCount;
        _flagCount = flagCount;
        X = 50; //change
        Y = 50; //change
    }

    public override void Draw(GameTime gameTime)
    {
        //throw new System.NotImplementedException();
        foreach (Tile tile in _tiles.Values){
            tile.Draw(gameTime);
        }
    }
    

    public override void Update(GameTime gameTime)
    {
        //throw new System.NotImplementedException();
        foreach (Tile tile in _tiles.Values){
            tile.Update(gameTime);
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        for (int column = 0; column < _size.X; column++)
            for (int row = 0; row < _size.Y; row++)
            {
                var index = new Vector2(row,column);
                
                _tiles[index] = new Tile(index,false,(MinesweeperGame)Game);
            }
    }

    /// <summary>
    /// Produces the board tile at the spot where the mouse is. Or null if there isn't one.
    /// </summary>
    /// <param name="mouseLocation"></param>
    /// <returns>The tile at the specified location.</returns>
    public Tile? GetTileAt(Vector2 index){
        return _tiles.GetValueOrDefault(index);
    }

}