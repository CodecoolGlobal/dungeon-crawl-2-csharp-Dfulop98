using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Armor : Item
    {
        public override string DefaultName => "Armor";
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            // Apply change
            // TODO: add to armor status
            player.Inventory.Add(this);
            ActorManager.Singleton.DestroyActor(this);
            UpdateSprite(player);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");
        }

        private void UpdateSprite(Player player)
        {
            if (player.UsedSpriteCollection != Sprites.WarriorArmorSpear
                 && player.UsedSpriteCollection != Sprites.WarriorArmorSword)
            {
                if (player.UsedSpriteCollection == Sprites.WarriorWithSword)
                    player.UsedSpriteCollection = Sprites.WarriorArmorSword;
                else if (player.UsedSpriteCollection == Sprites.WarriorWithSpear)
                    player.UsedSpriteCollection = Sprites.WarriorArmorSpear;
                else { player.UsedSpriteCollection = Sprites.WarriorArmor; }
            }
        }
    }
}