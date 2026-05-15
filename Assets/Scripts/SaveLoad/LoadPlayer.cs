using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PauseMenuUI pause;

    public static LoadPlayer Instance {get; private set;}

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSave()
    {
        GameData2 data = SaveLoadBase.Load("Example");

        if(data.SCENE != SceneManager.GetActiveScene().buildIndex)
        {
            StartCoroutine(NewSceneLoad(data.SCENE, data.GetGUIDObjects[0].GetPosition));
        }
        else
        {
            GameObject player = FindAnyObjectByType<PlayerMovement>().gameObject;
            Debug.Log(player);
            player.transform.position = data.GetGUIDObjects[0].GetPosition;
        }
    }

    public void InstantiatePlayer()
    {
        
        GameData2 data = SaveLoadBase.Load("Example");

        if(data.SCENE != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(data.SCENE);
            //GameObject currentPlayer = FindAnyObjectByType<PlayerMovement>().gameObject;

            // if (currentPlayer != null)
            // {
            //     Destroy(currentPlayer);
            // }

            player = Instantiate(player, data.GetGUIDObjects[0].GetPosition, Quaternion.Euler(data.GetGUIDObjects[0].GetRotation));

            
            pause = FindAnyObjectByType<PauseMenuUI>();
            pause.Resume();
        }
        else
        {
            GameObject currentPlayer = FindAnyObjectByType<PlayerMovement>().gameObject;
            Destroy(currentPlayer);

            //player = Instantiate(player, data.GetGUIDObjects[0].GetPosition, Quaternion.Euler(data.GetGUIDObjects[0].GetRotation));

            
            pause = FindAnyObjectByType<PauseMenuUI>();
            pause.Resume();
        }
    }

    public void RepositionPlayer(Transform spawnPos)
    {
        GameObject player = FindAnyObjectByType<PlayerMovement>().gameObject;

        player.transform.position = spawnPos.position;
    }

    IEnumerator NewSceneLoad(int scene, Vector3 position)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        yield return operation;

        GameObject player = FindAnyObjectByType<PlayerMovement>().gameObject;
        player.transform.position = position;
    }
}
