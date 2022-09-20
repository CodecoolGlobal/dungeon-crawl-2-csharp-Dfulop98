using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Characters.Enemy
{
    internal interface IDamageableEnemy : IDamageable
    {
        public void OnDeath(Player player);
        public void ApplyDamage(Player player);
    }
}
