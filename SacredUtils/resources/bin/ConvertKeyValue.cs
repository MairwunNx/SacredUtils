namespace SacredUtils.resources.bin
{
    public static class ConvertKeyValue
    {
        public static string Convert(string value)
        {
            string returnValue = "";

            switch (value)
            {
                case "Undead Death Potion": returnValue = "Q"; break;
                case "Mentor Potion": returnValue = "W"; break;
                case "Viper’s Antidote Potion": returnValue = "E"; break;
                case "Concentration Potion": returnValue = "R"; break;
                case "Open Inventory": returnValue = "I"; break;
                case "Open Options": returnValue = "O"; break;
                case "Game Pause": returnValue = "P"; break;
                case "Pickup Items": returnValue = "A"; break;
                case "Open Save Menu": returnValue = "S"; break;
                case "Open Skills Menu": returnValue = "F"; break;
                case "Open Help Menu": returnValue = "H"; break;
                case "Open Journal": returnValue = "L"; break;
                case "Party Information": returnValue = "N"; break;
                case "Open World Map": returnValue = "M"; break;
            }

            return returnValue;
        }
    }
}
