using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public float movementVelocity;
    public float runVelocity;
    public float rotationVelocity;

    public bool canRun;

    private PhotonView photon;

    private Animator animator;

    // Use this for initialization
    void Start(){
        movementVelocity = 5f;
        runVelocity = 10f;
        rotationVelocity = 60f;
        canRun = true;

        animator = GetComponent<Animator>();
        photon = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update(){
        if (photon.isMine){
            if (Input.GetKey("w")){
                transform.Translate(0, 0, movementVelocity * Time.deltaTime);
            }

            if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift) && canRun){
                transform.Translate(0, 0, runVelocity * Time.deltaTime);
                animator.SetBool("isRun", true);
            }else{
                animator.SetBool("isRun", false);
            }

            if (Input.GetKey("s")){
                transform.Translate(0, 0, -movementVelocity * Time.deltaTime);
            }

            if (Input.GetKey("a")){
                transform.Rotate(0, -rotationVelocity * Time.deltaTime, 0);
            }

            if (Input.GetKey("d")){
                transform.Rotate(0, rotationVelocity * Time.deltaTime, 0);
            }

            if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a")){
                animator.SetBool("isWalking", true);
            }else{
                animator.SetBool("isWalking", false);
            }

        }//Fecha photon.isMine
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            //Cliente mandando informações
            stream.SendNext(animator.GetBool("isWalking"));
            stream.SendNext(animator.GetBool("isRun"));
        }else{
            //Clientes recebendo a informação
            animator.SetBool("isWalking", (bool)stream.ReceiveNext());
            animator.SetBool("isRun", (bool)stream.ReceiveNext());
        }
    }
}