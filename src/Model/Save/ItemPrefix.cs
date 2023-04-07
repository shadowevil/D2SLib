using D2SLib.IO;
using D2SLib.Model.Data;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;

namespace D2SLib.Model.Save;

public class ItemPrefix
{
    public ushort ID { get; private set; }
    public string Name { get; private set; } = string.Empty;

}

public class PrefixSkill
{

}