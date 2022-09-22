using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Items
{
    internal class MachineGun : Item
    {
        public override string DefaultName => "Gépágyú";
        public override string DefaultSpriteId => "kenney_transparent_473";

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 1000;
            player._inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
