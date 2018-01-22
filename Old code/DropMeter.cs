using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMeter : MonoBehaviour {
    public GameObject sizeFinder;
    private float size;
	void Start () {
	}
	
	void Update () {
        size = (0.2f* sizeFinder.GetComponent<DropCharger>().dropCharge);
        transform.localScale = new Vector3(.5f,1,size);
	}
}
