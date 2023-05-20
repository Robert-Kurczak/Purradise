using UnityEngine;

public class DropFloat : MonoBehaviour{
    public float frequency = 1;
    public float amplitude = 0.125f;

	private float previousOffset = 0;
    void FixedUpdate(){
		float offset = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position += new Vector3(
            0,
            offset - previousOffset,
            0
        );

		previousOffset = offset;
    }
}
