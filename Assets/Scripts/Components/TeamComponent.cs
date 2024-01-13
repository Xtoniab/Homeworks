using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public TeamTag TeamTag => this.teamTag;

        [SerializeField] private TeamTag teamTag;
    }
}