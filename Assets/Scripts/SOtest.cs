using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOtest : MonoBehaviour //suscriptor 
{
    [SerializeField] MainSO yefri;
    [SerializeField] Slider jordan; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //jordan.value = yefri.value; 
    }

    private void SliderChange(int value)
    {
        jordan.GetComponent<Slider>().value += value;
    }
    private void OnEnable()
    {
        yefri.OnValueChanged += SliderChange;
      
    }
    private void OnDisable()
    {
        yefri.OnValueChanged -= SliderChange;
    }
}
