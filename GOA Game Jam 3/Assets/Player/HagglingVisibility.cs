using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagglingVisibility : MonoBehaviour
{
    private bool _visible = false;
    private SpriteRenderer _sp;
    private SpriteRenderer _spChild;
    // Update is called once per frame
    public static HagglingVisibility instance;
    void Awake(){
        instance = this;
    }
    void Start(){
    	_sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(_visible){
        	_sp.enabled = true;
        }else{
        	_sp.enabled = false;
        }
    }
    public bool visibilityStatus(){
        return _sp.enabled;
    }
    public void Show()
    {
        _visible = true;
        _sp.enabled = true;
    }

    public void Hide()
    {
        _visible = false;
        _sp.enabled = false;
    }

}
