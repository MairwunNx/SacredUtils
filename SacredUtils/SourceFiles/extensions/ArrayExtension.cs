using System.Text;
using Castle.Core.Internal;

namespace SacredUtils.SourceFiles.extensions
{
    public static class ArrayExtension
    {
        public static string ToNormalString(this string[] stringArray)
        {
            if (stringArray.IsNullOrEmpty())
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var str in stringArray)
            {
                stringBuilder.Append(
                    str == stringArray[stringArray.Length - 1]
                        ? str
                        : $"{str}, "
                );
            }

            return $"[{stringBuilder}]";
        }
    }
}
