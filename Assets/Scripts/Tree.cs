using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    
    public void dealDamage(int amount)
    {
        health -= amount;
    }

    public int getHealth()
    {
        return health;
    }
}
