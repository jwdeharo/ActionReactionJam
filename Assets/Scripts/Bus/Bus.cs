using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    public GameObject bus, player;
    public Animator busAnim;
    public float speed;
    public AudioSource audioS;
    public AudioClip clip,clipStop;

    private Vector2 target;
    private bool canMove;

    private void Start()
    {
        target = new Vector2(3.717f, bus.transform.position.y);
    }

    private void Update()
    {
        if (canMove)
        {
            bus.transform.position = Vector2.MoveTowards(bus.transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(bus.transform.position, target) == 0.0f)
            {
                StartCoroutine(Wait());
            }
        }
    }

    private void OnBus()
    {
        audioS.PlayOneShot(clip);
        player.SendMessage("ToWait", true);
        bus.SetActive(true);
        canMove = true;
    }

    IEnumerator Wait()
    {
        busAnim.SetBool("stop", true);
        player.SetActive(false);
        yield return new WaitForSeconds(1);
        busAnim.SetBool("stop", false);
        audioS.PlayOneShot(clip);
        target = new Vector2(6.717f, bus.transform.position.y);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }
}
