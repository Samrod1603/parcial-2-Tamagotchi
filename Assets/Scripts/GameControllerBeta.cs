using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBeta : MonoBehaviour
{

    private float happiness = 100, sleep = 100, hunger = 100, max = 100;

    [SerializeField] private Slider happinessSlider, sleepSlider, hungerSlider;

    [SerializeField] private SpriteRenderer hungerNoti, sleepNoti, playNoti;

    [SerializeField] private GameObject pet, deadState, sleepState, playButton, hungerButton, sleepButton;

    private bool sleeping=false;

    // Update is called once per frame
    void Update()
    {
        //interfaz
        happiness -= 6.4f * Time.deltaTime;
        if (happiness < 0)
        {
            happiness = 0;
        }

        if (sleeping == false)
        {
            sleep -= 4f * Time.deltaTime;
            if (sleep < 0)
            {
                sleep = 0;
            }
        }

        hunger -= 5.5f * Time.deltaTime;
        if (hunger < 0)
        {
            hunger = 0;
        }
        
        //Observer

        if (hunger <= 50)
        {
            if (hunger <= 10)
            {
                hungerNoti.color = Color.red;
            }
            else
            {
                hungerNoti.color = Color.white;
            }
        }
        else
        {
            hungerNoti.color = new Color(1, 1, 1, 0);
        }

        if (sleep <= 50)
        {
            if (sleep <= 10)
            {
                sleepNoti.color = Color.red;
            }
            else
            {
                sleepNoti.color = Color.white;
            }
        }
        else
        {
            sleepNoti.color = new Color(1, 1, 1, 0);
        }

        if (happiness <= 50)
        {
            if (happiness <= 10)
            {
                playNoti.color = Color.red;
            }
            else
            {
                playNoti.color = Color.white;
            }
        }
        else
        {
            playNoti.color = new Color(1, 1, 1, 0);
        }
        
        //Estado

        if (hunger <= 0 && happiness <= 0 && sleep <= 0)
        {
            pet.transform.rotation = Quaternion.Euler(0, 0, -90);
            deadState.SetActive(true);
            hungerButton.SetActive(false);
            playButton.SetActive(false);
            sleepButton.SetActive(false);
        }

        UpdateHappinessBar();
        UpdateHungerBar();
        UpdateSleepBar();
    }

    private void UpdateHungerBar()
    {
        float ratio = hunger / max;
        hungerSlider.value = ratio;
    }

    private void UpdateHappinessBar()
    {
        float ratio = happiness / max;
        happinessSlider.value = ratio;
    }

    private void UpdateSleepBar()
    {
        float ratio = sleep / max;
        sleepSlider.value = ratio;
    }

    public void Feed()
    {
        hunger += 15;
        if (hunger >= max)
        {
            hunger = 100;
        }
    }

    public void Play()
    {
        happiness += 6;
        if (happiness >= max)
        {
            happiness = 100;
        }
    }

    public void Sleep()
    {

        StartCoroutine(SleepStateCorutine());
    }

    IEnumerator SleepStateCorutine()
    {
        sleeping = true;
        hungerButton.SetActive(false);
        playButton.SetActive(false);
        sleepButton.SetActive(false);
        
        sleepState.SetActive(true);
        
        for (int i = (int)sleep; i < sleep + 20; i++)
        {
            
            sleep += 0.5f;
            if (sleep >= max)
            {
                sleep = 100;
                break;
            }

            yield return new WaitForSeconds(0.01f);
        }
        
        hungerButton.SetActive(true);
        playButton.SetActive(true);
        sleepButton.SetActive(true);
        sleepState.SetActive(false);
        sleeping = false;

    }
}
