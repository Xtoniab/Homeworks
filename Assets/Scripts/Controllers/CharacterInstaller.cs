using Objects;
using Sirenix.Utilities;
using Systems;
using UnityEngine;

namespace Controllers
{
    public class CharacterInstaller: MonoBehaviour
    {
        [SerializeField] private Character[] characters;
        [SerializeField] private BulletSystem bulletSystem;

        private void Awake()
        {
            characters.ForEach(x => x.Construct(bulletSystem));
        }
    }
}