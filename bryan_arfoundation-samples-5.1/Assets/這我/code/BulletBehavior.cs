using UnityEngine;

using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string targetName = other.gameObject.name;

        if (targetName.Contains("Cube") || targetName.Contains("Fireball"))
        {
            Destroy(other.gameObject); // �P���Q���쪺����
            Destroy(gameObject);       // �P���l�u�ۤv
        }
        else
        {
            // �Y�D�ؼСA�]�i������l�u�۰ʮ���
            Destroy(gameObject);
        }
    }
}

