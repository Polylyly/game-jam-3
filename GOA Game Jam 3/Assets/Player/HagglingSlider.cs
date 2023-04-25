using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HagglingSlider : MonoBehaviour
{
	private float _angularF = 5f;
	public bool _pauseToggle = false;
	private float _time = 0f;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if(_pauseToggle == false){
			_time += 0.3f * Time.deltaTime;
			transform.localPosition = new Vector2( (float) 0.473 * Mathf.Cos(_angularF * _time), (float) -0.27);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			_pauseToggle = true;
		}
		//if(Input.GetKeyUp(KeyCode.Space)){
		//	_pauseToggle = false;
		//}
	}

	public int getValue()
    {

		float iLerp = Mathf.InverseLerp(-0.473f, 0.473f, transform.localPosition.x);
		return (int) ( 100f * iLerp);

	}
}
