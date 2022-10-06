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

        private bool IsAttack = false;

        // init
        public Item FloorItem = null;
        private string _currentWeapon = "Fist";
        public List<string> Inventory = new List<string>();
        public List<Crosshair> Crosshairs = new List<Crosshair>();

        public static Player Singleton { get; private set; }


        private float _movementTimeThreshold = 0.35f;

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
            HandleInput(deltaTime);
            HandleContinousKeyPress(deltaTime);
            ShowHud();
            UpdateCrosshairs();
        }

        private void SwitchWeapon(int choice)
        {
            Crosshairs.ForEach(crosshair => ActorManager.Singleton.DestroyActor(crosshair));
            Crosshairs.Clear();
            switch (choice)
            {
                case 1:
                    _currentWeapon = "Fist";
                    Damage = 5;
                    CreateCrosshair(1);
                    break;
                case 2:
                    if (Inventory.Contains(Sword.ClassName))
                    {
                        _currentWeapon = Sword.ClassName;
                        Damage = 15;
                        CreateCrosshair(1);
                    }
                    else if (Inventory.Contains(Stick.ClassName))
                    {
                        _currentWeapon = Stick.ClassName;
                        Damage = 15;
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
                        _currentWeapon = Spear.ClassName;
                        Damage = 10;
                        CreateCrosshair(1);
                        CreateCrosshair(2);
                    }
                    else if (Inventory.Contains(Wand.ClassName))
                    {
                        _currentWeapon = Wand.ClassName;
                        Damage = 10;
                        CreateCrosshair(1);
                        CreateCrosshair(2);
                    }
                    else
                    {
                        SwitchWeapon(1);
                    }
                    break;
            }
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

        private void ChooseSpriteCollection()
        {
            if (DefaultName == Warrior.ClassName && Armor > 0)
            {
                if (_currentWeapon == "Fist")
                {
                    UsedSpriteCollection = new List<string>(Sprites.WarriorArmor);
                }
                else if (_currentWeapon == Sword.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WarriorArmorSword);
                }
                else if (_currentWeapon == Spear.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WarriorArmorSpear);
                }
            }
            else if (DefaultName == Warrior.ClassName && Armor <= 0)
            {
                if (_currentWeapon == "Fist")
                {
                    UsedSpriteCollection = new List<string>(Sprites.Warrior);
                }
                else if (_currentWeapon == Sword.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WarriorWithSword);
                }
                else if (_currentWeapon == Spear.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WarriorWithSpear);
                }
            }
            else if (DefaultName == Wizard.ClassName && Armor > 0)
            {
                if (_currentWeapon == "Fist")
                {
                    UsedSpriteCollection = new List<string>(Sprites.WizardBlanket);
                }
                else if (_currentWeapon == Stick.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WizardStickBlanket);
                }
                else if (_currentWeapon == Wand.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WizardWandBlanket);
                }
            }
            else if (DefaultName == Wizard.ClassName && Armor <= 0)
            {
                if (_currentWeapon == "Fist")
                {
                    UsedSpriteCollection = new List<string>(Sprites.Wizard);
                }
                else if (_currentWeapon == Stick.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WizardWithStick);
                }
                else if (_currentWeapon == Wand.ClassName)
                {
                    UsedSpriteCollection = new List<string>(Sprites.WizardWithWand);
                }
            }
        }
        
        private void UpdateSprite(float deltaTime)
        {
            ElapsedTime += deltaTime;
            if (ElapsedTime >= 0.15)
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
            UserInterface.Singleton.SetText($"Health: {Health}\nArmor: {Armor}\nCurrent Weapon: {_currentWeapon}", UserInterface.TextPosition.TopLeft, "red");

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

        private void ContinualMovement(Direction direction, float deltatime)
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

            if (_movementCounters[direction] >= _movementTimeThreshold)
            {
                TryMove(direction);
                _movementCounters[direction] = 0;
            }
        }
        private void HandleInput(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMove(Direction.Up);
                Facing = Direction.Up;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMove(Direction.Down);
                Facing = Direction.Down;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMove(Direction.Left);
                Facing = Direction.Left;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMove(Direction.Right);
                Facing = Direction.Right;
            }

            if (Input.GetKeyDown(KeyCode.E) && FloorItem != null)
            {
                FloorItem.Pickup(this);
                FloorItem = null;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackEnemiesUnderCrosshairs();
                IsAttack = true;
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
                SwitchWeapon(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchWeapon(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchWeapon(3);
            }
        }

        private void HandleContinousKeyPress(float deltaTime)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                ContinualMovement(Direction.Up, deltaTime);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ContinualMovement(Direction.Down, deltaTime);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                ContinualMovement(Direction.Left, deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                ContinualMovement(Direction.Right, deltaTime);
            }
        }

        private void AttackEnemiesUnderCrosshairs()
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
            //this.SetSprite(Sprites.PlayerSprites["move1"]);

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

                    HandleArmorSprite();
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
        private void HandleArmorSprite()
        {
            if (DefaultName == "Wizard")
            {
                if (UsedSpriteCollection == Sprites.WizardBlanket)
                    UsedSpriteCollection = Sprites.Wizard;
                else if (UsedSpriteCollection == Sprites.WizardStickBlanket)
                    UsedSpriteCollection = Sprites.WizardWithStick;
                else if (UsedSpriteCollection == Sprites.WizardWandBlanket)
                    UsedSpriteCollection = Sprites.WizardWithWand;
            }

            if (DefaultName == "Warrior")
            {
                if (UsedSpriteCollection == Sprites.WarriorArmor)
                    UsedSpriteCollection = Sprites.Warrior;
                else if (UsedSpriteCollection == Sprites.WarriorArmorSword)
                    UsedSpriteCollection = Sprites.WarriorWithSword;
                else if (UsedSpriteCollection == Sprites.WarriorArmorSpear)
                    UsedSpriteCollection = Sprites.WarriorWithSpear;
            }
        }
    }
}
