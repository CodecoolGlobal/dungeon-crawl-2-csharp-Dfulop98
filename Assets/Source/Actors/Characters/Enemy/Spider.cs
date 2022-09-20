using Assets.Source.Actors.Characters.Enemy;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Enemy
    {
        public override int Damage { get; set; } = 2;
        public override int Health { get; set; } = 10;
        

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
        protected override void OnDeathFeedBack()
        {
            Debug.Log("Spider noises...");
        }
    }
}
