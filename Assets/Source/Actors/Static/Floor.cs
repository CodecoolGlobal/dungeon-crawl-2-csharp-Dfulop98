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
        public override char MapIcon => '#';
        public override string DefaultSpriteId => "WoodWall";
        public override string DefaultName => "WoodenFloor";

        public override bool Detectable => false;
    }

    public class SandFloor : Actor
    {
        // in txt "s" full
        public override char MapIcon => 's';
        public override string DefaultSpriteId => "SandFloor";
        public override string DefaultName => "SandFloor";
        public override bool Detectable => false;
    }
}
   
