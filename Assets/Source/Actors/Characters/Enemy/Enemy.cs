using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Characters.Enemy
{
    public abstract class Enemy : Character
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public virtual int ScoreValue { get; set; }  

        public abstract override int DefaultSpriteId { get; }

        public abstract override  string DefaultName { get; }

        public override void ApplyDamage(int damage, Player player)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();
            }
        }

        public override void ApplyDamage(int damage)
        {
            
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                ApplyDamage(player.Damage, player);
                if (Health > 0)
                {
                    player.ApplyDamage(this.Damage);
                }
            }
            return true;
        }
        protected override void OnDeath(Player player)
        {
            OnDeathFeedBack();
            player.Score += ScoreValue;
            ActorManager.Singleton.DestroyActor(this);
        }

        protected override void OnDeath()
        {
        }

        protected abstract override void OnDeathFeedBack();
    }
}
