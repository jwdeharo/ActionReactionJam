using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Target; //!< This is the target that the camera will follow.

    [SerializeField]
    private float MaxX;         //!< Max X for the camera to reach.
    [SerializeField]
    private float MaxY;         //!< Max Y for the camera to reach.
    [SerializeField]
    private float MinX;         //!< Min X for the camera to reach.
    [SerializeField]
    private float MinY;         //!< Min Y for the camera to reach.

    /**
     * Update is called once per frame
     */
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(Target.transform.position.x, MinX, MaxX), 
            Mathf.Clamp(Target.transform.position.y, MinY, MaxY), transform.position.z);
    }
}
