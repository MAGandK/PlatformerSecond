using PlayerSpasePlatformer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().TakeDamade();
        }
    }
}
