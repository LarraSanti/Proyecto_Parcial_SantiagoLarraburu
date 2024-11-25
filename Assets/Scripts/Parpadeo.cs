using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LightningFlash : MonoBehaviour
{
    public Image pantallaBlanca; 
    public float duracionFlash = 0.1f; 

    public void IniciarParpadeo(float tiempoTotal)
    {
        StartCoroutine(ParpadeoEstiloRelampago(tiempoTotal));
    }

    IEnumerator ParpadeoEstiloRelampago(float tiempo)
    {
        float final = Time.time + tiempo;
        while (Time.time < final)
        {
            
            pantallaBlanca.enabled = true;

            
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));

           
            pantallaBlanca.enabled = false;


            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        }

       
        pantallaBlanca.enabled = false;
    }
}
