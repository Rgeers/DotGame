using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialChanger : MonoBehaviour {
    [SerializeField] private KeyCode _changeAnim;
    [SerializeField] private float _bpm, _cooldown;
    public Texture[] TextureList = new Texture[15];
    public GameObject[] AnimationList = new GameObject[6];
    public int CurrentAnimation, CurrentAnimationObject, MaxAnims;
    private bool _cooldownActive;


    private void Start() {
        _cooldownActive = false;
        MaxAnims -= 1;
        TextureList = AnimationList[CurrentAnimationObject].GetComponent<AnimationTemplate>().textureList;
        CurrentAnimation = 0;
        CurrentAnimationObject = 0;
        InvokeRepeating("PlayAnimation", 0, (.25f * (60 / _bpm)));
    }

    private void Update() {
        if (Input.GetKeyDown(_changeAnim) && _cooldownActive == false) {
            _cooldownActive = true;
            ChangeAnimation();
            StartCoroutine("CooldownKiller");
        }
    }

    public void ChangeAnimation() {
        if (CurrentAnimationObject < MaxAnims) CurrentAnimationObject++;
        else CurrentAnimationObject = 0;

        TextureList = AnimationList[CurrentAnimationObject].GetComponent<AnimationTemplate>().textureList;
    }

    private void PlayAnimation() {
        if (CurrentAnimation < TextureList.Length - 1) CurrentAnimation++;
        CurrentAnimation = 0;
        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", TextureList[CurrentAnimation]);
    }

    private IEnumerator CooldownKiller() {
        yield return new WaitForSeconds(_cooldown);
        _cooldownActive = false;
    }
}