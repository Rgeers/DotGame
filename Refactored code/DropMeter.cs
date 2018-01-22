using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMeter : MonoBehaviour {
    private GameObject _sizeFinder;
    private float _size;

    private void Update() {
        _size = (0.2f * _sizeFinder.GetComponent<DropCharger>().DropCharge);
        transform.localScale = new Vector3(.5f, 1, _size);
    }
}