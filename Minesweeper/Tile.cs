using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGameGum.Forms.Controls;

namespace Minesweeper;

public class Tile : Button, IUpdateable {
    public bool ValueVisible {get; private set;}
    public bool HasMine {get; private set;}
    public bool MinesInProximity {get; private set;}
    public bool IsFlagged {get; private set;}

    

    private static readonly Color STANDING = Color.BlanchedAlmond;
    private static readonly Color HIGHLIGHTED = Color.Beige;
    private Color color = STANDING;

    public Tile(){
        
        this.Visual.RollOn += (_,_) => {Console.WriteLine("Roll on"); color = HIGHLIGHTED;};
        this.Visual.Push += (_,_) => {Console.WriteLine("Push"); color = STANDING;};
        this.Visual.Click += (_,_) => {Console.WriteLine("Click"); color = HIGHLIGHTED;};
        this.Visual.RollOff += (_,_) => {Console.WriteLine("Roll off"); color = STANDING;};
    }

    protected override void OnClick()
    {
        base.OnClick();
        //TODO - implement
        Console.WriteLine("TEST");
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.FillRectangle(X,Y,Width,Height,color);
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}