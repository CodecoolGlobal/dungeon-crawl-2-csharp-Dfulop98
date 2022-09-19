using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Items
{
    internal class HealthPotion : Item
    {
        public override string DefaultName => "Health Potion";
        public override int DefaultSpriteId => 896;

        public override void Pickup(Actor player)
        {
            // Apply change
            // player.Health += 10;
            ActorManager.Singleton.DestroyActor(this);
        }
    }
}
