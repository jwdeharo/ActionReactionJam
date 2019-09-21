public class DeathState : CState
{
    public override void OnEnterState()
    {
        ((PlayerController)Controller).Animator.SetBool("IsDead", true);
    }
}
