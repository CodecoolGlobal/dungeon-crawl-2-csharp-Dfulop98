using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public class Slime : Enemy
    {
        public override char MapIcon => 'q';
        // Stats
        public override int Damage { get; set; } = 25;
        public override int Health { get; set; } = 30;
        public override int ScoreValue { get; set; } = 20;
        public override string DefaultName => "KardosJános";

        // Sprite Handle
        
        protected override List<string> UsedSpriteCollection { get; set; } = Sprites.Slime;
        public override string DefaultSpriteId => UsedSpriteCollection[SpriteIndex];
        protected override int SpriteIndex { get; set; } = 0;
        protected override int MaxIndex { get; set; } = 3;
        protected override float IdleTime { get; set; } = 0;
        protected override float MaxIdleTime { get; set; } = 0.15f;
       
    }
}
