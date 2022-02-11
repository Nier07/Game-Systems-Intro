using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script can be found in the Component section under RPG Game/Character/Movement
[AddComponentMenu("RPG Game/Character/Movement")]
//This script requires the component Character cotroller to be attacted to the Game Object
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    [Tooltip("use this to apply movement in worldspace")]
    public Vector3 moveDirection; //Used to apply movement in worldspace
    public CharacterController charC; //A reference to varable in character controller
    [Header("Speeds")] // header creates a header fot the variable directly underneath
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f, gravity = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //asign component to our reference
        charC = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (charC.isGrounded)
        {
            //set MoveDirection to the input direction
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //allows us to move the player were the player is facing
            moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection is multiplied by speed
            moveDirection *= moveSpeed;
            //if the input for jump is pressed then
            if (Input.GetButton("Jump"))
            {
                //the moveDirection.y = jump speed
                moveDirection.y = jumpSpeed;
            }

        }

        //since gravity is positive we subtract to go down gravity is always effecting the object (moveDirection)
        moveDirection.y -= gravity;
        //tell the character controller to move in a direction
        charC.Move(moveDirection * Time.deltaTime);
    }
}
