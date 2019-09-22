using UnityEngine;

public abstract class ChoiceGeneral : MonoBehaviour
{
    public string axisName;
    private bool isFire;

    [SerializeField]
    public bool MustDestroy;

    private void Update()
    {
        if (Input.GetAxisRaw(axisName) != 0 && GetComponent<SpriteRenderer>().color.a == 1)
        {
            if (!isFire)
            {
                isFire = true;
                PerformAction();
            }
        }
        else
        {
            isFire = false;
        }
    }

    protected abstract void PerformAction();

}
