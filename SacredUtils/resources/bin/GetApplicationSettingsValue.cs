﻿using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationSettingsValue
    {
        public static void Get()
        {
            if (!File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);
            }
        }
    }
}
