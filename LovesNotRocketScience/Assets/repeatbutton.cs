using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class repeatbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(1, 3f).SetDelay(10);
    }


    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("InitiateScene");
    }
}
