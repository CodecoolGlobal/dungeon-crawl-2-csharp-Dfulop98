using System.Collections.Generic;
using Assets.Source.Actors.Items;
using Assets.Source.scripts;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public new int Score { get; set; }

        private List<Item> _inventory = new List<Item>();
        public Item _floorItem = null;
        public float Health = 100f;

        protected override void OnUpdate(float deltaTime)
        {
            HealthBar_Script.CurrenctHealth = Health;
            HealthBar_Script.HealthBar.fillAmount = HealthBar_Script.CurrenctHealth / HealthBar_Script.MaxHealth;

            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
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

                Health -= 30f;
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

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";


      


    }
}
