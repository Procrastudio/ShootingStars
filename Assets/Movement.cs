using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
      public Rigidbody2D rb;
      public Camera cam;
      public Vector2 mousePos;
      public GameObject gun;
      public Animator anim;


      public float runSpeed = 20.0f;
      private Vector2 direction;
      void Start()
      {
          rb = GetComponent<Rigidbody2D>();
      }

      void Update()
      {
          direction.x = Input.GetAxisRaw("Horizontal");
          direction.y = Input.GetAxisRaw("Vertical");

          mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
      }

      private void FixedUpdate()
      {
          rb.MovePosition(rb.position + direction * runSpeed * Time.fixedDeltaTime);
          Vector2 lookDir = mousePos - rb.position;
          float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
          gun.transform.eulerAngles = new Vector3(0, 0, angle);

          if(angle < -90 || angle > 90)
          {
              gun.GetComponent<SpriteRenderer>().flipY = true;
          }
          else
          {
              gun.GetComponent<SpriteRenderer>().flipY = false;
          }
          if(direction.x <= 0.5f && direction.x >= -0.5f)
          {
            anim.SetBool("isRunning", false);
          }
          else
          {
            anim.SetBool("isRunning", true);
          }
          if(direction.x < 0 )
          {
            this.transform.eulerAngles = new Vector3(0,180,0);
          }
          if(direction.x > 0  )
          {
            this.transform.eulerAngles = new Vector3(0,0,0);
          }
      }
}
