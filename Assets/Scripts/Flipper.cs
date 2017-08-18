using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;
    public string flipperinput;

    private HingeJoint hingejointflipper;

    void Start () {
        hingejointflipper = GetComponent<HingeJoint>();
        hingejointflipper.useSpring = true;
    }
	
	void FixedUpdate () {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;
        if (Input.GetAxis(flipperinput) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;

        }
        hingejointflipper.spring = spring;
        hingejointflipper.useLimits = true;
    }
    
}
