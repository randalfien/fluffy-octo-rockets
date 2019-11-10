 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class introcontroller : MonoBehaviour
{

    private int Step;

    public GameObject IntroText1;
    public GameObject IntroText2;

    public GameObject Switchtext1;
    public GameObject Switchtext2;
    public GameObject Switchtext3;
    // Start is called before the first frame update
    void Start()
    {
        Step = 0;
        Invoke("ShowText1", 1.3f);
        Invoke("ShowText2", 3.3f);
        Invoke("SwitchScene", 20f);
        InvokeRepeating("SwitchText", 1.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowText1 () {
        IntroText1.gameObject.SetActive(true);
    }

    void ShowText2 () {
        IntroText2.gameObject.SetActive(true);
    }

    void SwitchScene () {
        SceneManager.LoadScene("Scene1");
    }

    void SwitchText() {
        Step++;
        Switchtext1.gameObject.SetActive(false);
        Switchtext2.gameObject.SetActive(false);
        Switchtext3.gameObject.SetActive(false);

        if (Step == 1) {
            Switchtext1.gameObject.SetActive(true);
        } else if (Step == 2) {
            Switchtext2.gameObject.SetActive(true);
        } else if (Step == 3) {
            Switchtext3.gameObject.SetActive(true);
            Step=0;
        }
 
 
    }
}
