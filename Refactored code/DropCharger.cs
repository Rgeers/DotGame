using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCharger : MonoBehaviour {
    public bool DropCharged;
    public int DropCharge;
    [SerializeField] private GameObject _playerControls, _bpmGrabber;
    [SerializeField] private int _dropCooldown;
    [SerializeField] private float _bpm, _cooldown;
    [SerializeField] private KeyCode _myControls;
    private bool _pressCooldown, _allowedToUseCharges, _returnDropCharge;

    private void Start() {
        _pressCooldown = false;
        _allowedToUseCharges = true;
        _myControls = _playerControls.GetComponent<RaindropHandler>().HitIt;
        _bpm = _bpmGrabber.GetComponent<MaterialChanger>().BPM;
    }

    private void Update() {
        if (_returnDropCharge == true) {
            DropCharge -= 2;
        }
        if (_returnDropCharge == true && DropCharge <= 0) {
            _returnDropCharge = false;
            DropCharge = 0;
        }
        if (DropCharge >= 95) {
            DropCharged = true;
        }
        if (!DropCharged && _allowedToUseCharges == true) {
            if (_pressCooldown == false) {
                if (Input.GetKeyDown(_myControls)) {
                    DropCharge += 2;
                    _pressCooldown = true;
                    StartCoroutine("CooldownKiller");
                }
            }
        }
    }

    public void DropUsed() {
        DropCharged = false;
        _allowedToUseCharges = false;
        StartCoroutine("DropCooldown");
        _returnDropCharge = true;
    }

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(_cooldown);
        _pressCooldown = false;
    }

    private IEnumerator DropCooldown() {
        yield return new WaitForSeconds(_dropCooldown);
        _allowedToUseCharges = true;
    }
}