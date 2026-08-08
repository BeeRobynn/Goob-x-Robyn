using Content.Shared.Speech;
using Content.Shared.Eye;

namespace Content.Goobstation.Server.ImaginaryFriend;
/// <summary>
/// This handles the visibility for Imaginary Friends
/// </summary>
///
/// This is just a basic hardcoded system at the moment since its just for chaplain,
/// future expansion to an actual Imaginary Friend midround will need to make a
/// whole new system for people to see only their one and not others, this
/// will just let you see everyones
public sealed class ImaginaryFriendSystem : EntitySystem
{

    [Dependency] private readonly SharedEyeSystem _eye = default!;
    private const int ImaginaryFriendFlags = (int) VisibilityFlags.ImaginaryFriend;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CanSeeImaginaryComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<CanSeeImaginaryComponent, ComponentShutdown>(OnShutdown);
        SubscribeLocalEvent<ImaginaryFriendComponent, ListenEvent>(OnListen);
    }
    private void OnStartup(
        EntityUid uid,
        CanSeeImaginaryComponent component,
        ComponentStartup args)
    {
        if (TryComp(uid, out EyeComponent? eyeComp))
            _eye.SetVisibilityMask(uid, eyeComp.VisibilityMask | ImaginaryFriendFlags, eyeComp);
    }
    private void OnShutdown(
        EntityUid uid,
        CanSeeImaginaryComponent component,
        ComponentShutdown args)
    {
        if (TryComp<EyeComponent>(uid, out var eye))
            _eye.SetVisibilityMask(uid, eye.VisibilityMask & ~ImaginaryFriendFlags, eye);
    }

    private void OnListen(Entity<ImaginaryFriendComponent> ent, ref ListenEvent args)
    {

    }

}
