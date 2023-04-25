using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is just a data container for variables relating to scrap
public class ScrapData : MonoBehaviour
{
    //enums for different types of scrap are defined here
    //I used public enums so that other scripts, such as the scrap merchant script,
    //can also use the same enums to read the scrap data

    public enum ScrapType { Gear, Circuit, Battery };
    public enum ScrapCondition { Rusty, Cracked, Sandy}
    public enum ScrapColor { Teal, Brown, Grey}


 


    //the variables defined here are not final, just for testing
    //purposes and we can change them all later
    public ScrapType type;
    public ScrapCondition condition;
    public ScrapColor color;
    public int weight;
    public Sprite sprite;

    //you can uncomment the update function if you want to test out the script a bit
    //private void Update()
    //{
    //    Debug.Log(Description());
    //    if (Input.GetKeyDown("a")) Randomize();
    //}

    public void Randomize()
    {
        //can be called when generating new scrap to give the scrap random parameters
        type = (ScrapType)Random.Range(0, 3);
        condition = (ScrapCondition)Random.Range(0, 3);
        color = (ScrapColor)Random.Range(0, 3);
        weight = (int)Random.Range(1, 10);
        sprite = Resources.Load<Sprite>(type.ToString()) as Sprite;
        
    }

    public string Name()
    {
        string typeName = type.ToString();
        return typeName;
    }
    public string Description()
    {
        //gives a description of the item
        string typeName = type.ToString();
        string conditionName = condition.ToString();
        string colorName = color.ToString();
        
        return "A " + conditionName.ToLower() + ", " + colorName.ToLower() + " " + typeName.ToLower() + " weighing " + weight + " grams.";
        
    }

    public void Copy(ScrapData data)
    {
        type = data.type;
        weight = data.weight;
        condition = data.condition;
        color = data.color;
        sprite = data.sprite;
    }

    public int getValue()
    {
        int value = 0;
        switch (type) {
            case ScrapType.Gear:
                //code for usable value
                if(condition == ScrapCondition.Sandy)
                {
                    value = 25;
                }else if(condition == ScrapCondition.Cracked)
                {
                    value = 10;  
                }else if (condition == ScrapCondition.Rusty)
                {
                    value = 15;
                    if (condition == ScrapCondition.Rusty && color == ScrapColor.Teal)
                    {
                        value = Mathf.Max(value, weight * 10);
                    }
                }
                //code for melted down value
                if(color == ScrapColor.Grey)
                {
                    value = Mathf.Max(value, weight * 5);
                }
                break;
            case ScrapType.Battery:
                //code for usable value
                if (condition == ScrapCondition.Sandy)
                {
                    if (color == ScrapColor.Teal)
                    {
                        value = 35;
                    }
                    else if (color == ScrapColor.Brown)
                    {
                        value = 20;
                    }
                    value = 25;
                }
                else if (condition == ScrapCondition.Cracked)
                {
                    value = 5;
                }
                else if (condition == ScrapCondition.Rusty)
                {
                    if(color == ScrapColor.Teal)
                    {
                        value = 35;
                    }else if(color == ScrapColor.Brown)
                    {
                        value = 20;
                    }
                    if (condition == ScrapCondition.Rusty && color == ScrapColor.Teal)
                    {
                        value = Mathf.Max(value, weight * 10);
                    }
                }
                //code for melted down value
                if (color == ScrapColor.Grey)
                {
                    value = Mathf.Max(value, weight * 5);
                }
                break;
            case ScrapType.Circuit:
                //code for usable value
                if (condition == ScrapCondition.Sandy)
                {
                    value = 5;
                }
                else if (condition == ScrapCondition.Cracked)
                {
                    if(color == ScrapColor.Teal)
                    {
                        value = 45;
                    }else if(color == ScrapColor.Brown)
                    {
                        value = 15;
                    }else if(color == ScrapColor.Grey)
                    {
                        value = 25;
                    }   
                }
                else if (condition == ScrapCondition.Rusty)
                {
                    if (color == ScrapColor.Teal)
                    {
                        value = 45;
                    }
                    else if (color == ScrapColor.Brown)
                    {
                        value = 15;
                    }
                    else if (color == ScrapColor.Grey)
                    {
                        value = 25;
                    }
                    if (condition == ScrapCondition.Rusty && color == ScrapColor.Teal)
                    {
                        value = Mathf.Max(value, weight * 10);
                    } 
                }
                break;
        }
        return value;
    }
}
