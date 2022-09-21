
using DungeonCrawl.Core;
using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }

        protected abstract void OnDeathFeedBack();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public abstract void TryMove(Direction direction);
        public override int Z => -1;

        

        
    }
}
