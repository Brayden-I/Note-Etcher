//Code for Playmode
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using Note_Etcher.Components.Controls;
using Note_Etcher.Components.NoteEtcherComponents;
using RenderingLibrary.Graphics;
using System.Linq;
namespace Note_Etcher.Screens;
partial class Playmode : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Playmode");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Playmode - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new Playmode(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(Playmode)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Playmode", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public Album AlbumInstance { get; protected set; }
    public Album AlbumInstance1 { get; protected set; }
    public Album AlbumInstance2 { get; protected set; }
    public TextRuntime Title { get; protected set; }
    public TextRuntime Header { get; protected set; }
    public ContainerRuntime AlbumContainer { get; protected set; }
    public ButtonStandard BackButton { get; protected set; }

    public Playmode(InteractiveGue visual) : base(visual)
    {
    }
    public Playmode()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        AlbumInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Album>(this.Visual,"AlbumInstance");
        AlbumInstance1 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Album>(this.Visual,"AlbumInstance1");
        AlbumInstance2 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<Album>(this.Visual,"AlbumInstance2");
        Title = this.Visual?.GetGraphicalUiElementByName("Title") as global::MonoGameGum.GueDeriving.TextRuntime;
        Header = this.Visual?.GetGraphicalUiElementByName("Header") as global::MonoGameGum.GueDeriving.TextRuntime;
        AlbumContainer = this.Visual?.GetGraphicalUiElementByName("AlbumContainer") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        BackButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"BackButton");
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
