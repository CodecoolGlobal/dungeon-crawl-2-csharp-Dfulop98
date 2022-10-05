using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;


namespace DungeonCrawl.Actors.Characters
{
    public class Minotaur : Enemy
    {
        // Stats
        public override int Damage { get; set; } = 5;
        public override int Health { get; set; } = 10;
        public override int ScoreValue { get; set; } = 10;
        public override string DefaultName => "KrampuszJános";

        // Sprite Handle
        
        protected override List<string> UsedSpriteCollection { get; set; } = Sprites.Minotaur;
        public override string DefaultSpriteId => UsedSpriteCollection[SpriteIndex];
        protected override int SpriteIndex { get; set; } = 0;
        protected override int MaxIndex { get; set; } = 4;
        protected override float IdleTime { get; set; } = 0;
        protected override float MaxIdleTime { get; set; } = 0.45f;

    }
}
