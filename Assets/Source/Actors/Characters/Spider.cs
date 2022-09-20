using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
    {
        public override int Damage { get; set; } = 2;
        public override int Health { get; set; } = 10;
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Spider noises...");
        }

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
    }
}
