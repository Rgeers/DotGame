using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropHandler : MonoBehaviour {
    public float BPM;
    public GameObject[] locations = new GameObject[5];
    public GameObject rainDrop;
    public KeyCode HitIt;
    private int newLocation;
	void Start () {
        InvokeRepeating("RandomizeDrop", 0, (60 / BPM));

        }

    private void Update() {
        if (Input.GetKeyDown(HitIt)) {
            Instantiate(rainDrop, locations[newLocation].transform.position, locations[newLocation].transform.rotation);
        };
    }

    private void RandomizeDrop() {
        for (int i = 0; i < locations.Length; i++) {
            locations[i].SetActive(false);
        }
        newLocation = Random.Range(0, 4);
        locations[newLocation].SetActive(true);
    }
}
