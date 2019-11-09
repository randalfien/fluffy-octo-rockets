using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn;

public class RocketDialogOptions : MonoBehaviour
{
    public TextMeshPro Text1;
    public TextMeshPro Text2;
    public GameObject Arrow1;
    public GameObject Arrow2;

    private OptionChooser _optionsCallback;

    private bool _optionsConfirmed = false;
    
    public void SetOptions(IList<string> options)
    {
        if (options.Count < 2) return;

        Text1.text = options[0];
        Text2.text = options[1];
        Arrow1.SetActive(true);
        Arrow2.SetActive(false);
    }

    public IEnumerator WaitForInput(OptionChooser optionChooser)
    {
        _optionsCallback = optionChooser;

        while (!_optionsConfirmed) yield return null;

        yield return new WaitForSeconds(1);
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space ) )
        {
            _optionsConfirmed = true;
            if (Arrow1.activeSelf)
            {
                _optionsCallback(0);
                Text2.gameObject.SetActive(false);
            }
            else
            {
                _optionsCallback(1);
                Text1.gameObject.SetActive(false);
            }          
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Arrow1.activeSelf)
            {
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
            }
            else
            {
                Arrow1.SetActive(true);
                Arrow2.SetActive(false);
            }
        }
        
    }
}
