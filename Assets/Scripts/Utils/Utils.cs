using UnityEngine;

public abstract class Utils : MonoBehaviour
{
    //Pasar la animacion por parametro, cuando esta haya finalizado devolverá true
    public static bool AnimationIsFinished(Animator anim)
    {
        return anim.isActiveAndEnabled && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !anim.IsInTransition(0);
    }
}
