using UnityEngine;

public class FrankieTheKillerIdleState : CState
{
    private float RotationRadius = 0.003f;
    private float AngularSpeed = 2.0f;
    private float PositionX;
    private float PositionY;
    private float Angle;

    public override void OnEnterState()
    {
        Angle = 0.0f;
    }

    /**
     * Function that is called while the state is the current.
     */
    public override void UpdateState()
    {
        PositionX = Controller.transform.position.x + Mathf.Cos(Angle) * RotationRadius;
        PositionY = Controller.transform.position.y + Mathf.Sin(Angle) * RotationRadius;

        Controller.transform.position = new Vector3(PositionX, PositionY, 0.0f);
        Angle += Time.deltaTime * AngularSpeed;

        if (Angle > 360.0f)
        {
            Angle = 0.0f;
        }
    }
}
