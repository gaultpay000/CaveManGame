using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
  [SerializeField] private GameObject pausePanel;
  [SerializeField] private GameObject settingsPanel;
  [SerializeField] private MonoBehaviour playerLook;
  [SerializeField] LoadPlayer load;

  private bool isPaused = false;

  private void Start()
  {
    pausePanel.SetActive(false);
    settingsPanel.SetActive(false);
    Time.timeScale = 1f;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (isPaused)
        Resume();
      else
        Pause();
    }
  }

  public void Pause()
  {
    pausePanel.SetActive(true);
    settingsPanel.SetActive(false);

    Time.timeScale = 0f;
    isPaused = true;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    if (playerLook != null)
      playerLook.enabled = false;
  }

  public void Resume()
  {
    pausePanel.SetActive(false);
    settingsPanel.SetActive(false);

    Time.timeScale = 1f;
    isPaused = false;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    if (playerLook != null)
      playerLook.enabled = true;
  }

  public void OpenSettings()
  {
    settingsPanel.SetActive(true);
  }

  public void CloseSettings()
  {
    settingsPanel.SetActive(false);
  }

  public void LoadGame()
  {
    load.InstantiatePlayer();
  }

  public void BackToMainMenu()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene("Main Menu");
  }

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log("Quit Game");
  }
}