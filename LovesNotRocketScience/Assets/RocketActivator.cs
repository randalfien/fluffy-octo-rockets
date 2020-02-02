using UnityEngine;
using Yarn.Unity;

public class RocketActivator : MonoBehaviour
{
    private void Awake()
    {
        SetObjectActive("false");
    }

    [YarnCommand("setactive")]
    public void SetObjectActive(string valueval)
    {
        Debug.Log("setting " + gameObject.name + " active:" + valueval);
        if (transform.childCount < 1)
        {
            Debug.Log("object already destroyed");
            return;
        }
        if (valueval == "true")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void DDestroy()
    {
        Destroy(gameObject);
    }
}
