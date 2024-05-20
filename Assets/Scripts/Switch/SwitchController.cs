using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchController : MonoBehaviour
{
    public bool whiteSwitch;
    public bool bySwitch;

    public GameObject[] colorLights;
    public GameObject goal;
    public GameObject switchManager;

    public Material White;
    public Material WhiteEmittion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (bySwitch)
            InputE();
            Debug.Log($"redSwitch: {SwitchManager.redSwitch},\n blueSwitch: {SwitchManager.blueSwitch},\n greenSwitch: {SwitchManager.greenSwitch}");
        }
    }

    public virtual void InputE()
    {

    }

    public virtual void RGBGoal()
    {
        if (goal.CompareTag("Goal"))
        {
            Debug.Log("白く光る");
            if (SwitchManager.redSwitch == true && SwitchManager.blueSwitch == true && SwitchManager.greenSwitch == true)
            {
                PlayerController.canGoal = true;
                goal.GetComponent<MeshRenderer>().material = WhiteEmittion;
            }
        }
    }

    public void GoalOff()
    {
        PlayerController.canGoal = false;
        goal.GetComponent<MeshRenderer>().material = White;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.CompareTag("Player"))
        {
            bySwitch = true;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if(_other.gameObject.CompareTag("Player"))
        {
            bySwitch = false;
        }
    }
}
