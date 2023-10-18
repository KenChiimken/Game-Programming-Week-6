using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    //Player GameObjec
    public GameObject player;
    public Rigidbody rigidBody;
    public Animator playerAnim;

    [Header("Scripts")]
    //Player Scripts
    public InputManager inputManager;
    public PlayerLocalMotion playerLocalMotion;
    public PlayerAnimation playerAnimation;

    //Player Stats
    [Header("Player Stats")]
    [Range(0, 1000)]
    public float Movementspeed;
    [Range(0, 1000)]
    public float Rotatationspeed;
    public float Sprintspeed;
    public float Walkspeed;
    [Header("Action Stats")]
    public bool isSprinting;
    public bool isWalking;
    public bool isJumping;


    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
        inputManager = player.GetComponent<InputManager>();
        playerLocalMotion = player.GetComponent<PlayerLocalMotion>();
        rigidBody = player.GetComponent<Rigidbody>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
        playerAnim = player.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInput();
    }
    private void FixedUpdate()
    {
        playerLocalMotion.HandleAllMovement();
    }

}
}
