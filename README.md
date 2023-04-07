### FORKED
Original is here, I forked and updated/fixed to work with Diablo 2 Resurrected D2S files
https://github.com/dschu012/D2SLib

### D2SLib

Simple C# library for reading and writing Diablo 2 saves. Supports version 1.10 through Diablo II: Resurrected (1.15). Supports reading both d2s (player saves) and d2i (shared stash) files.


### Usage

```
using D2SLib;
using D2SLib.Model.Save;

....
// Get all D2S Files into an array so we can pick one easily (better to use FileDialog)
SavedGamesDirectory = (Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))?.FullName!) + "\\Saved Games\\Diablo II Resurrected\\";
SavedGames = Directory.GetFiles(SavedGamesDirectory, "*.d2s", SearchOption.TopDirectoryOnly).Select(file => new FileInfo(file)).ToDictionary(f => Path.GetFileNameWithoutExtension(f.Name), f => f.FullName);

// Open said file using the path we want
D2S Char = Core.ReadD2S(SavedGames.ElementAt(1).Value);

// Modify attributes if you want
Char.Attributes.Level = 99;
Char.Attributes.Gold = 10000 * 99;
Char.Attributes.StashGold = 2500000;

// Optional save as json to be human readable (using JsonConvert (newtonsoft.json package) as it supports decent beautification)
Char.SaveJsonCharacter(".\\test.json", JsonConvert.SerializeObject(Char, Formatting.Indented));
// Save the character
Char.SaveCharacter();

```

How to seed the library with your own TXT files
```
All converted to a SQLite Library as well as tools to convert the library to sql :D
```

##### Useful Links:
* https://github.com/d07RiV/d07riv.github.io/blob/master/d2r.html (credits to d07riv for reversing the item code on D2R)
* https://github.com/nokka/d2s
* https://github.com/krisives/d2s-format
* http://paul.siramy.free.fr/d2ref/eng/
* http://user.xmission.com/~trevin/DiabloIIv1.09_File_Format.shtml
* https://github.com/nickshanks/Alkor
* https://github.com/HarpyWar/d2s-character-editor
