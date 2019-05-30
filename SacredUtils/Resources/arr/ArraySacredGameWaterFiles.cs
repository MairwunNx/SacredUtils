using System.IO;

namespace SacredUtils.resources.arr
{
    public static class ArraySacredGameWaterFiles
    {
        public static readonly string[] Files =
            File.ReadAllLines("$SacredUtils\\conf\\ar.watr.txt");
    }
}
