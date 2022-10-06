using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace Assets.Source.Actors.Items
{
    internal class Stick : Item
    {
        public override string DefaultName => "Pálca";
        public override char MapIcon => 'w';
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            // Apply change
            player.Inventory.Add(this.DefaultName);
            UpdateSprite(player);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");

        }
        private void UpdateSprite(Player player)
        {
            if (player.UsedSpriteCollection == Sprites.Wizard
                || player.UsedSpriteCollection == Sprites.WizardWithWand)
                player.UsedSpriteCollection = Sprites.WizardWithStick;
            else if (player.UsedSpriteCollection == Sprites.WizardBlanket
                || player.UsedSpriteCollection == Sprites.WizardWandBlanket)
                player.UsedSpriteCollection = Sprites.WizardStickBlanket;
        }
    }
}
