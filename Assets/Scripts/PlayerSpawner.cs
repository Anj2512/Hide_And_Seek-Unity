using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject HiderPrefab;
    public GameObject SeekerPrefab;
    public GameObject PlayerPrefab;

    private bool hasSpawned = false;

    GameObject ActualPlayer;

    public void PlayerJoined(PlayerRef player)
    {
 
        if (hasSpawned) return;
        hasSpawned = true;

        int count = player.AsIndex;

        if (count == 1)
        {
            ActualPlayer = HiderPrefab;
        }
        else if (count == 2)
        {
            ActualPlayer = SeekerPrefab;
        }
        else
        {
            ActualPlayer = PlayerPrefab;
        //    print("AHHHHHHHH");
        }

        NetworkObject spawnedObj = Runner.Spawn(ActualPlayer, new Vector3(0f, 7f, -7f), Quaternion.identity, player);

    }
}
