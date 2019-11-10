 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
using Yarn.Unity;

public class EndSceneFadeIn : MonoBehaviour
{
 private SpriteRenderer MySpriteRenderer;
    void Start () {
    StartEnd();
        }
    
    public void StartEnd()
    {
                MySpriteRenderer = GetComponent<SpriteRenderer>();
                MySpriteRenderer.enabled = !MySpriteRenderer.enabled;
                  StartCoroutine(FadeTo(0f, 2.5f));
                  Invoke("SwitchSad",5f); 
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
}