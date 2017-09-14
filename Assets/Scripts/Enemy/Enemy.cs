using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public int health;
    public int energy;

    public abstract void takeDamage(int dmg);

}
