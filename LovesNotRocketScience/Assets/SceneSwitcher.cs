 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneSwitcher : MonoBehaviour
{
    private SpriteRenderer MySpriteRenderer;

    [YarnCommand("switchscene")]
    
    public void SwitchScene(string valueval)
    {
                MySpriteRenderer = GetComponent<SpriteRenderer>();
                MySpriteRenderer.enabled = !MySpriteRenderer.enabled;
                  StartCoroutine(FadeTo(1f, 2.5f));
    
        
        if (valueval == "happy")
        {
            Invoke("SwitchHappy",5f);
        }
        else
        {
            Invoke("SwitchSad",5f); 
        }
    }

IEnumerator FadeTo(float aValue, float aTime)
     {
         float alpha = gameObject.GetComponent<SpriteRenderer>().color.a;
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
             gameObject.GetComponent<SpriteRenderer>().color = newColor;
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
