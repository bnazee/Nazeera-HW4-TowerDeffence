using UnityEngine;

public class FreezeTurret : Turret
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _slowRate;

    protected override void Shoot()
        {
            if (Physics.Raycast(_shellOut.position, _shellOut.transform.right * _turretData.FireRange, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    var enemy = hit.collider.GetComponent<IEnemy>();

                    if (enemy != null)
                    {                    
                        enemy.TakeDamage(TurretData.Damage);   
                        enemy.SlowDown(_slowRate);      

                        _lineRenderer.SetPosition(0, _shellOut.position);
                        _lineRenderer.SetPosition(1, hit.point);
                    }

                    if (!hit.collider.gameObject.activeSelf)
                    {
                        _lineRenderer.SetPosition(0, Vector3.zero);
                        _lineRenderer.SetPosition(1, Vector3.zero);
                    }
                }
            }

            if (!_target)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }
}


