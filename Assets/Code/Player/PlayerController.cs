using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IReactToHit
{
    public int Health { get; private set; }
    private int _maxHealth;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = Mathf.Abs(value);
        }
    }

    public PlayerController()
    {
        Health = 100;
        MaxHealth = 100;
    }

    public void ReactToHit(int hitCount)
    {
        Health = Mathf.Clamp(Health - 
            Mathf.Abs(hitCount), 0, MaxHealth);
    }

    

    void Update()
    {
        
    }
}
