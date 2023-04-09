using UnityEngine;

public class DropFloat : MonoBehaviour{
    public float frequency = 1;
    public float amplitude = 0.125f;

    private Vector3 initialPosition;

    void Start(){
        initialPosition = transform.position;
    }

    void Update(){
        Vector3 newPosition = initialPosition;
        newPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = newPosition;
    }
}
