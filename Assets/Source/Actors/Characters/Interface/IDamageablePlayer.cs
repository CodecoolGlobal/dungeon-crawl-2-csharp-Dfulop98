using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Characters
{
    internal interface IDamageablePlayer : IDamageable
    {
        public void OnDeath();
        public void ApplyDamage(Enemy.Enemy enemy);
    }
}
