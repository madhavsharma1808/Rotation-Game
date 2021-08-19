using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] ParticleSystem winEffect;
    [SerializeField] ParticleSystem loseEffect;
    float speed = 5f;
   
    // Update is called once per frame
    void Update()
    {
        MoveObject();
        
    }

    void MoveObject()
    {
        Vector3 dir = Vector3.zero;

        dir.x = -Input.acceleration.x;
        dir.z = -Input.acceleration.y;

        // clamp acceleration vector to unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag=="Win")
        {
            print("Next Level");
            winEffect.Play();
        }
       else if(collision.gameObject.tag=="Lose")
        {
            print("Game Over");
            loseEffect.Play();
        }
    }

}
