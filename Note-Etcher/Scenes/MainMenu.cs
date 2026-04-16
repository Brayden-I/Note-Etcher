using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms.Controls;
using Gum.Wireframe;
using MonoGameGum.GueDeriving;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.IScenes;

public class MainMenu : IScene
{
    private Game1 _game;
    private ContentManager _content;
    
    // SPRITES
    private SpriteFont _titleFont;
    
    // Gum UI elements
    private Panel _panel;
    private Button _playButton;
    private Button _createButton;
    private Button _settingsButton;

    private Image _image;

    public MainMenu(Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _panel = new Panel();
        _playButton = new Button();
        _createButton = new Button();
        _settingsButton = new Button();
        _image = new Image();
        
        _panel.AddToRoot();
        _panel.Anchor(Anchor.Left);
        _panel.Height = 200;
        _panel.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        _panel.Width = 400;
        _panel.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        var panelVisual =_panel.Visual;
        panelVisual.ChildrenLayout = Gum.Managers.ChildrenLayout.AutoGridHorizontal;
        
        panelVisual.AutoGridHorizontalCells = 1;
        panelVisual.AutoGridVerticalCells = 3;
        
        _panel.AddChild(_playButton);
        _playButton.Text = "Play";
        _playButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.PLAYMODE);
        
        _panel.AddChild(_createButton);
        _createButton.Text = "Create";
        _createButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.CREATEMODE);
        
        _panel.AddChild(_settingsButton);
        _settingsButton.Text = "Settings";
        _settingsButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.SETTINGS);
        
        _image.AddToRoot();
        _image.Anchor(Anchor.BottomRight);
        _image.Texture = _content.Load<Texture2D>("Sprites/tux");
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
        spriteBatch.DrawString(_titleFont, "Note Etcher", new Vector2(50, 50), Color.White);
    }

    public void UnloadContent()
    {
        _image.RemoveFromRoot();
        _panel.RemoveFromRoot();
        _content.Unload();
    }
}