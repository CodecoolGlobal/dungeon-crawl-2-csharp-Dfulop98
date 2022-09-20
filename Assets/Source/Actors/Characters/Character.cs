
using DungeonCrawl.Core;
using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public float Health;


        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();
            }
        }


        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        

        
    }
}
