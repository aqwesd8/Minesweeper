using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Minesweeper;

public class Tile : Button {
    public bool ValueVisible {get; private set;}
    public bool HasMine {get; private set;}
    public int MinesInProximity {get; private set;}
    public bool IsFlagged {get; private set;}

    public const int SIDE_LENGTH = 30;

    public Vector2 Index {get; private set;}
    
    public Board Board {get; private set;}

    public Tile(float x, float y, float width, float height, bool hasMine, Vector2 index, MinesweeperGame game) :base(x,y,width,height,game) 
    {
        Board = game.Board; 
        HasMine = hasMine;
        Index = index;
    }
    public Tile(MinesweeperGame game) : this(0,0,SIDE_LENGTH,SIDE_LENGTH,false,Vector2.One,game){}

    public Tile(Vector2 index, bool hasMine, MinesweeperGame game) : this(game){
        HasMine = hasMine;
        Index = index;
        X = Board.X + Index.X*SIDE_LENGTH;
        Y = Board.Y + Index.Y*SIDE_LENGTH;
    }

    public void SetMinesInProximity()
    {
        int mineCount = 0;
        foreach (Vector2 index in getNeighboringIndicies()){
            Tile? neighbor = Board.GetTileAt(index);
            mineCount += (neighbor?.HasMine ?? false) ? 1 : 0;
        }
        MinesInProximity = mineCount;
    }
    private List<Vector2> getNeighboringIndicies()
    {
        var neighbors = new List<Vector2>();

        for (int i = -1; i < 2; i++)
            for (int j = -1; j < 2; j++)
            {
                if(i!=0 || j!=0) neighbors.Add(new Vector2(Index.X+i,Index.Y+j));
            }

        return neighbors;
    }

}