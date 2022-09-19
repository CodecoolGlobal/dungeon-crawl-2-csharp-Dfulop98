using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Items
{
    public abstract class Item : Actor
    {
        public abstract void Pickup(Actor player);

    }
}
