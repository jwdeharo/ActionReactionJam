using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Target = null; //!< This is the target that the camera will follow.

    [SerializeField]
    private float MaxX = 0.0f;         //!< Max X for the camera to reach.
    [SerializeField]
    private float MaxY = 0.0f;         //!< Max Y for the camera to reach.
    [SerializeField]
    private float MinX = 0.0f;         //!< Min X for the camera to reach.
    [SerializeField]
    private float MinY = 0.0f;         //!< Min Y for the camera to reach.

    /**
     * Update is called once per frame
     */
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(Target.transform.position.x, MinX, MaxX), 
            Mathf.Clamp(Target.transform.position.y, MinY, MaxY), transform.position.z);
    }
}
