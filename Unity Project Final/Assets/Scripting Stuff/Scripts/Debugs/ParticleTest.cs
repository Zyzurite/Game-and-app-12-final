using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{

    public ParticleSystem buff;
    public ParticleSystem debuff;
    public ParticleSystem level;
    public ParticleSystem hurt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buff()
    {
        buff.Play();
    }

    public void Debuff()
    {
        debuff.Play();
    }

    public void Level()
    {
        level.Play();
    }

    public void Hurt()
    {
        hurt.Play();
    }
}
