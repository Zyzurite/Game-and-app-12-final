using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public bool potion;
    public bool debuff;
    public bool buff;
    public bool bomb;
    private PlayerCombat player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerCombat>();
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                if (potion)
                {
                    player.potions += 1;
                    print("Potion picked up");
                }
                if (debuff)
                {
                    player.xDebuff += 1;
                    print("xDebuff picked up");
                }
                if (buff)
                {
                    player.xBuff += 1;
                    print("xBuff picked up");
                }
                if (bomb)
                {
                    player.smokeBomb += 1;
                    print("Smokebomb picked up");
                }
                else
                    print("Missing item bool");

                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
