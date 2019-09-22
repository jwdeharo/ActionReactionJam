using UnityEngine;



public class ActionInteraction : MonoBehaviour
{
    [System.Serializable]
    public class ActionParameters
    {
        public bool BoolP;
        public float FloatP;
        public GameObject ObjectP;

        public bool SendFloat;
        public bool SendGameObject;
        public bool SendBool;

        public bool SendParam;
       
    }
    
    public Animator anim;
    public AudioClip[] actionSnd;
    public AudioSource audioS;
    public GameObject[] choices;
    public DeployChoices deployChoicesScript;

    private bool canInteract, isFire;

    [SerializeField]
    private bool HasOptions = true;
    [SerializeField]
    private GameObject OnlyChoice = null;
    [SerializeField]
    private string ActionToDo = "";
    [SerializeField]
    private bool mustDestroy;

    public ActionParameters ActionParams;

    private void Update()
    {
        if (enabled && Input.GetAxisRaw("Fire1") != 0 && canInteract)
        {
            if (!isFire)
            {
                isFire = true;

                if (HasOptions)
                {
                    deployChoicesScript.ShowChoices(choices);
                }
                else
                {
                    if (OnlyChoice != null)
                    {
                        if (ActionParams.SendFloat)
                        {
                            DoAction<float>(ActionParams.FloatP, ActionParams.SendParam, mustDestroy);
                        }
                        else if (ActionParams.SendBool)
                        {
                            DoAction<bool>(ActionParams.BoolP, ActionParams.SendParam, mustDestroy);
                        }
                        else 
                        {
                            DoAction<GameObject>(ActionParams.ObjectP, ActionParams.SendParam, mustDestroy);
                        }
                    }
                }

                VanishAnimation();
            }
        }
        else
        {
            isFire = false;
        }
    }

    /*
     * When player hits interactable object animation pops up 
     * and is possible to interact with it
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled && collision.tag == "Player")
        {
            canInteract = true;
            anim.gameObject.SetActive(false);
            anim.gameObject.SetActive(true);
            audioS.PlayOneShot(actionSnd[Random.Range(0,actionSnd.Length)]);
        }
    }

    /*
     * When player leaves the collider tha nimation dissapears
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enabled && collision.tag == "Player")
        {
            canInteract = false;
            VanishAnimation();

            if (HasOptions)
            {
                deployChoicesScript.DeactivateChoices(choices);
            }
        }
    }

    private void VanishAnimation()
    {
        anim.SetBool("canContinue", true);
    }

    private void DoAction<T>(T aToSend, bool aSendParam, bool destroy)
    {
        if (aSendParam)
        {
            OnlyChoice.SendMessage(ActionToDo, aToSend);
            
        }
        else
        {
            OnlyChoice.SendMessage(ActionToDo);
        }
        if(destroy)
            Destroy(gameObject);
    }

   
}
