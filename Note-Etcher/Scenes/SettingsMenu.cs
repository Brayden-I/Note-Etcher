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

public class SettingsMenu : IScene
{
    private Game1 _game;
    private ContentManager _content;
    private Screens.SettingsMenu _gumScreen;
    private SpriteFont _titleFont;
    private KeyboardState _prevKeyboard;

    public SettingsMenu(Game1 game)
    {

        _game = game;
        _content = new ContentManager(game.Services, "Content");
    }

    public void LoadContent()
    {
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _gumScreen = new Screens.SettingsMenu();
        _gumScreen.Game = _game;
        _gumScreen.AddToRoot();
    }

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

    }

    public void UnloadContent()
    {
        _gumScreen.RemoveFromRoot();
        _content.Unload();
    }
}