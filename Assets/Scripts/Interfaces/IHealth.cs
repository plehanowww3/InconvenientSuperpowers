namespace Interfaces
{
    public interface IHealth
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }

        public void DecreaseHealth(int _value);
        public void IncreaseHealth(int _value);
    }
}