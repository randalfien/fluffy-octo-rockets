using System.Collections;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class RocketDialogUI : DialogueUIBehaviour
{
    public GameObject BubblePrefab;
    public GameObject OptionsPrefab;
    public Transform Point1;
    public Transform Point2;
    public Transform OptionsPoint;
    public Camera GameObjectCamera;
    
    public override IEnumerator RunLine(Line line)
    {
        print(line.text);
        var bubble = Instantiate(BubblePrefab);
        bubble.GetComponent<DialogBubble>().Text = line.text;
        bubble.transform.position = Point1.position;
        GameObjectCamera.gameObject.SetActive(false);
        yield return new WaitForSeconds(line.text.Length*0.05f);
        GameObjectCamera.gameObject.SetActive(true);
        Destroy(bubble);
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
        
        var bubble = Instantiate(BubblePrefab);
        bubble.GetComponent<DialogBubble>().Text = optionsScript.SelectedText;
        bubble.transform.position = Point2.position;
        
        yield return new WaitForSeconds(optionsScript.SelectedText.Length*0.03f);
        Destroy(bubble);
        Destroy(optionsp);
    }

    public override IEnumerator RunCommand(Command command)
    {
        yield break;
    }
    
    public override IEnumerator DialogueComplete () {
        print("complete");
        yield break;
    }
    
    public override IEnumerator DialogueStarted () {
        print("start");
        yield break;
    }
}
