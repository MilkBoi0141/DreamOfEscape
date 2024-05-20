using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class WhiteSwitch : SwitchController
{
    public Material Emission;
    public Material EmissionOff;

    public override void InputE()
    {
        if (!SwitchManager.whiteSwitch)
        {
            SwitchManager.whiteSwitch = true;
            Debug.Log(SwitchManager.whiteSwitch);
            GetComponent<MeshRenderer>().material = Emission;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = Emission;
            }
            RGBGoal();
        }
        else if (SwitchManager.whiteSwitch)
        {
            SwitchManager.whiteSwitch = false;
            GetComponent<MeshRenderer>().material = EmissionOff;
            for (int i = 0; i < colorLights.Length; ++i)
            {
                colorLights[i].GetComponent<MeshRenderer>().material = EmissionOff;
            }
            GoalOff();
        }
    }

    public override void RGBGoal()
    {
        if (goal.CompareTag("StageGoal"))
        {
            if (SwitchManager.whiteSwitch == true)
            {
                Debug.Log("Stage1");
                PlayerController.canGoal = true;
                goal.GetComponent<MeshRenderer>().material = WhiteEmittion;
            }
        }
    }
}
