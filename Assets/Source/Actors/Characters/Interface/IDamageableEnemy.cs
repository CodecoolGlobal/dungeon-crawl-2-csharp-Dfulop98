

namespace DungeonCrawl.Actors.Characters
{
    internal interface IDamageableEnemy : IDamageable
    {
        public void OnDeath(Player player);
        public void ApplyDamage(Player player);
    }
}
