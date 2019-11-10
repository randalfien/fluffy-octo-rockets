 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class initiate_controller : MonoBehaviour
{

    private int Step;
    public GameObject Switchtext1;
    public GameObject Switchtext2;
    public GameObject Switchtext3;
    // Start is called before the first frame update
    void Start()
    {
        Step = 0;
        InvokeRepeating("SwitchText", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.anyKeyDown)
        {
            SwitchScene();
        }
    }


    void SwitchScene () {
        SceneManager.LoadScene("StartScene");
    }

    void SwitchText() {
        Step++;

        if (Step == 1) {
            Switchtext2.gameObject.SetActive(false);
            Switchtext3.gameObject.SetActive(false);
            Switchtext1.gameObject.SetActive(true);
        } else if (Step == 2) {
            Switchtext1.gameObject.SetActive(false);
            Switchtext3.gameObject.SetActive(false);
            Switchtext2.gameObject.SetActive(true);
        } else if (Step == 3) {
            Switchtext1.gameObject.SetActive(false);
            Switchtext2.gameObject.SetActive(false);
            Switchtext3.gameObject.SetActive(true);
            Step=0;
        }
 
 
    }
}
