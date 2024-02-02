using UnityEngine;


public class SimpleTurret : Turret
{
    protected override void Shoot()
    {
        GameObject bullet = null;
        bullet = Instantiate(_turretData.Bullet, _shellOut.transform.position, Quaternion.identity);
        var bul = bullet.GetComponent<Bullet>();
        bul.Init(_turretData.Damage);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(_shellOut.transform.right * _turretData.ShootForce, ForceMode.Impulse);

        Destroy(bullet, 0.5f);
    }
}
