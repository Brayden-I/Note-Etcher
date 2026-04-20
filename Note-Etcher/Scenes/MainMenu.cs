using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Gum.Forms.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Note_Etcher.IScenes.Essentials;
using Note_Etcher.Screens;

namespace Note_Etcher.IScenes;

public class MainMenu : IScene
{
    private Game1 _game;
    private ContentManager _content;
    private Screens.MainMenu _gumScreen;
    private SpriteFont _titleFont;
    private KeyboardState _prevKeyboard;

    private async Task FetchNotices()
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "NoteEtcher");
            var xml = await client.GetStringAsync("https://lwn.net/headlines/rss");
            var doc = XDocument.Parse(xml);
            var items = doc.Descendants("item");

            foreach (var item in items.Take(5))
            {
                var title = item.Element("title")?.Value ?? "";
                var notice = new Label();
                notice.Text = $"• {title}";
                notice.Visual.HeightUnits = Gum.DataTypes.DimensionUnitType.Ratio;
                notice.Visual.Height = 1;
                _gumScreen.NewsBox.AddChild(notice);
            }
        }
        catch
        {
            // fail silently
        }
    }

    public MainMenu(Game1 game)
    {
        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _gumScreen = new Screens.MainMenu();
        _gumScreen.Game = _game;
        _gumScreen.AddToRoot();

        _ = FetchNotices();
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