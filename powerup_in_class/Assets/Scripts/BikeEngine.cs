using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeEngine : MonoBehaviour, IBikeElement
{
    public float turboBoost = 25f;
    public float maxTurboBoost = 100f;
    private bool _isTurboOn;
    private float _defaultSpeed = 300f;

    public float CurrentSpeed {
        get {
            if (_isTurboOn) return _defaultSpeed + turboBoost;
            return _defaultSpeed;
        }
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void ToggleTurbo() {
        _isTurboOn = !_isTurboOn;
    }

    void OnGUI() {
        GUI.color = Color.green;
        GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost: " + turboBoost);
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
