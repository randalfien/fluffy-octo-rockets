 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    [YarnCommand("switchscene")]
    public void SwitchScene(string valueval)
    {
        
        StartCoroutine(FadeTo(1.0f, 1f));
    
        
        if (valueval == "happy")
        {
            Invoke("SwitchHappy",3f);
        }
        else
        {
            Invoke("SwitchSad",3f); 
        }
    }
IEnumerator FadeTo(float aValue, float aTime)
     {
         float alpha = gameObject.GetComponent<SpriteRenderer>().material.color.a;
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
             gameObject.GetComponent<SpriteRenderer>().material.color = newColor;
             yield return null;
         }
     }

    public void SwitchHappy() {
         SceneManager.LoadScene("HappyEnd");
    }  

    public void SwitchSad() {
                    SceneManager.LoadScene("SmutnyEnd");

    }

}
