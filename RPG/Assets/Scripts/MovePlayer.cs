using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator anim; // armazena o controlador da animacao
    bool isWalkingFlag; // armazena o estado do parâmetro "isWalking"
    bool isRunningFlag; // armazena o estado do parâmetro "isRunning"

    PlayerControl input;

    public void Awake() {
        input = new PlayerControl();
    }

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", isWalkingFlag);
        anim.SetBool("isRunning", isRunningFlag);
    }
}
