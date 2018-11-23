using System.IO;

namespace SacredUtils.resources.arr
{
    public static class ArraySacredGameOldTextureFiles
    {
        public static readonly string[] Files = File.ReadAllLines("$SacredUtils\\conf\\ar.odtx.txt");
    }
}
