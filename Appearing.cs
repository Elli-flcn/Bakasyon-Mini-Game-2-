using UnityEngine;

public class Appearing : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetTrigger("Open");
    }
}
