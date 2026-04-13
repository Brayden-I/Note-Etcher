using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.IScenes;

public class SettingsMenu : IScene
{
    private Game1 _game;
    private ContentManager _content;
    
    // SPRITES
    private Texture2D _logo;

    public SettingsMenu(Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _logo = _content.Load<Texture2D>("Sprites/tux-cartoon");
    }

    private KeyboardState _prevKeyboard;

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Escape) && _prevKeyboard.IsKeyUp(Keys.Escape))
        {
            Console.WriteLine("switching to main menu");
            _game._sceneManager.SwitchTo(Scenes.MAINMENU);
        }
        _prevKeyboard = keyboard;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_logo, Vector2.Zero, Color.White);
    }

    public void UnloadContent()
    {
        _content.Unload();
    }
}