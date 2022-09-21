using System.Collections.Generic;
using Assets.Source.Actors.Characters;
using Assets.Source.Actors.Characters.Enemy;
using Assets.Source.Actors.Items;
using Assets.Source.Core;
using Assets.Source.scripts;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character, IDamageablePlayer
    {
        public int Score { get; set; } = 0;
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 100;

        public List<Item> _inventory = new List<Item>();
        public Item _floorItem = null;

        public string Name = "Hegyiember";

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrentHealth = (float)Health;
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrentHealth / HealthBar_Script.MaxHealth;

            UserInterface.Singleton.SetText($"Health: {Health}\nDamage: {Damage}\nScore: {Score}", UserInterface.TextPosition.TopRight, "magenta");

            UserInterface.Singleton.SetText($"{CreateInventoryString()}", UserInterface.TextPosition.BottomRight, "red");


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

            //test HealthBar
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Health -= Damage;
            }
        }

        public new void TryMove(Direction direction)
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
            else
            {
                if (actorAtTargetPosition is Item item)
                {
                    Position = targetPosition;
                    CameraController.Singleton.Position = targetPosition;

                    _floorItem = item;
                }
                else if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    // Position = targetPosition;
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
                _inventory.ForEach(item => output += item.DefaultName);
                return output;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Item item)
            {
                _floorItem = item;
            }
            else
            {
                _floorItem = null;
            }
            return false;
        }

        public void OnDeath()
        {
            OnDeathFeedBack();
            ActorManager.Singleton.DestroyActor(this);
        }


        protected override void OnDeathFeedBack()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public void ApplyDamage(Enemy enemy)
        {
            Health -= enemy.Damage;
            EventLog.AddEvent($"{enemy.DefaultName} hits {Name} for {enemy.Damage}");
            if (Health <= 0)
            {
                // Die
                OnDeath();
            }
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

    }
}
