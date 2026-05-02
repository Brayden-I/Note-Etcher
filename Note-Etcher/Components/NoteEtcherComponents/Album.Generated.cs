//Code for NoteEtcherComponents/Album (Container)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using Note_Etcher.Components.Controls;
using RenderingLibrary.Graphics;
using System.Linq;
namespace Note_Etcher.Components.NoteEtcherComponents;
partial class Album : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("NoteEtcherComponents/Album");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named NoteEtcherComponents/Album - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new Album(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(Album)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("NoteEtcherComponents/Album", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public TextRuntime TitleLabel { get; protected set; }
    public TextRuntime KeywordLabel { get; protected set; }
    public TextRuntime AuthorLabel { get; protected set; }
    public ColoredRectangleRuntime Frame { get; protected set; }
    public ContainerRuntime ContainerInstance { get; protected set; }
    public ButtonIcon PlayButton { get; protected set; }

    public Album(InteractiveGue visual) : base(visual)
    {
    }
    public Album()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        TitleLabel = this.Visual?.GetGraphicalUiElementByName("TitleLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        KeywordLabel = this.Visual?.GetGraphicalUiElementByName("KeywordLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        AuthorLabel = this.Visual?.GetGraphicalUiElementByName("AuthorLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        Frame = this.Visual?.GetGraphicalUiElementByName("Frame") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        ContainerInstance = this.Visual?.GetGraphicalUiElementByName("ContainerInstance") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        PlayButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonIcon>(this.Visual,"PlayButton");
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
