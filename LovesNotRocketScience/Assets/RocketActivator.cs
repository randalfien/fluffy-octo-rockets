using UnityEngine;
using Yarn.Unity;

public class RocketActivator : MonoBehaviour
{
    [YarnCommand("setactive")]
    public void SetObjectActive(string valueval)
    {
        if (valueval == "true")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
