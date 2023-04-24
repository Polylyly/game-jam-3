using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static Money instance;
    public int currentMoney;

    [Space]
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMoney = 0;
    }

    void Update()
    {
        moneyText.SetText("$" + currentMoney);
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
    }

    public void RemoveMoney(int moneyToRemove)
    {
        currentMoney -= moneyToRemove;
    }
}
