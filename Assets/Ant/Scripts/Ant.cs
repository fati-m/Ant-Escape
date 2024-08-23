using UnityEngine;

public class Ant : MonoBehaviour {
    Animator ant;
    public GameObject mesh;
    public Material[] materials;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    void Start () {
        ant = GetComponent<Animator>();
    }
    
    void Update () {
        float moveDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * moveDirection);
        transform.Rotate(Vector3.up * rotation);

        bool isMoving = Mathf.Abs(moveDirection) > 0 || Mathf.Abs(rotation) > 0;

        if (isMoving)
        {
            ant.SetBool("walk", true);
            ant.SetBool("idle", false);
            ant.SetBool("run", false);
        }
        else
        {
            ant.SetBool("walk", false);
            ant.SetBool("idle", true);
            ant.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ant.SetBool("run", true);
            ant.SetBool("walk", false);
            ant.SetBool("idle", false);
            ant.SetBool("eat", false);
        }
        if (Input.GetKey(KeyCode.F))
        {
            ant.SetBool("attack", true);
            ant.SetBool("idle", false);
            ant.SetBool("run", false);
            ant.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            ant.SetBool("hit", true);
            ant.SetBool("idle", false);
            ant.SetBool("run", false);
            ant.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            ant.SetBool("die", true);
            ant.SetBool("idle", false);
        }
        if (Input.GetKey(KeyCode.E))
        {
            ant.SetBool("eat", true);
            ant.SetBool("idle", false);
            ant.SetBool("walk", false);
            ant.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.G))
        {
            ant.SetBool("launch", true);
            ant.SetBool("idle", false);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            mesh.GetComponent<SkinnedMeshRenderer>().material = materials[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            mesh.GetComponent<SkinnedMeshRenderer>().material = materials[1];
        }
    }
}
