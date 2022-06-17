using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        Debug.Log("Network Player Spawned in room");
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Network Player has Left room");
        base.OnLeftRoom();
        // PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
