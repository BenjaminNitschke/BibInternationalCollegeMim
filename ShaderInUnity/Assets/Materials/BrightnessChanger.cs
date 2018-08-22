using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessChanger : MonoBehaviour
{
    MeshRenderer mr;


	// Use this for initialization
	void Awake ()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
        mr.material.SetFloat("_Brightness", (Mathf.Sin(Time.fixedTime)+1)*20);
	}
	
	// Update is called once per frame
	void Update ()
    {
        mr.material.SetFloat("_Brightness", (Mathf.Sin(Time.fixedTime) + 1) * 20);
    }
}
