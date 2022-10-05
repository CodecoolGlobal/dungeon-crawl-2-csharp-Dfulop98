using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using DungeonCrawl;
using UnityEngine;
using Random = System.Random;
using EventLog = Assets.Source.Core.EventLog;
using System.Collections.Generic;
using Assets.Source.Actors.SpritesCollection;
using UnityEditor;

namespace Assets.Source.Actors.Characters.Enemy
{
    public abstract class Enemy : Character, IDamageableEnemy
    {
        // Enemy Stats
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public virtual int ScoreValue { get; set; }
        public abstract override string DefaultName { get; }

        

        // Sprite Handle
        
        protected abstract List<string> UsedSpriteCollection { get; set; }
        public override string DefaultSpriteId => UsedSpriteCollection[SpriteIndex];
        protected override int SpriteIndex { get; set; }
        protected abstract int MaxIndex { get; set; }
        protected override float IdleTime { get; set; }
        protected abstract float MaxIdleTime { get; set; }

        
        
        // Random instance
        private static Random _seedRandom = new Random();
        private Random _rnd = new Random(_seedRandom.Next());


        private int _detectionRange = 5;

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

            UpdateSprite(Time.deltaTime);
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

        private void UpdateSprite(float deltaTime)
        {

            IdleTime += deltaTime;
            if (IdleTime >= MaxIdleTime)
            {

                if (SpriteIndex == MaxIndex)
                    SpriteIndex = 0;
                else { SpriteIndex++; }

                var newSprite = UsedSpriteCollection[SpriteIndex];
                SetSprite(newSprite);

                IdleTime = 0;
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
