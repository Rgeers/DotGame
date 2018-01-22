using UnityEngine;
using System.Collections;

public class AttackMovement : MonoBehaviour {
    public float BPM;
    private int lifetime = 0;

    private void Start() {
        BPM = 120;
        InvokeRepeating("Move", 0, ((60 / BPM) * 0.5f));
    }

    private void Move() {
        if (lifetime == 3) {
            Destroy(gameObject);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        lifetime++;
    }
}