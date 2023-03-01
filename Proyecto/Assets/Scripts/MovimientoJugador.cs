using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

   public float velocidad;
   private Vector2 moveImput;
   private Rigidbody2D rigidbody;
   private Animator playerAnimator;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveImput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Velocidad", moveImput.sqrMagnitude);

    }

    private void FixedUpdate()
    {
       rigidbody.MovePosition(rigidbody.position + moveImput * velocidad * Time.fixedDeltaTime);

    }
}
