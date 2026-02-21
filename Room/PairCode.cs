using System.Security.Cryptography;

namespace Helmz.Core.Room;

public readonly record struct PairCode
{
    public string Value { get; }

    private PairCode(string value) => Value = value;

    public static PairCode Generate()
    {
        var code = RandomNumberGenerator.GetInt32(100000, 1000000);
        return new PairCode(code.ToString("D6", System.Globalization.CultureInfo.InvariantCulture));
    }

    public static PairCode Parse(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        if (code.Length != 6 || !int.TryParse(code, out var val) || val < 100000)
            throw new ArgumentException("Pair code must be a 6-digit number.", nameof(code));
        return new PairCode(code);
    }

    public override string ToString() => Value;
}
