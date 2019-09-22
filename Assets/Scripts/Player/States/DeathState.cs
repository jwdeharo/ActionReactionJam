using UnityEngine.SceneManagement;

public class DeathState : CState
{
    public override void OnEnterState()
    {
        ((PlayerController)Controller).Animator.SetBool("IsDead", true);
    }

    public override void UpdateState()
    {
        if (Utils.AnimationIsFinished(((PlayerController)Controller).Animator))
        {
            SceneManager.LoadScene("Muerte");
        }
    }
}
