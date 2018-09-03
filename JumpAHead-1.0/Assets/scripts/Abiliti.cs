using UnityEngine;

[CreateAssetMenu()]
public class Abiliti : ScriptableObject
{
    public enum Power {Dash, Shield, Time};

    public Power power;
    public float jumpHeight;
    public float jump;
    public float speed;
    public new string name;
}