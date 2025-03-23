using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PenguinAnimator : MonoBehaviour
{
    private static readonly int _isRun = Animator.StringToHash("IsRun");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAnimation(bool isAnimationWork)
    {
        _animator.SetBool(_isRun, isAnimationWork);
    }
}
