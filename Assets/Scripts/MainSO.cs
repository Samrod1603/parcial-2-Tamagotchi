using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainSO", menuName = "ScriptableObjects/MainSO", order = 1)]
public class MainSO : ScriptableObject //evento
{
    public int value = 0;

    public event UnityAction<int> OnValueChanged; 

    public void OnValueChange() //input 
    {
        Debug.Log(value); 
        value += 15;
        if (value >= 100)
        {
            value = 100;
        }
        Debug.Log(value + " nuevo"); 
        OnValueChanged?.Invoke(value); 
    }


}
