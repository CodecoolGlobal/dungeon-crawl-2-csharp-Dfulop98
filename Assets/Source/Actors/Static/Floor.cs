using System;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        private Random Random = new Random();
        
        //private int RandomSprite()
        //{
        //    int number = Random.Next(0, 100);
        //    if (number > 0 && number < 10)
        //    {
        //        return 4;
        //    }
        //    else if(number >= 10 && number < 20)
        //    {
        //        return 5;
        //    }
        //    else if(number >= 30 && number < 40)
        //    {
        //        return 6;
        //    }
        //    else if(number >= 50 && number < 60)
        //    {
        //        return 300;
        //    }
        //    else if (number >= 60 && number < 70)
        //    {
        //        return 301;
        //    }
        //    else if (number >= 70 && number < 80)
        //    {
        //        return 303;
        //    }

        //    return 304;
        //}

        public override int DefaultMapSpriteId => 4;
        public override string DefaultName => "Floor";

        public override bool Detectable => false;
    }
}
