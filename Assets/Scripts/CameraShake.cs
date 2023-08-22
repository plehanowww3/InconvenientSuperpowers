using DefaultNamespace;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    private void Start()
    {
        //GameManager.instance.m_shakeCamera = this;
    }

    public void Shake()
    {
        m_animator.SetTrigger("Shake");
    }
}
