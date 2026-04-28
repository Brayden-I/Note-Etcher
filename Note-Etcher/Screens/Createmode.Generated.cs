//Code for Createmode
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
partial class Createmode : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Createmode");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Createmode - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new Createmode(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(Createmode)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Createmode", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public ContainerRuntime AlbumContainer { get; protected set; }
    public ColoredRectangleRuntime InfoFrame { get; protected set; }
    public ContainerRuntime ContainerInstance { get; protected set; }
    public ProjectCover ProjectCoverInstance2 { get; protected set; }
    public ProjectCover ProjectCoverInstance { get; protected set; }
    public ProjectCover ProjectCoverInstance1 { get; protected set; }
    public ButtonStandard BackButton { get; protected set; }
    public TextRuntime TitleLabel { get; protected set; }
    public TextRuntime KeywordLabel { get; protected set; }
    public TextRuntime ChangeLabel { get; protected set; }
    public TextRuntime DescriptionLabel { get; protected set; }

    public Createmode(InteractiveGue visual) : base(visual)
    {
    }
    public Createmode()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        AlbumContainer = this.Visual?.GetGraphicalUiElementByName("AlbumContainer") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        InfoFrame = this.Visual?.GetGraphicalUiElementByName("InfoFrame") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        ContainerInstance = this.Visual?.GetGraphicalUiElementByName("ContainerInstance") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        ProjectCoverInstance2 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ProjectCover>(this.Visual,"ProjectCoverInstance2");
        ProjectCoverInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ProjectCover>(this.Visual,"ProjectCoverInstance");
        ProjectCoverInstance1 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ProjectCover>(this.Visual,"ProjectCoverInstance1");
        BackButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"BackButton");
        TitleLabel = this.Visual?.GetGraphicalUiElementByName("TitleLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        KeywordLabel = this.Visual?.GetGraphicalUiElementByName("KeywordLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        ChangeLabel = this.Visual?.GetGraphicalUiElementByName("ChangeLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        DescriptionLabel = this.Visual?.GetGraphicalUiElementByName("DescriptionLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
