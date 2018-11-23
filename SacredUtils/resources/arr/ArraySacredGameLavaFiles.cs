using System.IO;

namespace SacredUtils.resources.arr
{
    public static class ArraySacredGameLavaFiles
    {
        public static readonly string[] Files = File.ReadAllLines("$SacredUtils\\conf\\ar.lava.txt");
    }
}
