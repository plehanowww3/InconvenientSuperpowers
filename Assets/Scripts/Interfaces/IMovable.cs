namespace Interfaces
{
    public interface IMovable
    {
        public float moveSpeed { get; set; }

        sealed void Move() { }
        public void DecreaseMoveSpeed(float _value);
        public void IncreaseMoveSpeed(float _value);
    }
}