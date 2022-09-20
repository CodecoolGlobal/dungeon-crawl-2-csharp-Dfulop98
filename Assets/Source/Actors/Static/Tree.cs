using Assets.Source.Actors.Static;

namespace DungeonCrawl.Actors.Static
{
    public class Tree : Actor
    {
        private int random = StaticUtil.RandomSprite(51, 49, 48, 52);
        public override string DefaultSpriteId => $"kenney_transparent_{random}";
        public override string DefaultName => "Tree";
    }
}
