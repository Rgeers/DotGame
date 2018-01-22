using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHandler : MonoBehaviour {
    public GameObject Drop, playerOne, playerTwo;
    public KeyCode P1dropButton, P2dropButton;
    private bool playerOneDrop, playerTwoDrop, allowedToDrop;

	private void Update () {
        playerOneDrop = playerOne.GetComponent<DropCharger>().dropCharged;
        playerTwoDrop = playerTwo.GetComponent<DropCharger>().dropCharged;

        if (playerOneDrop && playerTwoDrop) {
            ActivateDrop();
        }
	}
    private void ActivateDrop() {
        Drop.SetActive(true);
        StartCoroutine("ResetDrop");
    }

    IEnumerator ResetDrop() {
        playerOne.GetComponent<DropCharger>().DropUsed();
        playerTwo.GetComponent<DropCharger>().DropUsed();
        yield return new WaitForSeconds(4f);
        Drop.SetActive(false);
        Drop.GetComponent<MaterialChanger>().currentAnimation = 0;
        Drop.GetComponent<MaterialChanger>().ChangeAnimation();
    }
}
