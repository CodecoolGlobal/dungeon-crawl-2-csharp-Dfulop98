using Assets.Source.Actors.Static;
using System;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        public override string DefaultSpriteId => "Gress 4";
        public override string DefaultName => "Floor";
        public override bool Detectable => false;
    }
}
