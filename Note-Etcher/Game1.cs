using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms;
using Gum.Forms.Controls;
using Note_Etcher.IScenes;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MouseCursor _cursor;
    
    // Scenes
    public SceneManager _sceneManager { get; private set; }
    public GumService GumUI => GumService.Default;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        GumUI.Initialize(this);
        _sceneManager = new SceneManager();
        
        _sceneManager.Register(Scenes.MAINMENU, new MainMenu(this));
        _sceneManager.Register(Scenes.SETTINGS, new SettingsMenu(this));
        _sceneManager.SwitchTo(Scenes.MAINMENU);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        var cursorTexture = Content.Load<Texture2D>("Cursors/cursor_none");
        _cursor = MouseCursor.FromTexture2D(cursorTexture, 0, 0);
    }

    protected override void Update(GameTime gameTime)
    {
        Mouse.SetCursor(_cursor);
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.F4))
            Exit();
        
        GumUI.Update(gameTime);
        _sceneManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);
        _spriteBatch.Begin();
        
        var fps = 1.0 / gameTime.ElapsedGameTime.TotalSeconds;
        Window.Title = $"Note Etcher - FPS: {fps:0}";
        
        _sceneManager.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
        GumUI.Draw();
        base.Draw(gameTime);
    }
}