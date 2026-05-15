using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PauseMenuUI pause;

    public void InstantiatePlayer()
    {
        GameData2 data = SaveLoadBase.Load("Example");

        if(data.SCENE != SceneManager.GetActiveScene().buildIndex /*&& SceneManager.GetActiveScene().buildIndex != 0*/)
        {
            SceneManager.LoadScene(data.SCENE);
            GameObject currentPlayer = FindAnyObjectByType<PlayerMovement>().gameObject;

            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            player = Instantiate(player, data.GetGUIDObjects[0].GetPosition, Quaternion.Euler(data.GetGUIDObjects[0].GetRotation));
            pause.Resume();
        }
        else if(data.SCENE == 0)
        {
            Debug.Log("no scene");
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                GameObject currentPlayer = FindAnyObjectByType<PlayerMovement>().gameObject;
                Destroy(currentPlayer);
            }
            player = Instantiate(player, data.GetGUIDObjects[0].GetPosition, Quaternion.Euler(data.GetGUIDObjects[0].GetRotation));
            pause.Resume();
        }
    }
}
