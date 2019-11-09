using System.Collections;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class RocketDialogUI : DialogueUIBehaviour
{
    public GameObject BubblePrefab;
    
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

        yield break;
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
