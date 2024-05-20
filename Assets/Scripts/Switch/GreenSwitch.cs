using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSwitch : SwitchController
{
    public Material Emission;
    public Material EmissionOff;

    public override void InputE()
    {
        if (!SwitchManager.greenSwitch)
        {
            SwitchManager.greenSwitch = true;
            Debug.Log(SwitchManager.greenSwitch);
            GetComponent<MeshRenderer>().material = Emission;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = Emission;
            }
            RGBGoal();
        }
        else if (SwitchManager.greenSwitch)
        {
            SwitchManager.greenSwitch = false;
            GetComponent<MeshRenderer>().material = EmissionOff;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = EmissionOff;
            }
            GoalOff();
        }
    }
}
