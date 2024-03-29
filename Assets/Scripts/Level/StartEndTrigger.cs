using Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class StartEndTrigger : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] public UnityEvent onSuccessfulEnd;
        #nullable enable
        private void OnTriggerEnter(Collider other)
        {
            var inv = other.gameObject.GetComponent<Inventory>();
            if (inv is null)
            {
                return;
            }

            foreach (var item in inv.GetItems())
            {
                if (item.type == ItemType.KeyItem)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    onSuccessfulEnd.Invoke();
                }
            }
        }
        #nullable disable


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, _collider.bounds.size);
        }
    }
}
