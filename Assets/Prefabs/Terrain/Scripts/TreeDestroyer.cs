using UnityEngine;

public class TreeDestroyer: MonoBehaviour{
    public GameObject trunk;
    public GameObject dropItem;
    public void destroy(){
        Instantiate(trunk, transform.position, transform.rotation);
        Instantiate(dropItem, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
