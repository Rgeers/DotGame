using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialChanger : MonoBehaviour {
    public KeyCode changeAnim;
    public float BPM, cooldown;
    public Texture[] textureList = new Texture[15];
    public GameObject[] animationList = new GameObject[6];
    public int currentAnimation, currentAnimationObject, maxAnims;
    private bool cooldownActive;


    private void Start() {
        cooldownActive = false;
        maxAnims -= 1;
        //fixing the index, so no array will go too far
        textureList = animationList[currentAnimationObject].GetComponent<AnimationTemplate>().textureList;
        currentAnimation = 0;
        currentAnimationObject = 0;
        InvokeRepeating("PlayAnimation", 0, (.25f*(60 / BPM)));
    }

    private void Update() {
        if (Input.GetKeyDown(changeAnim) && cooldownActive == false) {
                cooldownActive = true;
                ChangeAnimation();
                StartCoroutine("CooldownKiller");
        }
    }

    public void ChangeAnimation() {
        if (currentAnimationObject < maxAnims) {
            currentAnimationObject++;
        }
        else {
            currentAnimationObject = 0;
        }

        textureList = animationList[currentAnimationObject].GetComponent<AnimationTemplate>().textureList;
    }

    private void PlayAnimation() {
        if (currentAnimation < textureList.Length-1) {
            currentAnimation++;
        } else {
            currentAnimation = 0;
        }
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", textureList[currentAnimation]);
    }

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(cooldown);
        cooldownActive = false;
    }

    
}
