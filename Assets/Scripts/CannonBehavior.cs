using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {
    
	public Transform rigthMuzzle;
    public Transform leftMuzzle;

    private PhotonView photon;

    public float fireRate;
    private float timeToFireRight;
    private float timeToFireLeft;
    private bool canFireRight;
    private bool canFireleft;

    // Use this for initialization
    void Start () {
        fireRate = 0.23f;
        timeToFireRight = 0;
        timeToFireLeft = 0;
        canFireRight = true;
        canFireleft = true;

        photon = GetComponent<PhotonView>();
    }
	
	// Update is called once per frame
	void Update () {
        if (photon.isMine){
            if (Input.GetMouseButtonDown(0) && canFireleft) {
                GameObject fireLeft = PhotonNetwork.InstantiateSceneObject("shot_prefab", leftMuzzle.position, leftMuzzle.rotation, 0, new object[0]);
                //GameObject.Instantiate(shotPrefab, leftMuzzle.position, leftMuzzle.rotation);
                canFireleft = false;
            }

            if (Input.GetMouseButtonDown(1) && canFireRight){
                GameObject fireRight = PhotonNetwork.InstantiateSceneObject("shot_prefab", rigthMuzzle.position, rigthMuzzle.rotation, 0, new object[0]);
                //GameObject.Instantiate(shotPrefab, rigthMuzzle.position, rigthMuzzle.rotation);
                canFireRight = false;
            }

            if (!canFireleft) {
                timeToFireLeft += Time.deltaTime;
                if (timeToFireLeft > fireRate) {
                    timeToFireLeft = 0;
                    canFireleft = true;
                }
            }

            if (!canFireRight) {
                timeToFireRight += Time.deltaTime;
                if (timeToFireRight > fireRate) {
                    timeToFireRight = 0;
                    canFireRight = true;
                }
            }
        }//Fecha photon.isMine
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            //Cliente mandando informações
        }else{
            //Clientes recebendo a informação
        }
    }
}