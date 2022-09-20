using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using Debug = UnityEngine.Debug;

namespace Assets.Source.Actors.Items
{
    internal class Weapon : Item
    {
        public override string DefaultName => "Weapon";
        public override string DefaultSpriteId => "kenney_transparent_128";

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 10;
            player._inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
        }
    }
}
