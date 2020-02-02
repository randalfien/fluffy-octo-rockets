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
                  StartCoroutine(FadeTo(1f, 2.5f, valueval));
    }

IEnumerator FadeTo(float aValue, float aTime, string val)
     {
         yield return new WaitForSeconds(2.5f);
         MySpriteRenderer = GetComponent<SpriteRenderer>();
         MySpriteRenderer.enabled = true;
         float alpha = 0;
         for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
         {
             Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
             gameObject.GetComponent<SpriteRenderer>().color = newColor;
             yield return null;
         }
         
                 
         if (val == "happy")
         {
             SwitchHappy();
         }
         else
         {
             SwitchSad(); 
         }
     }

    public void SwitchHappy() {
         SceneManager.LoadScene("HappyEnd");
    }  

    public void SwitchSad() {
                    SceneManager.LoadScene("SmutnyEnd");

    }

}
