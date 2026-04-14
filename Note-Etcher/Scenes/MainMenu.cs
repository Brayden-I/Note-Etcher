using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms.Controls;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.IScenes;

public class MainMenu : IScene
{
    private Game1 _game;
    private ContentManager _content;
    
    // SPRITES
    private Texture2D _logo;
    
    // Gum UI elements
    private Button _settingsButton;

    public MainMenu(Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _logo = _content.Load<Texture2D>("Sprites/tux");
        
        _settingsButton = new Button();
        _settingsButton.Text = "Settings";
        _settingsButton.X = 100;
        _settingsButton.Y = 100;
        _settingsButton.AddToRoot();
        _settingsButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.SETTINGS);
    }

    private KeyboardState _prevKeyboard;

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Escape) && _prevKeyboard.IsKeyUp(Keys.Escape))
        {
            Console.WriteLine("switching to settings");
            _game._sceneManager.SwitchTo(Scenes.SETTINGS);
        }
        _prevKeyboard = keyboard;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_logo, Vector2.Zero, Color.White);
    }

    public void UnloadContent()
    {
        _settingsButton.RemoveFromRoot();
        _content.Unload();
    }
}