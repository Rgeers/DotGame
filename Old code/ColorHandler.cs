using UnityEngine;
using System.Collections;

public class ColorHandler : MonoBehaviour {
    public Color One, Two, Three;
    public KeyCode KeyOne, KeyTwo, KeyThree;
    public float cooldown;
    private Renderer rend;
    private bool cooldownActive = false;
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", One);
	}
	
	void Update () {
        if (!cooldownActive) {
            if (Input.GetKeyDown(KeyOne)) {
                rend.material.SetColor("_Color", One);
                cooldownActive = true;
                StartCoroutine("CooldownKiller");
            }
            if (Input.GetKeyDown(KeyTwo)) {
                rend.material.SetColor("_Color", Two);
                cooldownActive = true;
                StartCoroutine("CooldownKiller");
            }
            if (Input.GetKeyDown(KeyThree)) {
                rend.material.SetColor("_Color", Three);
                cooldownActive = true;
                StartCoroutine("CooldownKiller");
            }
        }
	}

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(cooldown);
        cooldownActive = false;
    }
}
