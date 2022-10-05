using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DungeonCrawl.Actors.Characters
{
    public class Mushroom : Enemy
    {
        // Stats
        public override int Damage { get; set; } = 10;
        public override int Health { get; set; } = 20;
        public override int ScoreValue { get; set; } = 10;
        public override string DefaultName => "Angry Mushroom";

        // Sprite Handle
        
        protected override List<string> UsedSpriteCollection { get; set; } = Sprites.Mushroom;
        protected override int SpriteIndex { get; set; } = 0;
        protected override int MaxIndex { get; set; } = 7;
        protected override float IdleTime { get; set; } = 0;
        protected override float MaxIdleTime { get; set; } = 0.15f;



    }
    
}
