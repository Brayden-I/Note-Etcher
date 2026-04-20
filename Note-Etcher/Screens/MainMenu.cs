using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using RenderingLibrary.Graphics;
using System.Linq;
using Note_Etcher.IScenes.Essentials;

namespace Note_Etcher.Screens
{
    partial class MainMenu
    {
        public Game1 Game { get; set; }
        
        partial void CustomInitialize()
        {
            PlayButton.Click += (_, _) =>
                Game._sceneManager.SwitchTo(Scenes.PLAYMODE);
            CreateButton.Click += (_, _) =>
                Game._sceneManager.SwitchTo(Scenes.CREATEMODE);
            SettingsButton.Click += (_, _) =>
                Game._sceneManager.SwitchTo(Scenes.SETTINGS);
        }
    }
}