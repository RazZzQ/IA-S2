using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int healthMax;

    public virtual void LoadComponent()
    {
        health = healthMax;
    }
}
