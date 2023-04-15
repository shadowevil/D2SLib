using D2SLib.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static D2SLib.Core;

namespace D2SLib.Model.Structure;

public class Progression
{
    private byte progressionByte;

    public enum Classic : byte
    {
        NONE = 0,
        SIR_DAME = 4,
        LORD_LADY = 8,
        BARON_BARONESS = 12
    }

    public enum Classic_Hardcore : byte
    {
        NONE = 0,
        COUNT_COUNTRESS = 5,
        DUKE_DUCHESS = 9,
        KING_QUEEN = 13
    }

    public enum Expansion : byte
    {
        NONE = 0,
        SLAYER = 5,
        CHAMPION = 10,
        PATRIARCH_MATRIARCH = 15
    }

    public enum Expansion_Hardcore : byte
    {
        NONE = 0,
        DESTROYER = 6,
        CONQUEROR = 11,
        GUARDIAN = 15
    }

    private Progression(byte _byte)
    {
        progressionByte = _byte;
    }

    public static Progression ReadProgressionByte(IBitReader reader)
    {
        return new Progression(reader.ReadByte());
    }

    public void Write(IBitWriter writer)
    {
        writer.WriteByte(progressionByte);
    }

    public Enum GetProgressionEnum
    {
        get
        {
            if (D2S.Instance != null)
            {
                if (D2S.Instance.Status.IsExpansion)
                {
                    if (D2S.Instance.Status.IsHardcore)
                    {
                        return (Expansion_Hardcore)progressionByte;
                    }
                    return (Expansion)progressionByte;
                }
                else
                {
                    if (D2S.Instance.Status.IsHardcore)
                    {
                        return (Classic_Hardcore)progressionByte;
                    }
                    return (Classic)progressionByte;
                }
            }
            return (Classic)progressionByte;
        }
    }

    public void UpdateProgression(Enum value)
    {
        Type t = value.GetType();
        if (t == typeof(Classic) && Enum.IsDefined(typeof(Classic), value))
        {
            progressionByte = (byte)(Classic)value;
        }
        else if (t == typeof(Classic_Hardcore) && Enum.IsDefined(typeof(Classic_Hardcore), value))
        {
            progressionByte = (byte)(Classic_Hardcore)value;
        }
        else if (t == typeof(Expansion) && Enum.IsDefined(typeof(Expansion), value))
        {
            progressionByte = (byte)(Expansion)value;
        }
        else if (t == typeof(Expansion_Hardcore) && Enum.IsDefined(typeof(Expansion_Hardcore), value))
        {
            progressionByte = (byte)(Expansion_Hardcore)value;
        }
        else return;
    }

    public string ProgressionString
    {
        get
        {
            if (D2S.Instance != null)
            {
                if (D2S.Instance.Status.IsExpansion)
                {
                    if (D2S.Instance.Status.IsHardcore)
                    {
                        return GetProgressionString<Expansion_Hardcore>(D2S.Instance.CharacterClass);
                    }
                    return GetProgressionString<Expansion>(D2S.Instance.CharacterClass);
                }
                else
                {
                    if (D2S.Instance.Status.IsHardcore)
                    {
                        return GetProgressionString<Classic_Hardcore>(D2S.Instance.CharacterClass);
                    }
                    return GetProgressionString<Classic>(D2S.Instance.CharacterClass);
                }
            }
            return string.Empty;
        }
    }
    private string GetProgressionString<T>(Classes classes) where T : Enum
    {
        foreach (T enumValue in Enum.GetValues(typeof(T)))
        {
            if (Convert.ToInt32(enumValue) == progressionByte)
            {
                string enumName = enumValue.ToString().ToLower();
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                if (enumName.Contains('_'))
                {
                    if (classes == Classes.AMAZON || classes == Classes.SORCERESS || classes == Classes.ASSASSIN)
                    {
                        return textInfo.ToTitleCase(enumName.Split('_')[1]);
                    }
                    else
                    {
                        return textInfo.ToTitleCase(enumName.Split('_')[0]);
                    }
                }
                return textInfo.ToTitleCase(enumName);
            }
        }
        return "Unknown";
    }
}
