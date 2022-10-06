using Assets.Source.Actors.Items;
using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters;

public class PlayerUtilities
{
    public static void ChooseSpriteCollection()
    {
        if (Player.Singleton.DefaultName == Warrior.ClassName && Player.Singleton.Armor > 0)
        {
            if (Player.Singleton.CurrentWeapon == "Fist")
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WarriorArmor);
            }
            else if (Player.Singleton.CurrentWeapon == Sword.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WarriorArmorSword);
            }
            else if (Player.Singleton.CurrentWeapon == Spear.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WarriorArmorSpear);
            }
        }
        else if (Player.Singleton.DefaultName == Warrior.ClassName && Player.Singleton.Armor <= 0)
        {
            if (Player.Singleton.CurrentWeapon == "Fist")
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.Warrior);
            }
            else if (Player.Singleton.CurrentWeapon == Sword.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WarriorWithSword);
            }
            else if (Player.Singleton.CurrentWeapon == Spear.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WarriorWithSpear);
            }
        }
        else if (Player.Singleton.DefaultName == Wizard.ClassName && Player.Singleton.Armor > 0)
        {
            if (Player.Singleton.CurrentWeapon == "Fist")
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WizardBlanket);
            }
            else if (Player.Singleton.CurrentWeapon == Stick.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WizardStickBlanket);
            }
            else if (Player.Singleton.CurrentWeapon == Wand.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WizardWandBlanket);
            }
        }
        else if (Player.Singleton.DefaultName == Wizard.ClassName && Player.Singleton.Armor <= 0)
        {
            if (Player.Singleton.CurrentWeapon == "Fist")
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.Wizard);
            }
            else if (Player.Singleton.CurrentWeapon == Stick.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WizardWithStick);
            }
            else if (Player.Singleton.CurrentWeapon == Wand.ClassName)
            {
                Player.Singleton.UsedSpriteCollection = new List<string>(Sprites.WizardWithWand);
            }
        }
    }
}