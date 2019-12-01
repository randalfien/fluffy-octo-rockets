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
