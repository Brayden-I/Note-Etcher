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
    
    // SPRITES
    private Texture2D _logo;
    
    // Gum UI elements
    private Panel _panel;
    private Button _mainMenuButton;

    public Createmode (Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _logo = _content.Load<Texture2D>("Sprites/tux");
        
        _panel = new Panel();
        _mainMenuButton = new Button();
        
        _panel.AddToRoot();
        _panel.Anchor(Gum.Wireframe.Anchor.BottomLeft);
        
        _panel.AddChild(_mainMenuButton);
        _mainMenuButton.Text = "Back to Main Menu";
        _mainMenuButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.MAINMENU);
    }

    private KeyboardState _prevKeyboard;

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Escape) && _prevKeyboard.IsKeyUp(Keys.Escape))
        {
            Console.WriteLine("switching");
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
        _panel.RemoveFromRoot();
        _content.Unload();
    }
}