using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool thisSwitchOn = false;

    public GameObject[] colorLights;
    public GameObject blueSwitch;
    public GameObject greenSwitch;
    public GameObject redSwitch;
    public GameObject goal;

    public Material Emittion;
    public Material WhiteEmittion;

    private void OnTriggerStay(Collider _other)
    {
        if(_other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                thisSwitchOn = true;
                GetComponent<MeshRenderer>().material = Emittion;
                for (int i = 0; i < colorLights.Length; ++i)
                {
                    colorLights[i].GetComponent<MeshRenderer>().material = Emittion;
                }
                if (goal.CompareTag("StageGoal"))
                {
                    PlayerController.canGoal = true;
                    goal.GetComponent<MeshRenderer>().material = WhiteEmittion;
                }
                else if (goal.CompareTag("Goal"))
                {
                    if (blueSwitch.GetComponent<SwitchController>().thisSwitchOn == true && greenSwitch.GetComponent<SwitchController>().thisSwitchOn == true && redSwitch.GetComponent<SwitchController>().thisSwitchOn == false)
                    {
                        PlayerController.canGoal = true;
                        goal.GetComponent<MeshRenderer>().material = WhiteEmittion;
                    }
                }
            }
        }
    }
}
