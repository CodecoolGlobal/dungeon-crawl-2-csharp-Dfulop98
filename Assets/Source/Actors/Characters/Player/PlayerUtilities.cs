using Assets.Source.Actors.Items;
using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters;

public class PlayerUtilities
{
    public static void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Player.Singleton.TryMove(Direction.Up);
            Player.Singleton.Facing = Direction.Up;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Player.Singleton.TryMove(Direction.Down);
            Player.Singleton.Facing = Direction.Down;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player.Singleton.TryMove(Direction.Left);
            Player.Singleton.Facing = Direction.Left;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player.Singleton.TryMove(Direction.Right);
            Player.Singleton.Facing = Direction.Right;
        }

        if (Input.GetKeyDown(KeyCode.E) && Player.Singleton.FloorItem != null)
        {
            Player.Singleton.FloorItem.Pickup(Player.Singleton);
            Player.Singleton.FloorItem = null;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Singleton.AttackEnemiesUnderCrosshairs();
            Player.Singleton.IsAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveObject saveGame = new SaveObject();
            saveGame.MakeSave();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            SaveObject.LoadGame();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.Singleton.SwitchWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.Singleton.SwitchWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.Singleton.SwitchWeapon(3);
        }
    }

    public static void HandleContinousKeyPress(float deltaTime)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Player.Singleton.ContinualMovement(Direction.Up, deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Player.Singleton.ContinualMovement(Direction.Down, deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.Singleton.ContinualMovement(Direction.Left, deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.Singleton.ContinualMovement(Direction.Right, deltaTime);
        }
    }

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