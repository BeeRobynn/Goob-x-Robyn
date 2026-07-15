// SPDX-License-Identifier: MIT

using Content.Server.StationEvents.Events;

namespace Content.Goobstation.Server.StationEvents.Components;

[RegisterComponent, Access(typeof(VentClogRule))]
public sealed partial class VentBlacklistComponent : Component
{
    /// <summary>
    /// Marks any reagent blacklisted from the vent clog station event
    /// True if Blacklisted
    /// </summary>
    [DataField]
    public bool Blacklisted = true;
}
