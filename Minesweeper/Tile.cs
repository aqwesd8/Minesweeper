using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Minesweeper;

public class Tile : IUpdateable {
    public bool ValueVisible {get; private set;}
    public bool HasMine {get; private set;}
    public bool MinesInProximity {get; private set;}
    public bool IsFlagged {get; private set;}

    public float X;
    public float Y;
    public float Width;
    public float Height;
    

    private static readonly Color STANDING = Color.BlanchedAlmond;
    private static readonly Color HIGHLIGHTED = Color.Beige;
    private Color color = STANDING;

    public Tile(float x, float y, float width, float height){
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
    public Tile() : this(0,0,0,0){}

    

    protected virtual void OnClick()
    {
        //TODO - implement
        color = HIGHLIGHTED;
        Console.WriteLine("TEST");
    }
    protected virtual void OnPush()
    {
        color = STANDING;
    }
    protected virtual void OnRollOn()
    {
        color = HIGHLIGHTED;
    }  
    protected virtual void OnRollOff()
    {
        color = STANDING;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.FillRectangle(X,Y,Width,Height,color);
    }

    public void Update(GameTime gameTime)
    {

        ScaledMouseState ms = ScaledMouse.GetState();
        float mouseX= ms.X;
        float mouseY = ms.Y;
        float prevX = ms.Previous_X;
        float prevY = ms.Previous_Y;
        

        bool mouseOnTile = mouseX >= X && mouseX <= X+Width && mouseY >= X && mouseY <= X+Height;
        bool mouseWasOnTile = prevX >= X && prevX <= X+Width && prevY >= X && prevY <= X+Height;

        if(!mouseWasOnTile && mouseOnTile) OnRollOn();
        if(mouseWasOnTile && !mouseOnTile) OnRollOff();

    }

    public void Draw(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}