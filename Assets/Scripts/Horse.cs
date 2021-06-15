using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : HorseBase {

    private PhotonView photon;
    public PlayerCam camera;

	// Use this for initialization
	void Start () {
        photon = GetComponent<PhotonView>();

        setCurrentHp(getMaxHp());
        setCurrentMana(getMaxMana());

        if (photon.isMine) {
            camera.gameObject.SetActive(true);
            Debug.Log("CHEGOUUDUSAHUIASGFIAUGUI");
        } else {
            Debug.Log("MERDAAA");
            camera.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
