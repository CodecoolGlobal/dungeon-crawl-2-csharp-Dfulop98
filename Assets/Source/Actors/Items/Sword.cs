
using Assets.Source.Actors.SpritesCollection;
using System.Runtime.CompilerServices;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Sword : Item
    {
        public override char MapIcon => 'w';
        public override string DefaultName => "Sword";
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 10;
            UpdateSprite(player);
            player.Inventory.Add(this.DefaultName);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }

        private void UpdateSprite(Player player)
        {
            if (player.UsedSpriteCollection == Sprites.Warrior
                || player.UsedSpriteCollection == Sprites.WarriorWithSpear)
                player.UsedSpriteCollection = Sprites.WarriorWithSword;
            else if (player.UsedSpriteCollection == Sprites.WarriorArmor
                || player.UsedSpriteCollection == Sprites.WarriorArmorSpear)
                player.UsedSpriteCollection = Sprites.WarriorArmorSword;
        }
        
    }
}
