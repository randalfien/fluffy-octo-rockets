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

    public SpriteRenderer Background;
    
    private OptionChooser _optionsCallback;

    private bool _optionsConfirmed = false;
    public string SelectedText { get; private set; }

    private IList<string> _savedOptions;

    private bool IsOneAnswer;
    
    public void SetOptions(IList<string> options)
    
    {
        _savedOptions = options;
        if (options.Count < 2)
        {
            IsOneAnswer = true;
            
            Text1.text = GetOptionText(options[0]);
            Text2.gameObject.SetActive(false);
            Arrow1.SetActive(true);
            Arrow2.SetActive(false);
            return;
        }

     
        
        Text1.text = GetOptionText(options[0]);
        Text2.text = GetOptionText(options[1]);
        Text1.ForceMeshUpdate();
        Text2.ForceMeshUpdate();

        float maxTextW = Mathf.Max(Text1.textBounds.size.x, Text2.textBounds.size.x)+ 3.6f*2f;
        Background.transform.localScale = new Vector3( maxTextW*6.5f , 17.24f,0f);
        Arrow1.SetActive(true);
        Arrow2.SetActive(false);
    }

    private string GetOptionText(string s)
    {
        if (s.Contains("$") == false) return s;

        return s.Split('$')[0];
    }
    
    private string GetReplyText(string s)
    {
        if (s.Contains("$") == false) return s;

        return s.Split('$')[1];
    }

    public IEnumerator WaitForInput(OptionChooser optionChooser)
    {
        _optionsCallback = optionChooser;

        while (!_optionsConfirmed) yield return null;

        yield return new WaitForSeconds(0.2f);
    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space ) )
        {
            _optionsConfirmed = true;
            if (Arrow1.activeSelf)
            {
                _optionsCallback(0);
                SelectedText = GetReplyText(_savedOptions[0]);
                Text2.gameObject.SetActive(false);
            }
            else
            {
                _optionsCallback(1);
                SelectedText = GetReplyText(_savedOptions[1]);
                Text1.gameObject.SetActive(false);
            }          
        }

        if (IsOneAnswer) return;
        
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
