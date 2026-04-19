using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    private Image _logo;
    
    // Gum UI elements
    private Panel _menuPanel;
    
    private Button _playButton;
    private Button _createButton;
    private Button _settingsButton;
    
    private Panel _newsPanel;
    private Label _newsLabel;
    
    private async Task FetchNotices()
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "NoteEtcher");
            var xml = await client.GetStringAsync("https://lwn.net/headlines/rss");
            var doc = XDocument.Parse(xml);
            var items = doc.Descendants("item");
        
            foreach (var item in items.Take(3))
            {
                var title = item.Element("title")?.Value ?? "";
                var notice = new Label();
                notice.Text = $"• {title}";
                _newsPanel.AddChild(notice);
            }
        }
        catch
        {
            _newsLabel.Text = "Could not load news.";
        }
    }
        
    public MainMenu(Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        // Initiate elements
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _menuPanel = new Panel();
        
        _playButton = new Button();
        _createButton = new Button();
        _settingsButton = new Button();
        _logo = new Image();
        
        _newsPanel = new Panel();
        _newsLabel = new Label();

        // Menu buttons
        _menuPanel.AddToRoot();
        _menuPanel.Anchor(Anchor.Left);
        _menuPanel.Height = 200;
        _menuPanel.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        _menuPanel.Width = 400;
        _menuPanel.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        var panelVisual =_menuPanel.Visual;
        panelVisual.ChildrenLayout = Gum.Managers.ChildrenLayout.AutoGridHorizontal;
        
        panelVisual.AutoGridHorizontalCells = 1;
        panelVisual.AutoGridVerticalCells = 3;
        
        _menuPanel.AddChild(_playButton);
        _playButton.Text = "Play";
        _playButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.PLAYMODE);
        
        _menuPanel.AddChild(_createButton);
        _createButton.Text = "Create";
        _createButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.CREATEMODE);
        
        _menuPanel.AddChild(_settingsButton);
        _settingsButton.Text = "Settings";
        _settingsButton.Click += (_, _) =>
            _game._sceneManager.SwitchTo(Scenes.SETTINGS);
        
        // News Box
        _newsPanel.AddToRoot();
        _newsPanel.Anchor(Anchor.Center);
        _newsPanel.Width = 300;
        _newsPanel.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        _newsPanel.Height = 400;
        _newsPanel.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
        _newsPanel.Visual.ChildrenLayout = Gum.Managers.ChildrenLayout.TopToBottomStack;

        _ = FetchNotices();
        
        // Tux
        _logo.AddToRoot();
        _logo.Anchor(Anchor.BottomRight);
        _logo.Texture = _content.Load<Texture2D>("Sprites/tux");
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
        spriteBatch.DrawString(_titleFont, "Note Etcher", new Vector2(100, 50), Color.White);
    }

    public void UnloadContent()
    {
        _menuPanel.RemoveFromRoot();
        _newsPanel.RemoveFromRoot();
        _logo.RemoveFromRoot();
        _content.Unload();
    }
}