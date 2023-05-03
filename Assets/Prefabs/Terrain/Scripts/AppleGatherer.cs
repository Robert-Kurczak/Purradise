using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGatherer : MonoBehaviour{

    [Header("References")]
    public Sprite treeSprite;
    public Sprite noAppleTreeSprite;
    public GameObject dropItem;
    public SpriteRenderer spriteRenderer;
    [Space(5)]

    [Header("Properties")]
    public float regrowTimeMin = 300;
    public float regrowTimeMax = 600;

    private bool gathered = false;

    public event Action OnApplesRegrow;

    public bool canGather(){
        return !gathered;
    }

    public void gather(){
        spriteRenderer.sprite = noAppleTreeSprite;
        Instantiate(dropItem, transform.position, transform.rotation);

        float regrowTime = UnityEngine.Random.Range(regrowTimeMin, regrowTimeMax);
        StartCoroutine(regrowCoroutine(regrowTime));

        gathered = true;
    }

    private void regrow(){
        spriteRenderer.sprite = treeSprite;
        gathered = false;

        OnApplesRegrow?.Invoke();
    }

    private IEnumerator regrowCoroutine(float regrowTime){
        yield return new WaitForSeconds(regrowTime);

        regrow();
    }
}
