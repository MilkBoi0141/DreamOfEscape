using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSwitch : SwitchController
{
    public Material Emission;
    public Material EmissionOff;

    public override void InputE()
    {
        if (!SwitchManager.blueSwitch)
        {
            SwitchManager.blueSwitch = true;
            Debug.Log(SwitchManager.blueSwitch);
            GetComponent<MeshRenderer>().material = Emission;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = Emission;
            }
            RGBGoal();
        }
        else if (SwitchManager.blueSwitch)
        {
            SwitchManager.blueSwitch = false;
            GetComponent<MeshRenderer>().material = EmissionOff;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = EmissionOff;
            }
            GoalOff();
        }
    }
}
