using DefaultNamespace.Interfaces;
using Interfaces;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour, IMovable
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float MoveSpeedProperty;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;
    public float moveSpeed { get; set; }
    
    
    private void Awake()
    {
        IncreaseMoveSpeed(10);
        anim = GetComponent<Animator>();
    }

    public void DecreaseMoveSpeed(float _value)
    {
        moveSpeed -= _value;
        MoveSpeedProperty = moveSpeed;
    }

    public void IncreaseMoveSpeed(float _value)
    {
        moveSpeed += _value;
        MoveSpeedProperty = moveSpeed;
    }


    private void Move()
    {
        
    }
    
}