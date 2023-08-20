using UnityEngine;
using Interfaces;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int MaxHealthProperty;
    [SerializeField] private int CurrentHealthProperty;
    [SerializeField] private Image m_hpFiller;
    private Animator anim;
    private bool dead;
    private bool invulnerable;
    
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    private void Start()
    {
        MaxHealth = MaxHealthProperty;
        IncreaseHealth(MaxHealth);
    }

    public void DecreaseHealth(int _value)
    {
        CurrentHealth -= _value;
        CurrentHealthProperty = CurrentHealth;
    }
    public void IncreaseHealth(int _value)
    {
        CurrentHealth += _value;
        CurrentHealthProperty = CurrentHealth;
    }

    public void IncreaseMaxHealth(int _value) => MaxHealth += _value;
    public void DecreaseMaxHealth(int _value) => MaxHealth -= _value;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth - _damage, 0, MaxHealth);

        m_hpFiller.fillAmount = 1f * CurrentHealth / MaxHealth;

        if (CurrentHealth <= 0)
        {
            
        }
        /*if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;
            }
        }*/
    }
    
    /*private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }*/
}