using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployChoices : MonoBehaviour
{

    public float speed;

    private float step;
    [SerializeField]
    private bool twoChoices;

    private void Update()
    {
        step = speed * Time.deltaTime;
    }

    //Show the different choices by Action and orders them
    public void ShowChoices(GameObject[] choices)
    {
        float xPosition = 0.2f;

        if (twoChoices)
        {
            for (int i = 0; i < choices.Length; i++)
            {

                choices[i].SetActive(true);

                if (i % 2 == 0)
                {
                    StartCoroutine(SpreadChoicesRight(choices[i], xPosition));
                    xPosition += xPosition;
                }
                else
                    StartCoroutine(SpreadChoicesLeft(choices[i], xPosition));
            }
        }
        else
        {
            choices[0].SetActive(true);
        }
    }

    public void DeactivateChoices(GameObject[] choices)
    {
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].transform.position = choices[0].transform.position;
            choices[i].GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            choices[i].GetComponent<FadeIn>().enabled = true;
            choices[i].SetActive(false);
        }
    }

    //Orders choices even choices to the right
    IEnumerator SpreadChoicesRight(GameObject choice, float xPosition)
    {
        while (choice.transform.localPosition.x < xPosition)
        {
            choice.transform.localPosition = new Vector2(choice.transform.localPosition.x + step, choice.transform.localPosition.y);

            yield return null;
        }
        choice.transform.localPosition = new Vector2(xPosition, choice.transform.localPosition.y);
    }

    //Orders choices odd choices to the left
    IEnumerator SpreadChoicesLeft(GameObject choice, float xPosition)
    {
        while (choice.transform.localPosition.x > -xPosition)
        {
            choice.transform.localPosition = new Vector2(choice.transform.localPosition.x - step, choice.transform.localPosition.y);

            yield return null;
        }
        choice.transform.localPosition = new Vector2(-xPosition, choice.transform.localPosition.y);
    }

    public bool TwoChoices { get => twoChoices; set => twoChoices = value; }
}
