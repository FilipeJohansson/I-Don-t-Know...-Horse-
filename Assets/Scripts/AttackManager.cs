using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    private PhotonView photon;

	// Use this for initialization
	void Start () {
        photon = GetComponent<PhotonView>();
	}

    [PunRPC]
    public void takeDamage(int damage) {
        if (photon.isMine) {
            Horse horse = this.gameObject.GetComponent<Horse>();
            int currentHp = horse.getCurrentHp();
            horse.setCurrentHp(currentHp - damage);
        }
    }
}
