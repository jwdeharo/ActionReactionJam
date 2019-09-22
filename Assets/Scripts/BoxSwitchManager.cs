using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitchManager : MonoBehaviour
{
    public Transform player;
    public GameObject boxInteract;

    private float boxPositionX;
    private float playerPositionY;

    void Start()
    {
        boxPositionX = transform.position.x;
        playerPositionY = player.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        CheckSwitchOn();
    }

    public void CheckSwitchOn()
    {
        print("BOX POS X " + transform.position.x + " BOXPOSI X " + boxPositionX + " PLAYER POS Y " + player.position.y + " PLAYERPOSI Y " + playerPositionY);
        if (transform.position.x!= boxPositionX && player.position.y<= playerPositionY)
        {
            boxInteract.SetActive(true);
        }
    }

    public void InitializePositions()
    {
        boxPositionX = transform.position.x;
        playerPositionY = player.transform.position.y;
    }

    public void CheckSwitchOff()
    {
        boxInteract.SetActive(false);
        playerPositionY = player.position.y;
    }
}
