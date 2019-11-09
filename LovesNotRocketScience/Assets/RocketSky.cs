using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RocketSky : MonoBehaviour
{
    [YarnCommand("move")]
    public void MoveCharacter(string destinationName) {
       print(destinationName);
    }
}
