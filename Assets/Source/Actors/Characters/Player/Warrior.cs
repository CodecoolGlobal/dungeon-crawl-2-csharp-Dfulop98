using Assets.Source.Actors.SpritesCollection;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public class Warrior : Player
    {
        // Stats
        public override string DefaultName => ClassName;
        public static string ClassName = "Warrior";
        public override string Name { get; set; } = "Röszkei Rambó";

        // Sprite Handle
        public override List<string> UsedSpriteCollection { get; set; } = Sprites.Warrior;
        public override string DefaultSpriteId => UsedSpriteCollection[SpriteIndex];

        
    }
}
