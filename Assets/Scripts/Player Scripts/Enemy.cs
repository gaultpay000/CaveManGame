using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool gotHit = false;

    MeshRenderer meshRenderer;
    public void BeenShot()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (gotHit == false)
        {
            StartCoroutine(DamageDelay());
        }
    } 
    IEnumerator DamageDelay()
    {
        gotHit = true;
        //sets the timer for the I frame animation 
        StartCoroutine(EyeFrameAnimation());
        yield return new WaitForSeconds(2f);
        gotHit = false;
    }
    //I always look a the first letter of the method to see what im looking at
    //for some reason calling it IFrameAnimation made me unable to find the method
    IEnumerator EyeFrameAnimation()
    {
        //while were in I frames turns the mesh renderer on and off to give it a pseudo blinking animation 
        while (gotHit == true)
        {
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(.1f);
        meshRenderer.enabled = true;
        yield return new WaitForSeconds(.1f);
        }
    }
}
