using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseBase : MonoBehaviour {
    
    public string name;
    public int _id, _lvl;
    private int _maxHp, _currentHp, _maxMana, _currentMana, _currentXp;

    public Movement movement;

    // Use this for initialization
    void Start () {
        movement = GetComponent<Movement>();
    }

    int calculateMaxHp(int lvl) {
        if (lvl == 1) { _maxHp = 30; }
        else if (lvl == 2) { _maxHp = 70; }
        else if (lvl == 3) { _maxHp = 150; }
        else if (lvl == 4) { _maxHp = 260; }
        else if (lvl == 5) { _maxHp = 370; }
        else if (lvl == 6) { _maxHp = 500; }
        else if (lvl == 7) { _maxHp = 1150; }

        return _maxHp;
    }

    public int getMaxHp() {
        return calculateMaxHp(_lvl);
    }

    int calculateMaxMana(int lvl, int maxHp) {
        return _maxMana = lvl * maxHp * 2;
    }

    public int getMaxMana() {
        return calculateMaxMana(_lvl, _maxHp);
    }

    int calculateLvl(int currentXp) {
        if (currentXp >= 0 && currentXp < 30) { _lvl = 1; }
        else if (currentXp >= 30 && currentXp < 100) { _lvl = 2; }
        else if (currentXp >= 100 && currentXp < 270) { _lvl = 3; }
        else if (currentXp >= 270 && currentXp < 400) { _lvl = 4; }
        else if (currentXp >= 400 && currentXp < 1000) { _lvl = 5; }
        else if (currentXp >= 1000 && currentXp < 3000) { _lvl = 6; }
        else if (currentXp >= 3000) { _lvl = 7; }

        return _lvl;
    }

    public int getLvl() {
        return calculateLvl(_currentXp);
    }

    void calculateCurrentMana() {
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift)) {
            _currentMana -= (int)Time.deltaTime + 1;
        } else {
            _currentMana += (int)Time.deltaTime + 1;
        }

        if (_currentMana >= _maxMana) {
            _currentMana = _maxMana;
        }

        if (_currentMana > 0) {
            movement.canRun = true;
        }

        if (_currentMana <= 0) {
            _currentMana = 0;
            movement.canRun = false;
        }
    }

    public void setCurrentHp(int hp) {
        _currentHp = hp;
    }

    public void setCurrentMana(int mana) {
        _currentMana = mana;
    }

    public int getCurrentHp() {
        return _currentHp;
    }

    public int getCurrentMana() {
        return _currentMana;
    }

    public int getCurrentXp() {
        return _currentXp;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            //Cliente mandando informações
            stream.SendNext(this._currentHp);
        } else {
            //Clientes recebendo a informação
            this.setCurrentHp((int)stream.ReceiveNext());
        }
    }
}
