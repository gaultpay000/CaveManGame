using System.Collections;
using TMPro;
using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField]PlayerMovement player;
    public bool isLaunchable = false;
    [SerializeField]bool coroutineIsRunning = false;
    [SerializeField]float timeToRun;
    

    WeaponSwitching weaponSwitching;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weaponSwitching = GetComponent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSwitching == null)
            return;
        if (weaponSwitching.weaponCurrent != 1)
            return;
        transform.position = player.clubPos.transform.position;
        
        if (Input.GetMouseButton(0) && isLaunchable)
        {
            Launch();
        }
    }

    public void Launch()
    {
        Vector3 direction = player.transform.position - transform.position;
        timeToRun = Time.time;
        player.rb.linearDamping = 1;
        //player.isMovingUp = true;

        if (!coroutineIsRunning)
        {
            player.isMovingUp = true;
            StartCoroutine(ClubSmoother(timeToRun, direction));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isLaunchable = false;
    }
    void OnTriggerEnter(Collider other)
    {
        isLaunchable = true;
    }

    IEnumerator ClubSmoother(float timer, Vector3 direction)
    {
        coroutineIsRunning = true;
        while (timer > Time.time - 1)
        {
            player.rb.AddForce(direction * 10, ForceMode.Impulse);
            yield return new WaitForSeconds(.1f);
        }
        coroutineIsRunning = false;
        StopCoroutine(ClubSmoother(timer, direction));

    }
}
