using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFactory<T> where T : Turret
{

        public T CreateTurret(TurretData data)
        {
            GameObject instance = GameObject.Instantiate(data.Prefab);
            T turret = instance.GetComponent<T>();
            return turret;
        }
    
}
