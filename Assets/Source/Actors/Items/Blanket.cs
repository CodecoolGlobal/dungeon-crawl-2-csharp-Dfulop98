using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Items
{
    public class Blanket : Item
    {
        public override string DefaultName => "Köppeny";
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
            if (player.UsedSpriteCollection != Sprites.WizardStickBlanket
                 && player.UsedSpriteCollection != Sprites.WizardWandBlanket)
            {
                if (player.UsedSpriteCollection == Sprites.WizardWithStick)
                    player.UsedSpriteCollection = Sprites.WizardStickBlanket;
                else if (player.UsedSpriteCollection == Sprites.WizardWithWand)
                    player.UsedSpriteCollection = Sprites.WizardWandBlanket;
                else { player.UsedSpriteCollection = Sprites.WizardBlanket; }
            }
        }
    }
}