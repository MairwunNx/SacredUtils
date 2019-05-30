using System.IO;

namespace SacredUtils.resources.arr
{
    public static class ArraySacredGameComponentFiles
    {
        public static readonly string[] Files =
            File.ReadAllLines("$SacredUtils\\conf\\ch.files.txt");
    }
}
