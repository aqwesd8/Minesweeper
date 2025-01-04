using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum.GueDeriving;

namespace Minesweeper;

public class MinesweeperGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameState _gameState;

    private ContainerRuntime Root;
    private Tile button;
    
    public MinesweeperGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        var gumProject = MonoGameGum.GumService.Default.Initialize(
            this.GraphicsDevice);

        Root = new ContainerRuntime();
        Root.Width = 0;
        Root.Height = 0;
        Root.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
        Root.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
        Root.AddToManagers();


        button = new Tile();
        Root.Children.Add(button.Visual);
        button.X = 50;
        button.Y = 50;
        button.Width = 100;
        button.Height = 50;
        button.Text = "Hello MonoGame!";
        //int clickCount = 0;
        // button.Click += (_, _) =>
        // {
        //     clickCount++;
        //     button.Text = $"Clicked {clickCount} times";
        // };
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {

        // TODO: Add your update logic here
        MonoGameGum.GumService.Default.Update(this, gameTime, Root);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        MonoGameGum.GumService.Default.Draw();
        _spriteBatch.Begin();
        button.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
