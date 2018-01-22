using UnityEngine;
using System.Collections;

public class ColorHandler : MonoBehaviour {
    [SerializeField] private Color _one, _two, _three;
    [SerializeField] private KeyCode _keyOne, _keyTwo, _keyThree;
    [SerializeField] private float _cooldown;
    private Renderer _rend;
    private bool _cooldownActive = false;

    private void Start() {
        _rend = GetComponent<Renderer>();
        _rend.material.SetColor("_Color", _one);
    }

    private void Update() {
        if (!_cooldownActive) {
            if (Input.GetKeyDown(_keyOne)) {
                _rend.material.SetColor("_Color", _one);
            }
            if (Input.GetKeyDown(_keyTwo)) {
                _rend.material.SetColor("_Color", _two);
            }
            if (Input.GetKeyDown(_keyThree)) {
                _rend.material.SetColor("_Color", _three);
            }
            _cooldownActive = true;
        }
    }

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(_cooldown);
        _cooldownActive = false;
    }
}