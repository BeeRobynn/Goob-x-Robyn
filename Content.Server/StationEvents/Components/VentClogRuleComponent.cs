// SPDX-License-Identifier: MIT

using Content.Server.StationEvents.Events;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;

namespace Content.Server.StationEvents.Components;

[RegisterComponent, Access(typeof(VentClogRule))]
public sealed partial class VentClogRuleComponent : Component
{
    /// <summary>
    /// Sound played when foam is being created.
    /// </summary>
    [DataField]
    public SoundSpecifier Sound = new SoundPathSpecifier("/Audio/Effects/extinguish.ogg");

    /// <summary>
    /// The standard reagent quantity to put in the foam, modified by event severity.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int ReagentQuantity = 100;

    /// <summary>
    /// The standard spreading of the foam, not modified by event severity.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public int Spread = 16;

    /// <summary>
    /// How long the foam lasts for
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float Time = 20f;
}
