using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Automat : Gun
{
    // [Space(12)]
    [Header("Automat")]
    public int NumberOfBullets;
    public TextMeshProUGUI BulletsText;
    public PlayerArmory PlayerArmory;

    public override void CreateBullet()
    {
        base.CreateBullet();
        NumberOfBullets -= 1;
        UpdateText();
        if (NumberOfBullets == 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }

    }
    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }
    public void UpdateText()
    {
        BulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }
    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}