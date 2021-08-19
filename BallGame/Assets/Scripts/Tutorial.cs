using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] ParticleSystem winEffect;
    [SerializeField] ParticleSystem loseEffect;
    [SerializeField] GameObject mobileTilt;
    [SerializeField] GameObject goToGreenBlock;
    int flag = 0;
    float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        MoveObject();

    }

     void Start()
    {
        goToGreenBlock.SetActive(false);
        StartCoroutine(GoToGreen());
    }

    IEnumerator GoToGreen()
    {
        yield return new WaitForSeconds(5);
        goToGreenBlock.SetActive(true);
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
        if (collision.gameObject.tag == "Win")
        {
            print("Next Level");
            winEffect.Play();
            SceneManager.LoadScene("Level1");
        }
        else if (collision.gameObject.tag == "Lose")
        {
            print("Game Over");
            loseEffect.Play();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
