using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCharger : MonoBehaviour {
    public GameObject PlayerControls, BPMGrabber;
    public int dropCharge, dropCooldown;
    public float BPM, cooldown;
    public KeyCode myControls;
    public bool dropCharged;
    private bool pressCooldown, allowedToUseCharges, returnDropCharge;

	private void Start () {
        pressCooldown = false;
        allowedToUseCharges = true;
        myControls = PlayerControls.GetComponent<RaindropHandler>().HitIt;
        BPM = BPMGrabber.GetComponent<MaterialChanger>().BPM;
	}

    private void Update() {
        if (returnDropCharge == true) {
            dropCharge -= 2;
        }
        if (returnDropCharge == true && dropCharge <= 0) {
            returnDropCharge = false;
            dropCharge = 0;
        }
        if (dropCharge >= 95) {
            dropCharged = true;
        }
        if (!dropCharged && allowedToUseCharges == true) {
            if (pressCooldown == false) {
                if (Input.GetKeyDown(myControls)) {
                    dropCharge += 2;
                    pressCooldown = true;
                    StartCoroutine("CooldownKiller");
                }
            }
        }
    }

    public void DropUsed() {
        dropCharged = false;
        allowedToUseCharges = false;
        StartCoroutine("DropCooldown");
        returnDropCharge = true;
    }

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(cooldown);
        pressCooldown = false;
    }
    
    private IEnumerator DropCooldown() {
        yield return new WaitForSeconds(dropCooldown);
        allowedToUseCharges = true;
    }
}
