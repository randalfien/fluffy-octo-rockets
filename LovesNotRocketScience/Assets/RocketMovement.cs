using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float TargetX;

    public float PosX = 0;

    public float SpeedInc = 1f;

    public float Decay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        TargetX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PosX -= Time.deltaTime*SpeedInc;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PosX += Time.deltaTime*SpeedInc;
        }

        PosX *= 0.99f;

      /*  if (PosX > 0)
        {
            PosX = Mathf.Log(PosX + 1)/Mathf.Log(2);
        }
        else
        {
            PosX = -Mathf.Log(-PosX + 1)/Mathf.Log(2);
        }*/
        
        var target =  new Vector3(TargetX+PosX, transform.position.y, transform.position.z);
        
        transform.position = Vector3.Lerp(transform.position, target, 0.3f);
    }
}
