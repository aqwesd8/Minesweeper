﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input;
using MonoGame.Extended.Screens;

namespace Minesweeper;

public class MinesweeperGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public SpriteBatch SpriteBatch {get => _spriteBatch;}
    private GameState _gameState;
    private Tile button;
    private Matrix scale;
    private ScreenManager _screenManager;
    private readonly float virtualWidth;
    private readonly float virtualHeight;

    public GraphicsDeviceManager  Graphics => _graphics;

    public Board Board {get; private set;}
    
    public MinesweeperGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        virtualWidth = _graphics.PreferredBackBufferWidth;
        virtualHeight = _graphics.PreferredBackBufferHeight;
        Board = new Board(this);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        var gumProject = MonoGameGum.GumService.Default.Initialize(
            this.GraphicsDevice);

        button = new Tile(100,100,50,50,false,Vector2.One, this);

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnSizeChange;
        scale = Matrix.CreateScale(1,1,1);
        _screenManager = new ScreenManager();
        Components.Add(_screenManager);
        Components.Add(Board);
        base.Initialize();
    }

    private void OnSizeChange(object? sender = null, EventArgs? args = null){
        _graphics.PreferredBackBufferWidth = GraphicsDevice.Viewport.Width;
        _graphics.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height;
        _graphics.ApplyChanges();

        float scaleX = _graphics.PreferredBackBufferWidth/virtualWidth;
        float scaleY = _graphics.PreferredBackBufferHeight/virtualHeight;

        //SystemManagers.Default.Renderer.Camera.Zoom = scaleX;
        // GraphicalUiElement.CanvasWidth = virtualWidth;
        // GraphicalUiElement.CanvasHeight = virtualHeight;
        // Root.UpdateLayout();
        scale = Matrix.CreateScale(scaleX, scaleY,1);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {

        // TODO: Add your update logic here
        //MonoGameGum.GumService.Default.Update(this, gameTime, Root);
        MouseExtended.Update();
        ScaledMouse.Update(scale);
        //button.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        //MonoGameGum.GumService.Default.Draw();
        _spriteBatch.Begin(transformMatrix : scale);
        //button.Draw(gameTime, _spriteBatch);
        base.Draw(gameTime);
        _spriteBatch.End();
        
    }



}
