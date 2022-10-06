namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Actor
    {
        // in txt : "."
        public override char MapIcon => '.';
        public override string DefaultSpriteId => "GrassFloor";
        public override string DefaultName => "GrassFloor";
        public override bool Detectable => false;
    }

    public class WoodenFloor : Actor
    {
        // in txt "r"
        public override char MapIcon => 'r';
        public override string DefaultSpriteId => "Wall 1";
        public override string DefaultName => "WoodenFloor";
        public override bool Detectable => false;
    }

    public class SandFloor : Actor
    {
        // in txt "s" full
        public override char MapIcon => 's';
        public override string DefaultSpriteId => "SandFloor";
        public override string DefaultName => "DirtFloor1";
        public override bool Detectable => false;
    }
}
   
