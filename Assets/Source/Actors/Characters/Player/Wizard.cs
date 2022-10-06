using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public class Wizard : Player
    {
        // Stats
        public override string DefaultName => ClassName;
        public static string ClassName = "Wizard";
        public override string Name { get; set; } = "Röszkei Gandalf";

        // Sprite Handle
        public override List<string> UsedSpriteCollection { get; set; } = Sprites.Wizard;
        public override string DefaultSpriteId => UsedSpriteCollection[SpriteIndex];
    }
}
