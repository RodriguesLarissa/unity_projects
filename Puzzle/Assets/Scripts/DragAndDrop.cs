using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 posicaoOriginal;

    void Start() {
        posicaoOriginal = transform.position;
    }

    public void Drag() {
        // GameObject.Find("Image").transform.position = Input.mousePosition;
        print("Arrastando" + gameObject.name);
        gameObject.transform.position = Input.mousePosition;
    }

    public void Drop() {
        checkMatch();
    }

    public void moveBack() {
        transform.position = posicaoOriginal;
    }

    public void snap(GameObject img, GameObject lm) {
        img.transform.position = lm.transform.position;
    }

    public void checkMatch() {
        // GameObject lm1 = GameObject.Find("LM1");
        // GameObject img = GameObject.Find("Image");
        GameObject img = gameObject;
        string tag = gameObject.tag;
        GameObject lm1 = GameObject.Find("LM" + tag);
        
        float distance = Vector3.Distance(lm1.transform.position, img.transform.position);
        print("Distância" + distance);

        if (distance <= 50) 
            snap(img, lm1);
        else 
            moveBack();

    }
}
