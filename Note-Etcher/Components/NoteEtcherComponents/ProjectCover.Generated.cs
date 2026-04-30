//Code for NoteEtcherComponents/ProjectCover (Container)
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
partial class ProjectCover : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("NoteEtcherComponents/ProjectCover");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named NoteEtcherComponents/ProjectCover - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new ProjectCover(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(ProjectCover)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("NoteEtcherComponents/ProjectCover", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public TextRuntime TitleLabel { get; protected set; }
    public TextRuntime KeywordLabel { get; protected set; }
    public TextRuntime ChangeLabel { get; protected set; }
    public ButtonStandard Frame { get; protected set; }
    public ContainerRuntime ContainerInstance { get; protected set; }
    public ButtonIcon SelectButton { get; protected set; }

    public ProjectCover(InteractiveGue visual) : base(visual)
    {
    }
    public ProjectCover()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        TitleLabel = this.Visual?.GetGraphicalUiElementByName("TitleLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        KeywordLabel = this.Visual?.GetGraphicalUiElementByName("KeywordLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        ChangeLabel = this.Visual?.GetGraphicalUiElementByName("ChangeLabel") as global::MonoGameGum.GueDeriving.TextRuntime;
        Frame = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonStandard>(this.Visual,"Frame");
        ContainerInstance = this.Visual?.GetGraphicalUiElementByName("ContainerInstance") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        SelectButton = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ButtonIcon>(this.Visual,"SelectButton");
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
