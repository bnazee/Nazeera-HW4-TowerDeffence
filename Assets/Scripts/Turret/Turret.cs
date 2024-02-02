using System;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] protected Transform _shellOut;
    [SerializeField] protected Transform _pylon;
    [SerializeField] protected Transform _target;
    
    protected TurretData _turretData;
    protected float _lastShoot;

    public TurretData TurretData => _turretData;

    protected virtual void Update()
    {
        FindClosestTarget();

        if (_target == null) return;

        if (Time.time >= _lastShoot + _turretData.FireRate)
        {
            Shoot();
            _lastShoot = Time.time;
        }

    }

    protected void FindClosestTarget()
    {
        if (EnemyManager.Instance == null) return;

        if (_target)
        {
            if (!_target.gameObject.activeSelf)
            {
                _target = null;
            }
        }

        foreach (var enemy in EnemyManager.Instance.EnemyList)
        {
            if (!_target)
            {
                if (enemy.gameObject.activeSelf)
                {
                    var dis = (enemy.transform.position - transform.position).magnitude;

                    if (dis <= _turretData.FireRange)
                    {
                        _target = enemy.transform;
                    }
                }
            }
        }

        if (!_target)
        {
            return;
        }

        RotateToTarget(_target);
    }

    protected void RotateToTarget(Transform target)
    {
        Vector3 dir = (target.position - _pylon.position).normalized;
        dir.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        _pylon.rotation = Quaternion.Lerp(_pylon.rotation, lookRotation, Time.deltaTime * _turretData.RotationSpeed);
    }

    protected abstract void Shoot();

    public void Configure(TurretData data)
    {
        _turretData = data;
    }
}
