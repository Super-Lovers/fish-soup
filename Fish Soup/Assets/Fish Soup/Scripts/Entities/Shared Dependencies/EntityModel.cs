using UnityEngine;

public abstract class EntityModel : MonoBehaviour
{
    private Animator animator = null;

    private void Start()
    {
        // TODO: Homework on zeject component in local object hierarchy injection
        // Most likely temporary until I try to understand why
        // this can't work for me using ZenJect.
        animator = GetComponentInChildren<Animator>();
    }

    public virtual IProperties GetProperties()
    {
        throw new System.NotImplementedException();
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
