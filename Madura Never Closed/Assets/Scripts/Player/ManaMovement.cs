using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManaMovement : MonoBehaviour
{
    [SerializeField] private Image manaBar;
    [SerializeField] private int manaAmountMax = 100;

    private float manaAmount;

    private void Start()
    {
        manaAmount = manaAmountMax;
    }
    
    private void Update()
    {
        //Debug.Log(manaAmount);
    }

    public void DecreasePlayerMana()
    {
        manaAmount -= Time.deltaTime;
        manaBar.fillAmount = manaAmount / manaAmountMax;
    }

    public void IncreasePlayerSleepAmount(int manaSleep)
    {
        manaAmount += manaSleep;
        manaAmount = Mathf.Clamp(manaAmount, 0, manaAmountMax);
        manaBar.fillAmount = manaAmount / manaAmountMax;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Kandang Macan"))
        {
            IncreasePlayerSleepAmount(1);
        }
    }

    public float GetPlayerManaAmount()
    {
        return manaAmount;
    }
}
