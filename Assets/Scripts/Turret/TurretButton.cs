using UnityEngine;
using UnityEngine.UI;

public class TurretButton : MonoBehaviour
{
    [SerializeField] private CameraController _controller;
    [SerializeField] private TurretData _turretData;

    public void Start()
    {   
        GetComponent<Button>().onClick.AddListener(PlaceTurret);
    }

    private void PlaceTurret()
    {
        
        if (_turretData != null)
        {
            if (GameMenager.Instance.PlayerMoney >= _turretData.Cost)
            {
                GameMenager.Instance.PlayerMoney -= _turretData.Cost;
                GameMenager.Instance.UpdatePlayerMoney();
                _controller.Pointer = CreateTurret(_turretData).gameObject;
            }
        }
    }


    private Turret CreateTurret(TurretData data)
        {
            switch (data.Type)
            {
                case TurretType.Simple:
                    TurretFactory<SimpleTurret> simpleTurretFactory = new TurretFactory<SimpleTurret>();
                    return simpleTurretFactory.CreateTurret(data);
                case TurretType.Laser:
                    TurretFactory<LaserTurret> laserTurretFactory = new TurretFactory<LaserTurret>();
                    return laserTurretFactory.CreateTurret(data);
                case TurretType.Freeze:
                    TurretFactory<FreezeTurret> freezeTurretFactory = new TurretFactory<FreezeTurret>();
                    return freezeTurretFactory.CreateTurret(data);    
                default:
                    return null;
            }
        }
}