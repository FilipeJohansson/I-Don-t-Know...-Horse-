using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Horse horse;
    private Text hp;

	// Use this for initialization
	void Start () {
        horse = GetComponent<Horse>();
        hp = GameObject.Find("HorseHP").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        hp.text = horse.getCurrentHp().ToString();
	}
}
