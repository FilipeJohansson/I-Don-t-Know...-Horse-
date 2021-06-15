using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    public Text status;
    public Text opcoes;

    public Horse horse;

    // Use this for initialization
    void Start(){
        ConnectToPhoton();
    }

    // Update is called once per frame
    void Update(){
        // Input para criar sala
        if (Input.GetKeyDown(KeyCode.C)){
            PhotonNetwork.CreateRoom("sala_dos_trutao");
            status.text = "Room created";
            status.color = Color.magenta;
            opcoes.text = "Aperte 'E' para entrar na sala";
            opcoes.color = Color.green;
        }

        // Input para entrar sala
        if (Input.GetKeyDown(KeyCode.E)){
            PhotonNetwork.JoinRoom("sala_dos_trutao");
            status.text = "Entrando, aguarde...";
            status.color = Color.magenta;
            opcoes.text = "";
        }

    }

    void OnJoinedRoom(){
        GameObject player = PhotonNetwork.Instantiate("Horse", new Vector3(6, 0.16f, 6), Quaternion.identity, 0);
        status.text = "In Room 'jogao'";
        status.color = Color.yellow;
    }

    void OnJoinedLobby(){
        status.text = "In Lobby";
        status.color = Color.magenta;
        opcoes.text = "Aperte 'C' para criar uma sala";
        opcoes.color = Color.green;
    }

    void ConnectToPhoton(){
        try{
            PhotonNetwork.ConnectUsingSettings("v1.0");
            status.text = "Connected";
            status.color = Color.blue;
            opcoes.text = "Aperte 'C' para criar a sala";
            opcoes.color = Color.green;
        } catch (UnityException error){
            Debug.Log(error);
        }
    }
}
