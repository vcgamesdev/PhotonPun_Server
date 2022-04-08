using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PLayerPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(PLayerPrefab.name, new Vector3(Random.Range(-5f, 5f), 0, -5), Quaternion.identity);

        //Set Cursor to not be visible
        Cursor.visible = false;
    }

}
