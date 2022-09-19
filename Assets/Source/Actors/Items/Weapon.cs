using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Items
{
    internal class Weapon : Item
    {
        public override string DefaultName => "Weapon";
        public override int DefaultSpriteId => 128;

        public override void Pickup(Actor player)
        {
            // Apply change
            // player.damage += 10;
            // player._inventory.Add(this);
        }
    }
}
