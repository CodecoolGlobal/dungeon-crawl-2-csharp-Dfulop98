using Assets.Source.Actors.SpritesCollection;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace Assets.Source.Actors.Items
{
    internal class Wand : Item
    {
        public override string DefaultName => "Brutál Pálca";
        public override char MapIcon => 'G';
        public override string DefaultSpriteId => Sprites.Item[DefaultName];

        public override void Pickup(Player player)
        {
            // Apply change
            player.Damage += 1000;
            player.Inventory.Add(this.DefaultName);
            UpdateSprite(player);
            ActorManager.Singleton.DestroyActor(this);
            EventLog.AddEvent($"{player.Name} picks up {DefaultName}");

        }
        private void UpdateSprite(Player player)
        {
            if (player.UsedSpriteCollection == Sprites.Wizard
                || player.UsedSpriteCollection == Sprites.WizardWithStick)
                player.UsedSpriteCollection = Sprites.WizardWithWand;
            else if (player.UsedSpriteCollection == Sprites.WizardBlanket
                || player.UsedSpriteCollection == Sprites.WizardStickBlanket)
                player.UsedSpriteCollection = Sprites.WizardWandBlanket;
        }
    }
}