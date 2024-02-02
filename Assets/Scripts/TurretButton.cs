using UnityEngine;
using UnityEngine.UI;

public class TurretButton : MonoBehaviour
{
    [SerializeField] private CameraController _controller;
    [SerializeField] private SimpleTurret _turret;

    public void Start()
    {   
        GetComponent<Button>().onClick.AddListener(PlaceTurret);
    }

    private void PlaceTurret()
    {
        if (_turret != null)
        {
            if (GameMenager.Instance.PlayerMoney >= _turret.TurretData.Cost)
            {
                GameMenager.Instance.PlayerMoney -= _turret.TurretData.Cost;
                GameMenager.Instance.UpdatePlayerMoney();
                _controller.Pointer = Instantiate(_turret).gameObject;
                _controller.Pointer.transform.position = new Vector3(0, 50, 0);
            }
        }
    }
}