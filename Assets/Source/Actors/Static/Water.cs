using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonCrawl.Actors.Static
{
    public class Water1 : Actor
    {
        // in txt : "b" filled
        public override string DefaultSpriteId => "Water 4";
        public override string DefaultName => "Water1";
        public override bool Detectable => true;
    }
    public class Water2 : Actor
    {
        // in txt : "v" right up
        public override string DefaultSpriteId => "Water 2";
        public override string DefaultName => "Water2";
        public override bool Detectable => true;
    }
    public class Water3 : Actor
    {
        // in txt : "c" right down
        public override string DefaultSpriteId => "Water 8";
        public override string DefaultName => "Water3";
        public override bool Detectable => true;
    }
    public class Water4 : Actor
    {
        // in txt : "x" left down
        public override string DefaultSpriteId => "Water 6";
        public override string DefaultName => "Water4";
        public override bool Detectable => true;
    }
    public class Water5 : Actor
    {
        // in txt : "y" left up
        public override string DefaultSpriteId => "Water 0";
        public override string DefaultName => "Water5";
        public override bool Detectable => true;
    }
    public class Water6 : Actor
    {
        // in txt : "t" right
        public override string DefaultSpriteId => "Water 5";
        public override string DefaultName => "Water6";
        public override bool Detectable => true;
    }
    public class Water7 : Actor
    {
        // in txt : "t" down
        public override string DefaultSpriteId => "Water 7";
        public override string DefaultName => "Water7";
        public override bool Detectable => true;
    }
    public class Water8 : Actor
    {
        // in txt : "h" left
        public override string DefaultSpriteId => "Water 3";
        public override string DefaultName => "Water8";
        public override bool Detectable => true;
    }
    public class Water9 : Actor
    {
        // in txt : "g" up
        public override string DefaultSpriteId => "Water 1";
        public override string DefaultName => "Water9";
        public override bool Detectable => true;
    }
}
