using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
    {
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
