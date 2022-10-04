using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Actors.SpritesCollection
{
    static class Sprites
    {
        public static List<string> PlayerIdleSprites
            = new List<string>()
            {
                "PlayerIdle1",
                "PlayerIdle2",
                "PlayerIdle3",
                "PlayerIdle4",
            };
        
        public static List<string> PlayerWSPearSprites
            = new List<string>()
            {
                "PlayerWSpear1",
                "PlayerWSpear2",
                "PlayerWSpear3",
                "PlayerWSpear4",

            };

        public static List<string> PlayerWizardSprites
            = new List<string>()
            {
                "PlayerWizard1",
                "PlayerWizard2",
                "PlayerWizard3",
                "PlayerWizard4",

            };

        public static Dictionary<string, string> ItemSprites
            = new Dictionary<string, string>()
            {
                {"HealthPotion", "kenney_transparent_896"},
                {"Sword","PackCastle01_43" },
                {"Spear","PackCastle01_9"},
                {"Key","kenney_transparent_559" }
            };


    }
}
