using System.Collections.Generic;
using System.Threading;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Characters.Enemy;
using Assets.Source.Actors.Items;
using Assets.Source.Core;
using Assets.Source.scripts;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Source.Actors.SpritesCollection;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character, IDamageablePlayer
    {
        private int _spriteIndex { get; set; } = 0;

        public List<string> UsedSpriteCollection { get; set; }

        //Possible need remove
        public override string DefaultSpriteId => Sprites.Warrior[_spriteIndex];

        public override string DefaultName => "Player";
        public int Score { get; set; } = 0;
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 100;

        public List<Item> Inventory = new List<Item>();


        public Item FloorItem = null;

        public string Name = "Röszkei Rambó";

        public static Player Singleton { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            UsedSpriteCollection = Sprites.Warrior;
            SetSprite(UsedSpriteCollection[_spriteIndex]);
            Singleton = this;
        }

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrentHealth = (float)Health;

            UpdateSprite(Time.deltaTime);
            HandleInput();
            ShowHud();
        }
        private void UpdateSprite(float deltaTime)
        {
            ElapsedTime += deltaTime;
            if (ElapsedTime >= 0.15)
            {
                
                if (_spriteIndex == 3)
                    _spriteIndex = 0;
                else{_spriteIndex++;}

                var newSprite = UsedSpriteCollection[_spriteIndex];
                SetSprite(newSprite);
            
                Debug.Log(_spriteIndex);
                ElapsedTime = 0;
            }
            
        }

        private void ShowHud()
        {
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrentHealth / HealthBar_Script.MaxHealth;

            UserInterface.Singleton.SetText($"Damage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            UserInterface.Singleton.SetText($"Health: {Health}\n", UserInterface.TextPosition.TopLeft, "red");

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

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.E) && FloorItem != null)
            {
                FloorItem.Pickup(this);
                FloorItem = null;
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
                foreach (Item element in Inventory)
                {
                    if (element is Key key)
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
                Inventory.ForEach(item => output += $"{item.DefaultName}\n");
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
            Health -= enemy.Damage;
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
