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

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character, IDamageablePlayer
    {
        public int Score { get; set; } = 0;
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 100;

        public List<Item> _inventory = new List<Item>();

        public Item _floorItem = null;

        public string Name = "Röszkei Rambó";

        public static Player Singleton { get; private set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);
            Singleton = this;
        }

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrentHealth = (float)Health;
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrentHealth / HealthBar_Script.MaxHealth;

            UserInterface.Singleton.SetText($"Damage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");
            UserInterface.Singleton.SetText($"Health: {Health}\n", UserInterface.TextPosition.TopLeft, "red");

            UserInterface.Singleton.SetText($"{CreateInventoryString()}", UserInterface.TextPosition.BottomRight, "red");
            if (_floorItem != null)
            {
                UserInterface.Singleton.SetText($"Press 'E' to pick up {_floorItem.DefaultName}", UserInterface.TextPosition.BottomCenter, "white");
            }
            else
            {
                UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomCenter, "white");
            }


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

            if (Input.GetKeyDown(KeyCode.E) && _floorItem != null)
            {
                _floorItem.Pickup(this);
                _floorItem = null;
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
                _floorItem = null;
            }
            else if (actorAtTargetPosition is Item item)
            {
                Position = targetPosition;
                CameraController.Singleton.Position = targetPosition;
                _floorItem = item;
            }
            else if (actorAtTargetPosition is Enemy enemy)
            {
                enemy.OnCollision(this);
            }
            else if (actorAtTargetPosition is Door door)
            {
                foreach (Item element in _inventory)
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
            if (_inventory.Count == 0)
            {
                return "Inventory: \nNone";
            }
            else
            {
                string output = "Inventory: \n";
                _inventory.ForEach(item => output += $"{item.DefaultName}\n");
                return output;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Item item)
            {
                _floorItem = item;
            }
            else if (anotherActor is Enemy enemy)
            {
                ApplyDamage(enemy);
            }
            
            else
            {
                _floorItem = null;
            }
            return false;
        }

        public void OnDeath()
        {
            EventLog.AddEvent($"You Dieded! Oh Noes!");
            ActorManager.Singleton.DestroyActor(this);
            SceneManager.LoadScene(0);
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

        public override string DefaultSpriteId => "PackCastle01_0";
        public override string DefaultName => "Player";

    }
}
