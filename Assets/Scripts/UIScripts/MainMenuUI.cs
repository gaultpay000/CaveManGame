using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
  [SerializeField] private GameObject settingsPanel;

  private void Start()
  {
    settingsPanel.SetActive(false);
  }

  public void NewGame()
  {
    SceneManager.LoadScene("Controls");
  }

  public void LoadGame()
  {
    Debug.Log("Needs Added");
  }

  public void OpenSettings()
  {
    settingsPanel.SetActive(true);
  }

  public void CloseSettings()
  {
    settingsPanel.SetActive(false);
  }

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log("Quit Game (only works in build).");
  }
}