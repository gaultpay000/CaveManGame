using System.Collections;
using TMPro;
using UnityEngine;

public class AmbushBehavior : MonoBehaviour
{
    private bool _ambushHasTriggered = false;
    [SerializeField] private GameObject[] _ambushers;
    [SerializeField] private TMP_Text _antagSpeech;

    private void Start()
    {
        for (int i = 0; i < _ambushers.Length; i++)
        {
            _ambushers[i].SetActive(false);
            _antagSpeech.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!_ambushHasTriggered)
        {
            Debug.Log("ambush commenced");
            _ambushHasTriggered = true;
            AmbushTriggered();
        }
        return;
    }

    private void AmbushTriggered()
    {
        for (int i = 0; i < _ambushers.Length; i++)
        {
            _ambushers[i].SetActive(_ambushHasTriggered);
            StartCoroutine(TextDisplayCoro());
        }
    }

    private IEnumerator TextDisplayCoro()
    {
        _antagSpeech.enabled = true;
        yield return new WaitForSeconds(5f);
        _antagSpeech.enabled = false;
    }
}
