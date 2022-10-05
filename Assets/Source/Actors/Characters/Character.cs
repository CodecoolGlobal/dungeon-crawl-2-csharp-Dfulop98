namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }

        protected float ElapsedTime = 0;

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public abstract void TryMove(Direction direction);
        public override int Z => -1;

        protected abstract int SpriteIndex { get; set; }
        protected abstract float IdleTime { get; set; }

    }
}
