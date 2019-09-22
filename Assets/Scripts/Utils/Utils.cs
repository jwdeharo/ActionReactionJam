using UnityEngine;

public abstract class Utils : MonoBehaviour
{
    //Pasar la animacion por parametro, cuando esta haya finalizado devolverá true
    public static bool AnimationIsFinished(Animator anim)
    {
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).fullPathHash);
        return anim.isActiveAndEnabled && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && !anim.IsInTransition(0);
    }
}
