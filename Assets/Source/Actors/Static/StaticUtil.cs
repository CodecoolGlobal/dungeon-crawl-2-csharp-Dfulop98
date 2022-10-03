
using System;

namespace Assets.Source.Actors.Static
{
    public static class StaticUtil
    {
        public static int RandomSprite(params int[] args)
        {
            //random sprite from the given pack
            Random Random = new Random();
            
            int number = Random.Next(0, 100);
            
            if (number > 0 && number < 25)
            {
                return args[0];
            }
            else if (number >= 25 && number < 50)
            {
                return args[1];
            }
            else if (number >= 75 && number < 100)
            {
                return args[2];
            }
            return args[3];
        }
    }
}
