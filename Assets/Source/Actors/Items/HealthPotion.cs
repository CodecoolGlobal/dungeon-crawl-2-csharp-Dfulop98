using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Items
{
    internal class HealthPotion : Item
    {
        public override string DefaultName => "Health Potion";
        public override int DefaultSpriteId => 896;

        public override void Pickup(Player player)
        {
            // Apply change
            player.Health += 10;
            ActorManager.Singleton.DestroyActor(this);
        }
    }
}
