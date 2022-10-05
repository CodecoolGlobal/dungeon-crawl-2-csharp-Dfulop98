using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using DungeonCrawl;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;
using EventLog = Assets.Source.Core.EventLog;

namespace Assets.Source.Actors.Characters.Enemy
{
    public abstract class Enemy : Character, IDamageableEnemy
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public virtual int ScoreValue { get; set; }

        public abstract override string DefaultSpriteId { get; }

        public abstract override string DefaultName { get; }

        private static readonly Random SeedRandom = new Random();

        private readonly Random _rnd = new Random(SeedRandom.Next());

        private readonly int _detectionRange = 5;

        public void ApplyDamage(Player player)
        {
            Health -= player.Damage;
            EventLog.AddEvent($"{player.Name} hits {this.DefaultName} for {player.Damage}");
            if (Health <= 0)
            {
                // Die
                OnDeath(player);
                EventLog.AddEvent($"{this.DefaultName} Dies");
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
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
            }
            else if (actorAtTargetPosition is Player player)
            {
                player.OnCollision(this);
            }
        }
        public void OnDeath(Player player)
        {
            player.Score += ScoreValue;
            ActorManager.Singleton.DestroyActor(this);
        }

        protected override void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        protected override void OnUpdate(float deltaTime)
        {
            ElapsedTime += deltaTime;
            if (ElapsedTime >= 1)
            {
                var dir = CalculateDirection();

                TryMove(dir);
                ElapsedTime = 0;
            }
        }

        protected bool DetectPlayer()
        {
            if ((Position.x - _detectionRange < Player.Singleton.Position.x && Player.Singleton.Position.x < Position.x + _detectionRange) &&
                (Position.y - _detectionRange < Player.Singleton.Position.y && Player.Singleton.Position.y < Position.y + _detectionRange))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Direction CalculateDirection()
        {
            if (DetectPlayer())
            {
                int xDifference = Position.x - Player.Singleton.Position.x;
                int yDifference = Position.y - Player.Singleton.Position.y;

                if (xDifference < 0)
                {
                    return Direction.Right;
                }
                if (xDifference > 0)
                {
                    return Direction.Left;
                }
                if (yDifference < 0)
                {
                    return Direction.Up;
                }
                if (yDifference > 0)
                {
                    return Direction.Down;
                }
                else
                {
                    return (Direction)_rnd.Next(Enum.GetNames(typeof(Direction)).Length);
                }
            }
            else
            {
                return (Direction)_rnd.Next(Enum.GetNames(typeof(Direction)).Length);
            }
        }
    }
}
