using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class RedSwitch 
: SwitchController
{
    public Material Emission;
    public Material EmissionOff;

    public override void InputE()
    {
        if (!SwitchManager.redSwitch)
        {
            SwitchManager.redSwitch = true;
            Debug.Log(SwitchManager.redSwitch);
            GetComponent<MeshRenderer>().material = Emission;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = Emission;
            }
            RGBGoal();
        }
        else if (SwitchManager.redSwitch)
        {
            SwitchManager.redSwitch = false;
            GetComponent<MeshRenderer>().material = EmissionOff;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = EmissionOff;
            }
            GoalOff();
        }
    }
}
