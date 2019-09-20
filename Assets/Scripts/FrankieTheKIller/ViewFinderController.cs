using UnityEngine;

public class ViewFinderController : BaseController
{
    // Start is called before the first frame update
    void Start()
    {
        //MyFSM = GetComponent<FSM>();
        //MyFSM.StartFSM();
    }

    private void StartChasing()
    {
        Debug.Log("Starting the chase");
    }

    private void StopChasing()
    {
        Debug.Log("Stoping the chase");
    }
}
