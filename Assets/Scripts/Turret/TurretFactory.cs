using UnityEngine;

public class TurretFactory<T> where T : Turret
{
        public T CreateTurret(TurretData data)
        {
            GameObject instance = GameObject.Instantiate(data.Prefab, new Vector3(0, 50f, 0), Quaternion.identity);
            T turret = instance.GetComponent<T>();
            turret.Configure(data);
            return turret;
        }
    
}
