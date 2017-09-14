using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClass : MonoBehaviour {

    public Client player; //add the client object

    public void setClass()
    {
        //Debug.Log(this.gameObject.name);
        if (this.gameObject.name.Contains("Pilot"))
        {
            player.setClassName(ClassName.pilot);
        }
        else if (this.gameObject.name.Contains("Gunner"))
        {
            player.setClassName(ClassName.gunner);
        }
        else if (this.gameObject.name.Contains("Defender"))
        {
            player.setClassName(ClassName.defender);
        }
    }
}
