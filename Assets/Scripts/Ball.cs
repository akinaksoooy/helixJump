using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;
          
    void Update()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
       // rb.AddForce(Vector3.up * jumpForce);
        rb.velocity = Vector3.up * jumpForce;

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 1);

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
                
        if (materialName == "Unsafe Color (Instance)")
        {
            gm.RestartGame();
        }
        else if (materialName == "Last Ring (Instance)")
        {
            gm.NextLevel();
        }
    }

}
