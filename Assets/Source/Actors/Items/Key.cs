﻿using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Key : Item
    {
        // in txt: K
        public override char MapIcon => 'K';
        public override string DefaultName => ClassName;
        public static readonly string ClassName = "Key";
        public override string DefaultSpriteId => Sprites.Item["Key"];
        public override void Pickup(Player player)
        {
          
            player.Inventory.Add(this.DefaultName);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }
    }
}
