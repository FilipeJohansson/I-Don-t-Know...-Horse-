using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public int velocity;
    public float destroyTime;
    private int _damage;

    public HorseBase horse;
    private PhotonView photon;

	// Use this for initialization
	void Start () {
        destroyTime = 0.15f;

        photon = GetComponent<PhotonView>();
    }
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * velocity;
        Destroy(gameObject, destroyTime);
    }

    int calculateDamage(int lvl) {
        if (lvl == 1) { _damage = 10; }
        else if (lvl == 2) { _damage = 20; }
        else if (lvl == 3) { _damage = 35; }
        else if (lvl == 4) { _damage = 50; }
        else if (lvl == 5) { _damage = 70; }
        else if (lvl == 6) { _damage = 90; }
        else if (lvl == 7) { _damage = 120; }

        return _damage;
    }

    public int getDamage() {
        return calculateDamage(horse.getLvl());
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            int damageValue = getDamage();
            col.GetComponent<PhotonView>().RPC("takeDamage", PhotonTargets.All, damageValue);

            Destroy(gameObject);
        }
    }
}
