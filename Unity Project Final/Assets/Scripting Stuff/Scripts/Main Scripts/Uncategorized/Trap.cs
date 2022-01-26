using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public bool laser;
    public float timer = 3;
    public float damage = 10;
    private MeshRenderer mesh;
    private CapsuleCollider coll;
    private DataMemory player;
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        coll = gameObject.GetComponent<CapsuleCollider>();
        if (laser)
        {
            StartCoroutine("OnandOff");
        }
        if(GameObject.FindGameObjectWithTag("Player") != null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<DataMemory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnandOff()
    {
        mesh.enabled = true;
        coll.enabled = true;
        yield return new WaitForSeconds(Random.Range(1, timer));
        mesh.enabled = false;
        coll.enabled = false;
        yield return new WaitForSeconds(Random.Range(1, timer));
        StartCoroutine("OnandOff");
    }

        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if(controller != null)
            {
                Damager(damage);
                print("You triggered a trap.. it hurts");
            }
        }
    }

    void Damager(float damage)
    {
        player.health -= damage;
    }
}
