using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    public Image BackGround;
    public Image ForeGround;
    public TextMeshProUGUI Text;

    public void StartCharge()
    {
        BackGround.color = new Color(1f, 1f, 1f, 0.2f);
        ForeGround.enabled = true;
        Text.enabled = true;
    }
    public void StopCharge()
    {
        BackGround.color = new Color(1f, 1f, 1f, 1f);
        ForeGround.enabled = false;
        Text.enabled = false;
    }
    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        ForeGround.fillAmount = currentCharge / maxCharge;
        Text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
