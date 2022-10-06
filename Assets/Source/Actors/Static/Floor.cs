namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Actor
    {
        // in txt : "."
        public override char MapIcon => '.';
        public override string DefaultSpriteId => "Gress 4";
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

    public class DirtFloor1 : Actor
    {
        // in txt "s" full
        public override char MapIcon => 's';
        public override string DefaultSpriteId => "Soil 4";
        public override string DefaultName => "DirtFloor1";
        public override bool Detectable => false;
    }
    public class DirtFloor2 : Actor
    {
        //int txt "u" up faded
        public override char MapIcon => 'u';
        public override string DefaultSpriteId => "Soil 1";
        public override string DefaultName => "DirtFloor2";
        public override bool Detectable => false;
    }
    public class DirtFloor3 : Actor
    {
        //int txt "o" down faded
        public override char MapIcon => 'o';
        public override string DefaultSpriteId => "Soil 7";
        public override string DefaultName => "DirtFloor3";
        public override bool Detectable => false;
    }
    public class DirtFloor4 : Actor
    {
        //int txt "i" right faded
        public override char MapIcon => 'i';
        public override string DefaultSpriteId => "Soil 5";
        public override string DefaultName => "DirtFloor4";
        public override bool Detectable => false;
    }
    public class DirtFloor5 : Actor
    {
        //int txt "l" left faded
        public override char MapIcon => 'l';
        public override string DefaultSpriteId => "Soil 3";
        public override string DefaultName => "DirtFloor5";
        public override bool Detectable => false;
    }
    public class DirtFloor6 : Actor
    {
        //int txt "k" left up faded
        public override char MapIcon => 'k';
        public override string DefaultSpriteId => "Soil 0";
        public override string DefaultName => "DirtFloor6";
        public override bool Detectable => false;
    }
    public class DirtFloor7 : Actor
    {
        //int txt "j" right up faded
        public override char MapIcon => 'j';
        public override string DefaultSpriteId => "Soil 2";
        public override string DefaultName => "DirtFloor7";
        public override bool Detectable => false;
    }
    public class DirtFloor8 : Actor
    {
        //int txt "m right down faded
        public override char MapIcon => 'm';
        public override string DefaultSpriteId => "Soil 8";
        public override string DefaultName => "DirtFloor8";
        public override bool Detectable => false;
    }
    public class DirtFloor9 : Actor
    {
        //int txt "n" left down faded
        public override char MapIcon => 'n';
        public override string DefaultSpriteId => "Soil 6";
        public override string DefaultName => "DirtFloor9";
        public override bool Detectable => false;
    }
}
