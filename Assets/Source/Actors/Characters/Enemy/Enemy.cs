using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl;

namespace Assets.Source.Actors.Characters.Enemy
{
    public abstract class Enemy : Character, IDamageableEnemy
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public virtual int ScoreValue { get; set; }  

        public abstract override int DefaultSpriteId { get; }

        public abstract override  string DefaultName { get; }

        public void ApplyDamage(Player player)
        {
            Health -= player.Damage;

            if (Health <= 0)
            {
                // Die
                OnDeath(player);
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                ApplyDamage(player);
                if (Health > 0)
                {
                    player.ApplyDamage(this);
                }
            }
            return true;
        }

        public override void  TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                Position = targetPosition;
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    // Don't allow to move on other actors
                }
            }
        }
        public void OnDeath(Player player)
        {
            OnDeathFeedBack();
            player.Score += ScoreValue;
            ActorManager.Singleton.DestroyActor(this);
        }

        protected abstract override void OnDeathFeedBack();
    }
}
