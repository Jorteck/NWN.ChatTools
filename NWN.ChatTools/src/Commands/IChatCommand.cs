using System.Collections.Generic;
using Anvil.API;

namespace Jorteck.ChatTools
{
  /// <summary>
  /// A game chat command. Implement to add your own chat command.
  /// </summary>
  public interface IChatCommand
  {
    /// <summary>
    /// The default name/alias for this command. Shown in the help list.
    /// </summary>
    string Command { get; }

    /// <summary>
    /// Additional aliases for this command. Not shown in the help list.
    /// </summary>
    string[] Aliases => null;

    /// <summary>
    /// The number of arguments expected by this command. Set to null if the arguments are variable.
    /// </summary>
    int? ArgCount { get; }

    /// <summary>
    /// The description for this command. Shown in the help list.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// A list of valid usages for this command. Shown in the help list.
    /// </summary>
    CommandUsage[] Usages { get; }

    /// <summary>
    /// Additional user data for the command.<br/>
    /// DM-only commands should have [ChatCommandConstants.Keys.DMOnly] = true, and/or the appropriate permissions key.
    /// </summary>
    Dictionary<string, object> UserData { get; }

    /// <summary>
    /// Determines if this command should show in help lists, and can be executed.<br/>
    /// This is not for permissions, but raw server requirements (e.g. dependencies)
    /// </summary>
    bool IsAvailable => true;

    /// <summary>
    /// Process this command with the specified arguments.
    /// </summary>
    /// <param name="caller">The calling player of this command.</param>
    /// <param name="args">Any additional arguments specified.</param>
    void ProcessCommand(NwPlayer caller, IReadOnlyList<string> args);
  }
}
