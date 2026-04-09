using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Note_Etcher.IScenes;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MouseCursor _cursor;
    private SceneManager _sceneManager;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _sceneManager = new SceneManager();
        _sceneManager.Register(Scenes.MAINMENU, new MainMenu(this));
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
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _sceneManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);
        _spriteBatch.Begin();
        _sceneManager.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}