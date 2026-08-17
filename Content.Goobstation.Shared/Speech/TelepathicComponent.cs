using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.Speech;

[RegisterComponent]
public sealed partial class TelepathicComponent : Component
{
    [DataField]
    public string FailedPopup = "telepathy-system-failed-popup";

    [DataField]
    public EntProtoId ActionEntity = "ActionTelepathicCommunication";

    [DataField]
    public EntityUid? Action;

}
