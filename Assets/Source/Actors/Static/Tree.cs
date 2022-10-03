using Assets.Source.Actors.Static;

namespace DungeonCrawl.Actors.Static
{
    public class Tree : Actor
    {
        // in txt : "T"
        private int _rndId = StaticUtil.RandomSprite(51, 49, 48, 52);
         
        public override string DefaultSpriteId => $"kenney_transparent_{_rndId}";
        public override string DefaultName => "Tree";
    }
}
