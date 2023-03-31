using D2SLib.IO;
using System.Diagnostics.CodeAnalysis;

namespace D2SLib.Model.Save;

public class Difficulties
{
    private readonly Difficulty[] _difficulties = new Difficulty[3];

    public Difficulty Normal { get => _difficulties[0]; set => _difficulties[0] = value; }
    public Difficulty Nightmare { get => _difficulties[1]; set => _difficulties[1] = value; }
    public Difficulty Hell { get => _difficulties[2]; set => _difficulties[2] = value; }

    public void Write(IBitWriter writer)
    {
        for (int i = 0; i < _difficulties.Length; i++)
        {
            _difficulties[i].Write(writer);
        }
    }

    public static Difficulties Read(IBitReader reader)
    {
        var difficulty = new Difficulties();
        var places = difficulty._difficulties;
        for (int i = 0; i < places.Length; i++)
        {
            places[i] = Difficulty.Read(reader);
        }
        return difficulty;
    }

    [Obsolete("Try the direct-read overload!")]
    public static Difficulties Read(ReadOnlySpan<byte> bytes)
    {
        using var reader = new BitReader(bytes);
        return Read(reader);
    }

    [Obsolete("Try the non-allocating overload!")]
    public static byte[] Write(Difficulties difficulties)
    {
        using var writer = new BitWriter();
        difficulties.Write(writer);
        return writer.ToArray();
    }
}

public readonly struct Difficulty : IEquatable<Difficulty>
{
    public Difficulty(bool active, byte act)
    {
        Active = active;
        Act = act;
    }

    public readonly bool Active { get; }
    public readonly byte Act { get; }

    public void Write(IBitWriter writer)
    {
        byte b = 0x0;
        if (Active)
        {
            b |= 0x7;
        }

        b |= (byte)(Act - 1);

        writer.WriteByte(b);
    }

    public static Difficulty Read(IBitReader reader)
    {
        byte b = reader.ReadByte();
        return new Difficulty(
            active: (b >> 7) == 1,
            act: (byte)((b & 0x5) + 1)
        );
    }

    public bool Equals(Difficulty other)
    {
        return Active == other.Active
            && Act == other.Act;
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Difficulty other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Active, Act);

    public static bool operator ==(Difficulty left, Difficulty right) => left.Equals(right);

    public static bool operator !=(Difficulty left, Difficulty right) => !left.Equals(right);
}
