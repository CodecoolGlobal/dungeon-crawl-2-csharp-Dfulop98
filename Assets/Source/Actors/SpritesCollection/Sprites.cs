using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Actors.SpritesCollection
{
    static class Sprites
    {
        // Warrior Player Sprite collection
        public static List<string> Warrior
            = new List<string>()
            {
                "Warrior01",
                "Warrior02",
                "Warrior03",
                "Warrior04",
                "WarriorAttack"
            };

        public static List<string> WarriorWithSpear
            = new List<string>()
            {
                "WarriorSpear01",
                "WarriorSpear02",
                "WarriorSpear03",
                "WarriorSpear04",
                "WarriorSpearAttack"
            };

        public static List<string> WarriorWithSword
            = new List<string>()
            {
                "WarriorSword01",
                "WarriorSword02",
                "WarriorSword03",
                "WarriorSword04",
                "WarriorSwordAttack"
            };

        public static List<string> WarriorArmor
            = new List<string>()
            {
                "WarriorArmor01",
                "WarriorArmor02",
                "WarriorArmor03",
                "WarriorArmor04",
                "WarriorArmorAttack"

            };

        public static List<string> WarriorArmorSword
            = new List<string>()
            {
                "WarriorArmorSword01",
                "WarriorArmorSword02",
                "WarriorArmorSword03",
                "WarriorArmorSword04",
                "WarriorArmorSwordAttack"

            };

        public static List<string> WarriorArmorSpear
            = new List<string>()
            {
                "WarriorArmorSpear01",
                "WarriorArmorSpear02",
                "WarriorArmorSpear03",
                "WarriorArmorSpear04",
                "WarriorArmorSpearAttack"

            };
        
        // Wizard Sprites
        public static List<string> Wizard
            = new List<string>()
            {
                "Wizard01",
                "Wizard02",
                "Wizard03",
                "Wizard04",
                "WizardAttack"
            };
        
        public static List<string> WizardBlanket
            = new List<string>()
            {
                "WizardBlanket01",
                "WizardBlanket02",
                "WizardBlanket03",
                "WizardBlanket04",
                "WizardBlanketAttack"
            };

        public static List<string> WizardWithWand
            = new List<string>()
            {
                "WizardWand01",
                "WizardWand02",
                "WizardWand03",
                "WizardWand04",
                "WizardWandAttack"
            };

        public static List<string> WizardWithStick
            = new List<string>()
            {
                "WizardStick01",
                "WizardStick02",
                "WizardStick03",
                "WizardStick04",
                "WizardStickAttack"
            };

        public static List<string> WizardWandBlanket
            = new List<string>()
            {
                "WizardWandBlacket01",
                "WizardWandBlacket02",
                "WizardWandBlacket03",
                "WizardWandBlacket04",
                "WizardWandBlacketAttack"
            };

        public static List<string> WizardStickBlanket
            = new List<string>()
            {
                "WizardStickBlacket01",
                "WizardStickBlacket02",
                "WizardStickBlacket03",
                "WizardStickBlacket04",
                "WizardStickBlacketAttack"
            };
        
        // Enemy Sprites
        public static List<string> Mushroom
            = new List<string>()
            {
                "mushroom01",
                "mushroom02",
                "mushroom03",
                "mushroom04",
                "mushroom05",
                "mushroom06",
                "mushroom07",
                "mushroom08"
            };

        public static List<string> Slime
            = new List<string>()
            {
                "Slime01",
                "Slime02",
                "Slime03",
                "Slime04",
            };

        public static List<string> Minotaur
            = new List<string>()
            {
                "minotaur01",
                "minotaur02",
                "minotaur03",
                "minotaur04",
            };

        // Item Sprites
        public static Dictionary<string, string> Item
            = new Dictionary<string, string>()
            {
                {"HealthPotion", "HealtPotion"},
                {"Sword","Sword" },
                {"Halandzsa","Spear"},
                {"Key","kenney_transparent_559" },
                {"Armor", "Armor" },
                {"Pálca", "WoodenStick" },
                {"Brutál Pálca", "MagicWand" },
                {"Köppeny", "blanket"}
            };
    }
}
