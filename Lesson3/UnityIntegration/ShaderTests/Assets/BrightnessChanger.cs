using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessChanger : MonoBehaviour
{
	void Start () {
		renderer = GetComponent<MeshRenderer>();
	}

	private MeshRenderer renderer;
	
	void Update ()
	{
		renderer.material.SetFloat("_Brightness", (Mathf.Sin(Time.fixedTime)+1)*20);
	}
}
