using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public static bool whiteSwitch;
    public static bool redSwitch;
    public static bool blueSwitch;
    public static bool greenSwitch;

    // Start is called before the first frame update
    void Start()
    {
        whiteSwitch = false;
        redSwitch = false;
        blueSwitch = false;
        greenSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
