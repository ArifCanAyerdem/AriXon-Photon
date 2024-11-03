using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

public float walkSpeed = 8f;
public float sprintSpeed =16f;
public float maxVelocityChange = 10f;

private Vector2 input;
private Rigidbody rb;
private bool sprinting;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        input.Normalize();
        sprinting= Input.GetButton("Sprint");
    }


    void FixedUpdate()
    {
        if  (input.magnitude>0.5f)
        {  rb.AddForce(CalculateMovement(sprinting ? sprintSpeed : walkSpeed),ForceMode.VelocityChange);
        
        }
      else{
         var velocity1 = rb.velocity;
      velocity1=new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime,velocity1.y,velocity1.z * 0.2f * Time.fixedDeltaTime);
      rb.velocity=velocity1;
      }
    }


Vector3 CalculateMovement(float _speed)
{

    Vector3 targetVelocity = new Vector3(input.x, 0, input.y) ;
    targetVelocity = transform.TransformDirection(targetVelocity);

    targetVelocity *= _speed;

    Vector3  velocity = rb.velocity;


    if  (input.magnitude>0.5f)
    {
Vector3 velocityChange = (targetVelocity - velocity);
velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);

velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

velocityChange.y = 0;

return(velocityChange);

    }else{


        return new Vector3();
    }
}


}
