using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class RocketDialogUI : DialogueUIBehaviour
{
    public static Color TextColor = Color.white;
    
    public GameObject BubblePrefab;
    public GameObject OptionsPrefab;
    public Transform Point1;
    public Transform Point2;
    public Transform OptionsPoint;
    public Camera GameObjectCamera;

    public float Padding = 2.1f;
    
    private List<GameObject> R1Bubbles = new List<GameObject>();
    private List<GameObject> R2Bubbles = new List<GameObject>();
    
    public override IEnumerator RunLine(Line line)
    {
        print(line.text);
        if (line.text.StartsWith("wait("))
        {
            print(int.Parse(line.text.Substring(5,1)));
            yield return new WaitForSeconds(int.Parse(line.text.Substring(5,1)));
            yield break;
        }
        
        foreach (var a in R1Bubbles)
        {
            a.transform.DOMove(a.transform.position + Vector3.up * Padding, 1).SetEase(Ease.InOutCubic);
            a.GetComponentInChildren<TextMeshPro>().DOFade(0, 2).SetDelay(1);
        }
        foreach (var a in R2Bubbles)
        {
            a.transform.DOMove(a.transform.position + Vector3.up * Padding, 1).SetEase(Ease.InOutCubic);
            a.GetComponentInChildren<TextMeshPro>().DOFade(0, 2).SetDelay(1);
        }
        if (R1Bubbles.Count > 0)
        {
            yield return new WaitForSeconds(0.5f);
        }

        var bubble = Instantiate(BubblePrefab);
        bubble.GetComponentInChildren<TextMeshPro>().color = TextColor;
        if (line.text[0] == '$')
        {
            bubble.GetComponent<DialogBubble>().Text = line.text.Substring(1);
            bubble.transform.position = Point2.position;
            R2Bubbles.Add(bubble);
        }
        else
        {
            bubble.GetComponent<DialogBubble>().Text = line.text;
            bubble.transform.position = Point1.position;
            R1Bubbles.Add(bubble);
        }

        GameObjectCamera.gameObject.SetActive(false);
        yield return new WaitForSeconds(line.text.Length*0.06f);
        GameObjectCamera.gameObject.SetActive(true);
        
        
    }

    public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
    {
        print("options");
        foreach (var a in optionsCollection.options)
        {
            print(a);
        }
        
        

        var optionsp = Instantiate(OptionsPrefab);
        optionsp.transform.position = OptionsPoint.position;
        var optionsScript = optionsp.GetComponent<RocketDialogOptions>();
        optionsScript.SetOptions(optionsCollection.options);
        yield return optionsScript.WaitForInput(optionChooser);
        

        
        Destroy(optionsp);

        foreach (var a in R2Bubbles)
        {
            a.transform.DOMove(a.transform.position + Vector3.up * Padding, 1).SetEase(Ease.InOutCubic);
            a.GetComponentInChildren<TextMeshPro>().DOFade(0, 2).SetDelay(1);
        }

        if (R2Bubbles.Count > 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        var bubble = Instantiate(BubblePrefab);
        bubble.GetComponentInChildren<TextMeshPro>().color = TextColor;
        bubble.GetComponent<DialogBubble>().Text = optionsScript.SelectedText;
        bubble.transform.position = Point2.position;
        
        R2Bubbles.Add(bubble);
        
        yield return new WaitForSeconds(optionsScript.SelectedText.Length*0.06f);
    }

    public override IEnumerator RunCommand(Command command)
    {
        yield break;
    }
    
    public override IEnumerator DialogueComplete () {
        yield return new WaitForSeconds(2f);
        
        foreach (var a in R1Bubbles)
        {
            a.GetComponent<DialogBubble>().TextText.DOFade(0, 2f);
        }
        foreach (var a in R2Bubbles)
        {
            a.GetComponent<DialogBubble>().TextText.DOFade(0, 2f);
        }
        
        
        yield return new WaitForSeconds(2f);
    }
    
    public override IEnumerator DialogueStarted () {
        print("start");
        yield break;
    }


    [YarnCommand("color")]
    public void ColorRocket(string option)
    {
        
    }
}
