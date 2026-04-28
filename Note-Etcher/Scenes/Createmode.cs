using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using Gum.Forms.Controls;
using Note_Etcher.Components.NoteEtcherComponents;
using Note_Etcher.Data;
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
    
    private void LoadProjects()
    {
        _gumScreen.AlbumContainer.Children.Clear();

        foreach (var album in AlbumLoader.LoadAll())
        {
            var cover = new ProjectCover();
            cover.TitleLabel.Text = album.Details.Name;
            cover.KeywordLabel.Text = string.Join(", ", album.Details.Keywords);
            cover.ChangeLabel.Text = album.Details.LastUpdated;
            _gumScreen.AlbumContainer.Children.Add(cover.Visual);
        }
    }

    public void LoadContent()
    {
        _titleFont = _content.Load<SpriteFont>("Fonts/TitleFont");

        _gumScreen = new Screens.Createmode();
        _gumScreen.Game = _game;
        _gumScreen.AddToRoot();
        
        LoadProjects();
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