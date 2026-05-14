using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    public void InstantiatePlayer()
    {
        GameData2 data = SaveLoadBase.Load("Example");

        player = Instantiate(player, data.GetGUIDObjects[0].GetPosition, Quaternion.Euler(data.GetGUIDObjects[0].GetRotation));
    }
}
