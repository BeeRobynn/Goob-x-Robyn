using Content.Goobstation.Shared.Speech;
using Robust.Client.UserInterface;
using Robust.Shared.GameObjects;
using Robust.Client.UserInterface.XAML;

namespace Content.Goobstation.Client.Speech;

public partial class TelepathyBoundUserInterface : BoundUserInterface
{
    private readonly TelepathyWhisperSystem _whisperSystem;

    [ViewVariables]
    private TelepathyWindow? _menu;

    public TelepathyBoundUserInterface(EntityUid owner, Enum uiKey, TelepathyWhisperSystem whisperSystem) : base(owner,
        uiKey)
    {
        _whisperSystem = EntMan.System<TelepathyWhisperSystem>();
    }

    protected override void Open()
    {
        base.Open();

        if (_menu == null)
            CreateMenu();
    }

    private void CreateMenu()
    {
        _menu = this.CreateWindowCenteredLeft<TelepathyWindow>();
    }
}
