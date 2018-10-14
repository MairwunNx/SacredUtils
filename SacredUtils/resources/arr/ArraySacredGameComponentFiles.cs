using System.IO;

namespace SacredUtils.resources.arr
{
    public static class ArraySacredGameComponentFiles
    {
        public static string[] Files = File.ReadAllLines("$SacredUtils\\conf\\ch.files.txt");
    }
}
