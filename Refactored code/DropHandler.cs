using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHandler : MonoBehaviour {
    public GameObject Drop, playerOne, playerTwo;
    public KeyCode P1dropButton, P2dropButton;
    private bool _playerOneDrop, _playerTwoDrop, _allowedToDrop;

    private void Update() {
        _playerOneDrop = playerOne.GetComponent<DropCharger>().DropCharged;
        _playerTwoDrop = playerTwo.GetComponent<DropCharger>().DropCharged;

        if (_playerOneDrop && _playerTwoDrop) {
            ActivateDrop();
        }
    }

    private void ActivateDrop() {
        Drop.SetActive(true);
        StartCoroutine("ResetDrop");
    }

    private IEnumerator ResetDrop() {
        playerOne.GetComponent<DropCharger>().DropUsed();
        playerTwo.GetComponent<DropCharger>().DropUsed();
        yield return new WaitForSeconds(4f);
        Drop.SetActive(false);
        Drop.GetComponent<MaterialChanger>().CurrentAnimation = 0;
        Drop.GetComponent<MaterialChanger>().ChangeAnimation();
    }
}