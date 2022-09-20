using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character
    {
        public override int Damage { get; set; } = 50;
        public override int Health { get; set; } = 20;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player player)
            {
                ApplyDamage(player.Damage);
                if (Health > 0)
                {
                    player.ApplyDamage(this.Damage);
                }
            }
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("I am going to haunt you in your dreams!...");
            ActorManager.Singleton.DestroyActor(this);
        }

        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Ghost";
    }
}
