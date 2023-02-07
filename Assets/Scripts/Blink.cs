using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderer;
    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < Renderer.Length; i++)
            {
                for (int m = 0; m < Renderer[i].materials.Length; m++)
                {
                    Renderer[i].materials[m].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }

            yield return null;
        }
    }
}
