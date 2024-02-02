using UnityEngine;

    public class LaserTurret : SimpleTurret
    {
        [SerializeField] private LineRenderer _lineRenderer;

        protected override void Shoot()
        {
           
            if (Physics.Raycast(_shellOut.position, _shellOut.transform.right * 10, out RaycastHit hit))
            {
                if (hit.collider)
                {
                    var enemy = hit.collider.GetComponent<IEnemy>();

                    if (enemy != null)
                    {
                        if (Time.time > _lastShoot + TurretData.FireRate)
                        {
                            enemy.TakeDamage(TurretData.Damage);
                        }

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
