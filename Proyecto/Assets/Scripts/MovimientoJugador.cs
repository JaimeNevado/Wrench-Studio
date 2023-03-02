using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

   public float velocidad, moveX, moveY, lastMoveX;
   public int direction;
   private Vector2 moveImput;
   private Rigidbody2D rigidbody;
   private Animator playerAnimator;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        direction = 1;
        lastMoveX = 0;
    }

    private void Update()
    {
        //Movimiento
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveImput = new Vector2(moveX, moveY).normalized;
        
        //Dirección
        if(moveX != 0) {
            lastMoveX = moveX;
        }
        else { 
            if(lastMoveX >= 0) {
                direction=1;
            } 
            else {
                direction=-1;
            } 
        }

        //Animacion del Movimiento
        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Velocidad", moveImput.sqrMagnitude);
        playerAnimator.SetInteger("Direccion", direction);

    }

    private void FixedUpdate()
    {
       rigidbody.MovePosition(rigidbody.position + moveImput * velocidad * Time.fixedDeltaTime);
    }


}
