using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        dir.y = 0;
        
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        
        dir *= Time.deltaTime;

       
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
    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator RestartTutorial()
    {
        Destroy(this.gameObject, 1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Tutorial");
    }

}
