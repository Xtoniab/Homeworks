using UnityEngine;

namespace ShootEmUp
{
    public class CharacterInstaller: MonoBehaviour
    {
        [SerializeField] private ShipComponent shipComponent;
        [SerializeField] private BulletSystem bulletSystem;
        
        private void Awake()
        {
            shipComponent.Construct(bulletSystem);
        }
    }
}