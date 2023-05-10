namespace DefaultNamespace.Enemy
{
    public interface IEnemy
    {
        public float attackCooldown { get; set; }
        public float range { get; set; }
        public int damage { get; set; }
    }
}