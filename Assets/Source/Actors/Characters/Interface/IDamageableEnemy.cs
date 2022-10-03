using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Characters.Enemy
{
    internal interface IDamageableEnemy : IDamageable
    {
        public void OnDeath(Player player);
        public void ApplyDamage(Player player);
    }
}
