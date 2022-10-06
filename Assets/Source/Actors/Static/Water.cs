namespace DungeonCrawl.Actors.Static
{
    public class Water1 : Actor
    {
        // in txt : "b" filled
        public override char MapIcon => 'b';
        public override string DefaultSpriteId => "Water 4";
        public override string DefaultName => "Water1";
        public override bool Detectable => true;
    }
    public class Water2 : Actor
    {
        // in txt : "v" right up
        public override char MapIcon => 'v';
        public override string DefaultSpriteId => "Water 2";
        public override string DefaultName => "Water2";
        public override bool Detectable => true;
    }
    public class Water3 : Actor
    {
        // in txt : "c" right down
        public override char MapIcon => 'c';
        public override string DefaultSpriteId => "Water 8";
        public override string DefaultName => "Water3";
        public override bool Detectable => true;
    }
    public class Water4 : Actor
    {
        // in txt : "x" left down
        public override char MapIcon => 'x';
        public override string DefaultSpriteId => "Water 6";
        public override string DefaultName => "Water4";
        public override bool Detectable => true;
    }
    public class Water5 : Actor
    {
        // in txt : "y" left up
        public override char MapIcon => 'y';
        public override string DefaultSpriteId => "Water 0";
        public override string DefaultName => "Water5";
        public override bool Detectable => true;
    }
    public class Water6 : Actor
    {
        // in txt : "z" right
        public override char MapIcon => 'z';
        public override string DefaultSpriteId => "Water 5";
        public override string DefaultName => "Water6";
        public override bool Detectable => true;
    }
    public class Water7 : Actor
    {
        // in txt : "t" down
        public override char MapIcon => 't';
        public override string DefaultSpriteId => "Water 7";
        public override string DefaultName => "Water7";
        public override bool Detectable => true;
    }
    public class Water8 : Actor
    {
        // in txt : "h" left
        public override char MapIcon => 'h';
        public override string DefaultSpriteId => "Water 3";
        public override string DefaultName => "Water8";
        public override bool Detectable => true;
    }
    public class Water9 : Actor
    {
        // in txt : "g" up
        public override char MapIcon => 'g';
        public override string DefaultSpriteId => "Water 1";
        public override string DefaultName => "Water9";
        public override bool Detectable => true;
    }
}
