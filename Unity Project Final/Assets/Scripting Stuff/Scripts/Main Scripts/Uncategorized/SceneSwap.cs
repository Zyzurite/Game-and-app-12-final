using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwap : MonoBehaviour
{
    private PlayerCombat player;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if(controller != null)
            {
                player.resetCamera = true;
                player.gameObject.GetComponent<GameManage>().Sceneswap();
                
            }
        }
    }

}
