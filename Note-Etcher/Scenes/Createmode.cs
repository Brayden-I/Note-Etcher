using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms.Controls;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.IScenes;

public class Createmode : IScene
{
    private Game1 _game;
    private ContentManager _content;
    private Screens.Createmode _gumScreen;
    private SpriteFont _titleFont;
    private KeyboardState _prevKeyboard;

    public Createmode (Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _gumScreen = new Screens.Createmode();
        _gumScreen.Game = _game;
        _gumScreen.AddToRoot();
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Escape) && _prevKeyboard.IsKeyUp(Keys.Escape))
            _game._sceneManager.SwitchTo(Scenes.SETTINGS);
        _prevKeyboard = keyboard;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {

    }

    public void UnloadContent()
    {
        _gumScreen.RemoveFromRoot();
        _content.Unload();
    }
}