using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public override int Damage { get; set; } = 2;
        public override int Health { get; set; } = 10;
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
            
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
        
    }
}
