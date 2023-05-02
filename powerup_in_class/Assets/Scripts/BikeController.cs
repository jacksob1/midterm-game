using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour, IBikeElement
{
    private List<IBikeElement> _bikeElements = new List<IBikeElement>();

    public void Accept(IVisitor visitor)
    {
        foreach (IBikeElement element in _bikeElements) {
            element.Accept(visitor);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _bikeElements.Add(gameObject.AddComponent<BikeShield>());
        _bikeElements.Add(gameObject.AddComponent<BikeEngine>());
        _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
    }
}
