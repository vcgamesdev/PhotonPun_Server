using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Disable : MonoBehaviourPun
    {
        private PhotonView view;

        // Start is called before the first frame update
        void Start()
        {
            view = GetComponent<PhotonView>();

            if (view.IsMine)
            {
                gameObject.tag = "Player";
            }
            else
            {
                Destroy(this);
            }
        }
}