using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors;
using Assets.Source.Actors.Items;
using Assets.Source.Core;
using Assets.Source.scripts;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Source.Actors.SpritesCollection;


namespace DungeonCrawl.Actors.Characters
{
    public abstract class Player : Character, IDamageablePlayer
    {
        public override char MapIcon => 'p';

        // Stats
        public override string DefaultName { get; }
        public abstract string Name { get; set; }
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 100;
        public int Armor { get; set; } = 0;
        public int Score { get; set; } = 0;

        // Sprite Handle
        public abstract List<string> UsedSpriteCollection { get; set; }
        public override string DefaultSpriteId { get; }
        protected override int SpriteIndex { get; set; } = 0;
        protected override float IdleTime { get; set; } = 0;

        protected int MaxSpriteIndex = 3;

        public bool IsAttack = false;

        // init
        public Item FloorItem = null;
        public string CurrentWeapon = "Fist";
        public List<string> Inventory = new List<string>();
        public List<Crosshair> Crosshairs = new List<Crosshair>();

        public static Player Singleton { get; private set; }

        // Consts
        private const float MovementTimeThreshold = 0.35f;
        private const float SpriteUpdateTimeThreshold = 0.15f;
        private const int BasicWeaponDamage = 5;
        private const int MiddleWeaponDamage = 15;
        private const int LongWeaponDamage = 10;

        public Direction Facing = Direction.Right;

        private Dictionary<Direction, float> _movementCounters = new Dictionary<Direction, float>()
        {
            { Direction.Up, 0 },
            { Direction.Down, 0 },
            { Direction.Left, 0 },
            { Direction.Right, 0 }
        };
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetSprite(UsedSpriteCollection[SpriteIndex]);
            Singleton = this;
            SwitchWeapon(1);
        }

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrentHealth = (float)Health;
            ArmorBar_Script.CurrentArmor = (float)Armor;

            UpdateSprite(Time.deltaTime);
            PlayerUtilities.HandleInput();
            PlayerUtilities.HandleContinousKeyPress(deltaTime);
            ShowHud();
            UpdateCrosshairs();
        }

        public void SwitchWeapon(int choice)
        {
            Crosshairs.ForEach(crosshair => ActorManager.Singleton.DestroyActor(crosshair));
            Crosshairs.Clear();
            switch (choice)
            {
                case 1:
                    CurrentWeapon = "Fist";
                    Damage = BasicWeaponDamage;
                    CreateCrosshair(1);
                    break;
                case 2:
                    if (Inventory.Contains(Sword.ClassName))
                    {
                        CurrentWeapon = Sword.ClassName;
                        Damage = MiddleWeaponDamage;
                        CreateCrosshair(1);
                    }
                    else if (Inventory.Contains(Stick.ClassName))
                    {
                        CurrentWeapon = Stick.ClassName;
                        Damage = MiddleWeaponDamage;
                        CreateCrosshair(1);
                    }
                    else
                    {
                        SwitchWeapon(1);
                    }
                    break;
                case 3:
                    if (Inventory.Contains(Spear.ClassName))
                    {
                        CurrentWeapon = Spear.ClassName;
                        Damage = LongWeaponDamage;
                        CreateCrosshair(1);
                        CreateCrosshair(2);
                    }
                    else if (Inventory.Contains(Wand.ClassName))
                    {
                        CurrentWeapon = Wand.ClassName;
                        Damage = LongWeaponDamage;
                        CreateCrosshair(1);
                        CreateCrosshair(2);
                    }
                    else
                    {
                        SwitchWeapon(1);
                    }
                    break;
            }
            PlayerUtilities.ChooseSpriteCollection();
        }

        public void CreateCrosshair(int offset)
        {
            Crosshair crosshair = ActorManager.Singleton.Spawn<Crosshair>(this.Position.x, this.Position.y);
            crosshair.Offset = offset;
            Crosshairs.Add(crosshair);
        }

        private void UpdateCrosshairs()
        {
            foreach (Crosshair crosshair in Crosshairs)
            {
                crosshair.Move(this);
            }
        }

        private void UpdateSprite(float deltaTime)
        {
            ElapsedTime += deltaTime;
            if (ElapsedTime >= SpriteUpdateTimeThreshold)
            {
                if (SpriteIndex == MaxSpriteIndex)
                    SpriteIndex = 0;
                else{SpriteIndex++;}

                if (IsAttack)
                {
                    SetSprite(UsedSpriteCollection[MaxSpriteIndex+1]);
                    IsAttack = false;
                }
                else SetSprite(UsedSpriteCollection[SpriteIndex]);
            
                ElapsedTime = 0;
            }
        }

        private void ShowHud()
        {
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrentHealth / HealthBar_Script.MaxHealth;
            ArmorBar_Script.ArmorBar.fillAmount = ArmorBar_Script.CurrentArmor/ ArmorBar_Script.MaxArmor;

            UserInterface.Singleton.SetText($"Damage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            UserInterface.Singleton.SetText($"Health: {Health}\nArmor: {Armor}\nCurrent Weapon: {CurrentWeapon}", UserInterface.TextPosition.TopLeft, "red");

            UserInterface.Singleton.SetText($"{CreateInventoryString()}", UserInterface.TextPosition.BottomRight, "red");
            if (FloorItem != null)
            {
                UserInterface.Singleton.SetText($"Press 'E' to pick up {FloorItem.DefaultName}", UserInterface.TextPosition.BottomCenter, "white");
            }
            else
            {
                UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomCenter, "white");
            }
        }

        public void ContinualMovement(Direction direction, float deltatime)
        {
            switch (direction)
            {
                case Direction.Up:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Down:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Left:
                    _movementCounters[direction] += deltatime;
                    break;
                case Direction.Right:
                    _movementCounters[direction] += deltatime;
                    break;
            }

            var directionsToZero = _movementCounters.Where(element => element.Key != direction).Select(element => element.Key).ToList();

            // Reset all other direction counters to 0
            foreach (var dir in directionsToZero)
            {
                _movementCounters[dir] = 0;
            }

            if (_movementCounters[direction] >= MovementTimeThreshold)
            {
                TryMove(direction);
                _movementCounters[direction] = 0;
            }
        }

        public void AttackEnemiesUnderCrosshairs()
        {
            foreach (var crosshair in Crosshairs)
            {
                if (ActorManager.Singleton.GetActorAt(crosshair.Position) is Enemy enemy)
                {
                    enemy.ApplyDamage(this);
                }
            }
        }

        public override void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);
            
            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                Position = targetPosition;
                CameraController.Singleton.Position = targetPosition;
                FloorItem = null;
            }
            else if (actorAtTargetPosition is Item item)
            {
                Position = targetPosition;
                CameraController.Singleton.Position = targetPosition;
                FloorItem = item;
            }
            else if (actorAtTargetPosition is Enemy enemy)
            {
                enemy.OnCollision(this);
            }
            else if (actorAtTargetPosition is Door door)
            {
                foreach (var inventoryItem in Inventory)
                {
                    if (inventoryItem == "Key")
                    {
                        door.DoorOpen();
                    }
                }
            }
        }

        private string CreateInventoryString()
        {
            if (Inventory.Count == 0)
            {
                return "Inventory: \nNone";
            }
            else
            {
                string output = "Inventory: \n";
                Inventory.ForEach(item => output += $"{item}\n");
                return output;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Item item)
            {
                FloorItem = item;
            }
            else if (anotherActor is Enemy enemy)
            {
                ApplyDamage(enemy);
            }
            else
            {
                FloorItem = null;
            }
            return false;
        }

        public void OnDeath()
        {
            ActorManager.Singleton.DestroyActor(this);
            SceneManager.LoadScene("DeathScene");
        }

        public void ApplyDamage(Enemy enemy)
        {
            if(Armor > 0)
            {
                Armor -= enemy.Damage;   
                if(Armor - enemy.Damage <= 0)
                {
                    PlayerUtilities.ChooseSpriteCollection();
                }
            }
            else
            {
                Health -= enemy.Damage;
            }
            EventLog.AddEvent($"{enemy.DefaultName} hits {Name} for {enemy.Damage}");
            if (Health <= 0)
            {
                // Die
                OnDeath();
                UserInterface.Singleton.SetText($"Health: {Health}\nDamage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            }
        }
    }
}
