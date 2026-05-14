using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScreen : MonoBehaviour
{
  public void StartGame()
  {
    SceneManager.LoadScene("Grugs Village");
  }
}