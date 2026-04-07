using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Note_Etcher;

enum Scenes
{
    MAINMENU,
    SETTINGS
}
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private MouseCursor _cursor;
    private Scenes ActiveScene;
    
    bool SpaceKeyPressed = false;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        ActiveScene = Scenes.MAINMENU;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

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
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        switch (ActiveScene)
        {
            case  Scenes.MAINMENU:
                // TODO: Add main menu logic
                break;
            case  Scenes.SETTINGS:
                // TODO: Add Settings menu logic
                break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (SpaceKeyPressed)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
        else
        {
            GraphicsDevice.Clear(Color.DarkRed);
        }
        

        base.Draw(gameTime);
    }
}
