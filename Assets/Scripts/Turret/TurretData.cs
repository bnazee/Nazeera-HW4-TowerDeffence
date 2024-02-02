using UnityEngine;

public enum TurretType
    {
        Simple,
        Laser,
        Freeze
    }

[CreateAssetMenu(fileName = "Turret", menuName = "Turrets/TurretData")]
public class TurretData : ScriptableObject
{
    public GameObject Prefab;
    public TurretType Type;
    public float Cost;
    public float FireRange;
    public float RotationSpeed;
    public float Damage;
    public float FireRate;
    public float ShootForce;
    public GameObject Bullet;
}