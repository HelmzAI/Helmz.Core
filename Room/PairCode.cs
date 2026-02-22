using System.Security.Cryptography;

namespace Helmz.Core.Room;

/// <summary>
/// Represents a 6-digit pairing code used to connect a mobile client to a daemon room.
/// </summary>
public readonly record struct PairCode
{
    /// <summary>
    /// Gets the 6-digit string value of the pair code.
    /// </summary>
    public string Value { get; }

    private PairCode(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Generates a new cryptographically random 6-digit pair code.
    /// </summary>
    /// <returns>A new <see cref="PairCode"/> with a random 6-digit value.</returns>
    public static PairCode Generate()
    {
        int code = RandomNumberGenerator.GetInt32(100000, 1000000);
        return new PairCode(code.ToString("D6", System.Globalization.CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Parses a string into a <see cref="PairCode"/>, validating that it is a valid 6-digit number.
    /// </summary>
    /// <param name="code">The 6-digit string to parse.</param>
    /// <returns>The parsed <see cref="PairCode"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the code is not a valid 6-digit number.</exception>
    public static PairCode Parse(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        return code.Length != 6 || !int.TryParse(code, out int val) || val < 100000
            ? throw new ArgumentException("Pair code must be a 6-digit number.", nameof(code))
            : new PairCode(code);
    }

    /// <summary>
    /// Returns the 6-digit string representation of this pair code.
    /// </summary>
    /// <returns>The pair code value as a string.</returns>
    public override string ToString()
    {
        return Value;
    }
}
