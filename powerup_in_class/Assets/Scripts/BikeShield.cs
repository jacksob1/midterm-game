using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeShield : MonoBehaviour, IBikeElement
{
    public float health = 50f;
    public float Damage(float damage) {
        health -= damage;
        return health;
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(125, 0, 200, 20), "Shield Health: " + health);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
