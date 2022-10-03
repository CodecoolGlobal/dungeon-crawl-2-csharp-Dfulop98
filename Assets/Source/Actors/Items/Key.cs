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
    public class Key : Item
    {
        // in txt: K
        public override string DefaultName => "Key";
        public override string DefaultSpriteId => "kenney_transparent_559";
        public override void Pickup(Player player)
        {
          
            player._inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
