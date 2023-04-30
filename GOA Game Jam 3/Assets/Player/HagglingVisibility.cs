using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HagglingVisibility : MonoBehaviour
{
    private bool _visible = false;
    private SpriteRenderer _sp;
    private SpriteRenderer _spChild;
    // Update is called once per frame
    public static HagglingVisibility instance;
    public TextMeshProUGUI text;
    void Awake(){
        instance = this;
    }
    void Start(){
    	_sp = GetComponent<SpriteRenderer>();
        text.enabled = false;
    }
    void Update()
    {
        if(_visible){
        	_sp.enabled = true;
            text.enabled = true;
        }
        else{
        	_sp.enabled = false;
            text.enabled = false;
        }
    }
    public bool visibilityStatus(){
        return _sp.enabled;
    }
    public void Show()
    {
        _visible = true;
        _sp.enabled = true;
        text.enabled = true;
    }

    public void Hide()
    {
        _visible = false;
        _sp.enabled = false;
        text.enabled = false;
    }

}
