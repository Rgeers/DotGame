using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationHandler : MonoBehaviour {
    public float BPM;
    public List<GameObject> LocationList, AnimationList, AttackList;
    public GameObject Cube, Temp1, Temp2, Temp3;
    public AudioSource Tick;
    public KeyCode playerOneControl, playerTwoControl;
    void Start() {
        playerOneControl = KeyCode.Alpha1;
        playerTwoControl = KeyCode.Alpha2;
        BPM = 120;
       InvokeRepeating("MoveAll", 0, (60/BPM));
        //Spawn all the animation parts
        for (int i = 0; i < 28; i++) {
            LocationList[i] = Instantiate(Cube, new Vector3((i * 0.5f), 0, 0), Quaternion.identity) as GameObject;
        }
        //Maak straks ff een switch van 1,2,3 zodat hij normaler spawnt
        for (int i = 0; i < 28; i++) {
                AnimationList[i] = Instantiate(Temp1, LocationList[i + 1].transform.position, LocationList[i + 1].transform.rotation) as GameObject;
                AnimationList[27 - i] = Instantiate(Temp2, LocationList[i].transform.position, LocationList[i].transform.rotation) as GameObject;
                AnimationList[27].transform.position = LocationList[0].transform.position;
            i++;
        }
        AnimationList[27].transform.position = LocationList[0].transform.position;

    }

    void Update() {
        if (Input.GetKeyDown(playerOneControl)) {
            AttackList[0] = Instantiate(Temp3, new Vector3(0.5f, 6,-1), this.transform.rotation) as GameObject;
        }
    }

    void MoveAll() {
        Tick.Play();
        for (int i = 0; i < 28; i++) {
            if (AnimationList[i].transform.position.x >= 13.5f) {
                AnimationList[i].transform.position = LocationList[0].transform.position;
            } else {
                AnimationList[i].transform.position = new Vector3(AnimationList[i].transform.position.x+0.5f, 0, 0);
                
            }
        }
    }
    void MoveAttack(GameObject currentObject) {

    }
}
