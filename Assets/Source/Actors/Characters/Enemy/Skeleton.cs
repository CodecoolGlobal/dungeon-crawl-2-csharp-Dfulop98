using Assets.Source.Actors.Characters.Enemy;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Enemy
    {
        public override int Damage { get; set; } = 2;
        public override int Health { get; set; } = 10;
        

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";

        protected override void OnDeathFeedBack()
        {
            Debug.Log("Well, I was already dead anyway...");
        }
    }
}
