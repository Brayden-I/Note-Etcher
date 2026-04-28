//Code for MainMenu
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using Note_Etcher.Components.Controls;
using Note_Etcher.Components.Elements;
using RenderingLibrary.Graphics;
using System.Linq;
namespace Note_Etcher.Screens;
partial class MainMenu : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("MainMenu");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named MainMenu - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new MainMenu(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(MainMenu)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("MainMenu", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public TextRuntime Title { get; protected set; }
    public ButtonStandard PlayButton { get; protected set; }
    public ButtonStandard CreateButton { get; protected set; }
    public ButtonStandard SettingsButton { get; protected set; }
    public DividerVertical DividerVerticalInstance { get; protected set; }
    public TextRuntime NewsHeader { get; protected set; }
    public ContainerRuntime NewsBox { get; protected set; }

    public MainMenu(InteractiveGue visual) : base(visual)
    {
    }
    public MainMenu()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Title = this.Visual?.GetGraphicalUiElementByName("Title") as global::MonoGameGum.GueDeriving.TextRuntime;
        PlayButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"PlayButton");
        CreateButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"CreateButton");
        SettingsButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"SettingsButton");
        DividerVerticalInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<DividerVertical>(this.Visual,"DividerVerticalInstance");
        NewsHeader = this.Visual?.GetGraphicalUiElementByName("NewsHeader") as global::MonoGameGum.GueDeriving.TextRuntime;
        NewsBox = this.Visual?.GetGraphicalUiElementByName("NewsBox") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
