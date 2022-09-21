using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Actors.Characters.Enemy
{
    public class Ghost : Enemy
    {
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 20;
        public override int ScoreValue { get; set; } = 10;
        
        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Ghost";

        protected override void OnDeathFeedBack()
        {
            Debug.Log("I am going to haunt you in your dreams!...");
        }
    }
}
