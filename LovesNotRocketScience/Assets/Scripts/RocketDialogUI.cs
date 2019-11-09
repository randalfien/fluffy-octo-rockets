using System.Collections;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class RocketDialogUI : DialogueUIBehaviour
{
    public GameObject BubblePrefab;
    public GameObject OptionsPrefab;
    
    public override IEnumerator RunLine(Line line)
    {
        print(line.text);
        var bubble = Instantiate(BubblePrefab);
        bubble.GetComponent<DialogBubble>().Text = line.text;
        yield return new WaitForSeconds(line.text.Length*0.05f);
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
        var optionsScript = optionsp.GetComponent<RocketDialogOptions>();
        optionsScript.SetOptions(optionsCollection.options);
        yield return optionsScript.WaitForInput(optionChooser);
        
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
