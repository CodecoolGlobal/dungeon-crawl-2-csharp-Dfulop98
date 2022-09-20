
using DungeonCrawl.Core;
using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }


        public abstract void ApplyDamage(int damage);
        public abstract void ApplyDamage(int damage, Player player);



        protected abstract void OnDeath();
        protected abstract void OnDeath(Player player);

        protected abstract void OnDeathFeedBack();
        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        

        
    }
}
