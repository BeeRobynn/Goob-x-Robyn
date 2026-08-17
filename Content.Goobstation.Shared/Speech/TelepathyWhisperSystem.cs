using Content.Shared._Goobstation.Heretic.Components;
using Content.Shared.Interaction;
using Content.Shared.Mind.Components;
using Content.Shared.Popups;
using Content.Shared.Actions;

namespace Content.Goobstation.Shared.Speech
{
    public abstract partial class TelepathyWhisperSystem : EntitySystem
    {
        [Dependency] private readonly SharedPopupSystem _popup = default!;
        [Dependency] private readonly SharedActionsSystem _actionSystem = default!;

        public override void Initialize()
        {
            base.Initialize();

            SubscribeLocalEvent<TelepathicComponent, InteractHandEvent>(OnInteractHandEvent);
            SubscribeLocalEvent<TelepathicComponent, ComponentInit>(OnTelepathInit);
        }

        private void OnTelepathInit(EntityUid uid, TelepathicComponent component, ComponentInit args)
        {
            _actionSystem.AddAction(uid, ref component.Action, component.ActionEntity);
        }

        private void OnInteractHandEvent(EntityUid user, TelepathicComponent comp, InteractHandEvent args)
        {
            TryWhisper(args.User, args.Target, comp);
        }

        private void TryWhisper(EntityUid user, EntityUid target, TelepathicComponent comp)
        {
            if (!HasComp<MindContainerComponent>(target))
            {
                _popup.PopupEntity(Loc.GetString(comp.FailedPopup), user, PopupType.LargeCaution);
                return;
            }

        }


    }
}
