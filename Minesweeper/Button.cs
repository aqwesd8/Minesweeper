using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Input;

namespace Minesweeper;

public class Button : DrawableGameComponent {

    public float X;
    public float Y;
    public float Width;
    public float Height;
    protected bool wasPushed = false;
    protected bool mouseOnTile = false;
    protected bool mouseWasOnTile = false;
    protected bool isPush = false;
    protected bool isClick = false;
    

    private static readonly Color STANDING = Color.BlanchedAlmond;
    private static readonly Color HIGHLIGHTED = Color.Beige;
    private static readonly Color PUSHED = Color.BurlyWood;
    private Color color = STANDING;

    public event EventHandler Click;
    public event EventHandler Push;
    public event EventHandler RollOn;
    public event EventHandler RollOff;
    public event EventHandler RightClick;

    public Button(float x, float y, float width, float height, MinesweeperGame game) :base(game) {
        X = x;
        Y = y;
        Width = width;
        Height = height; 
        Click = (_,_) => OnClick();
        Push = (_,_) => OnPush();
        RollOn = (_,_) => OnRollOn();
        RollOff = (_,_) => OnRollOff();
        RightClick = (_,_) => OnRightClick();
    }
    public Button(MinesweeperGame game) : this(0,0,0,0, game){}

    

    protected virtual void OnClick()
    {
        //TODO - implement
        color = HIGHLIGHTED;
        Console.WriteLine("TEST");
    }
    protected virtual void OnPush()
    {
        color = PUSHED;
    }
    protected virtual void OnRollOn()
    {
        color = HIGHLIGHTED;
    }  
    protected virtual void OnRollOff()
    {
        color = STANDING;
    }

    protected virtual void OnRightClick()
    {
        color = Color.Black;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.FillRectangle(X,Y,Width,Height,color);
        spriteBatch.DrawRectangle(X,Y,Width,Height,Color.Black);
    }

    public override void Update(GameTime gameTime)
    {

        ScaledMouseState ms = ScaledMouse.GetState();
        float mouseX= ms.X;
        float mouseY = ms.Y;
        float prevX = ms.Previous_X;
        float prevY = ms.Previous_Y;
        

        mouseOnTile = mouseX >= X && mouseX <= X+Width && mouseY >= Y && mouseY <= Y+Height;
        mouseWasOnTile = prevX >= X && prevX <= X+Width && prevY >= Y && prevY <= Y+Height;

        MouseStateExtended state = MouseExtended.GetState();

        isPush = mouseOnTile && state.WasButtonPressed(MouseButton.Left);
        
        wasPushed = wasPushed || isPush;
        isClick = mouseOnTile && state.WasButtonReleased(MouseButton.Left) && wasPushed;
        bool rightClick = mouseOnTile && state.WasButtonPressed(MouseButton.Right);
        //bool rightRelease = mouseOnTile && state.WasButtonReleased(MouseButton.Right);

        if(!mouseWasOnTile && mouseOnTile) RollOn.Invoke(this, EventArgs.Empty);
        if(mouseWasOnTile && !mouseOnTile) {RollOff.Invoke(this, EventArgs.Empty); wasPushed = false;}
        if(isPush) Push.Invoke(this, EventArgs.Empty);
        if(isClick) {Click.Invoke(this, EventArgs.Empty); wasPushed = false;}
        if(rightClick) RightClick.Invoke(this, EventArgs.Empty);

    }

    public override void Draw(GameTime gameTime)
    {
        Draw(gameTime, ((MinesweeperGame)Game).SpriteBatch);
    }

    public override void Initialize()
    {
        base.Initialize();
        Enabled = true;   
    }
}