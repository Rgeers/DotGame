using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropMovement : MonoBehaviour {
    public float BPM;
	private void Start () {
        InvokeRepeating("Move", 0, 0.1f*(60 / BPM));
        Destroy(gameObject, (125 / BPM));
	}
    private void Move() {
        transform.position -= new Vector3(0, 0.7f, 0);
    }
}
