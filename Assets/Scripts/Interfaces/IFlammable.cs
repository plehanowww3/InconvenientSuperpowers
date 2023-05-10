using Interfaces;

namespace DefaultNamespace.Interfaces
{
    public interface IFlammable: IEffect
    {
        public float FlameDuration { get; set; }
        public float FlameRate { get; set; }
        public float FlameDamage { get; set; }
        
        public void InitFlammable(float _duration, float _rate, float _damage);
    }
}