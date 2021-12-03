using UnityEngine;
using UnityEngine.AI;

public class ShowGoldenPath : MonoBehaviour
{
    public Transform target;
    private NavMeshPath path;
    private float elapsed = 0.0f;
    public LineRenderer lineRenderer;

    void Start()
    {
        path = new NavMeshPath();
        elapsed = 0.0f;
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            print("hi");
            elapsed -= 1.0f;
            bool result = NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            print(result);
            lineRenderer.SetVertexCount(path.corners.Length);
            lineRenderer.SetPositions(path.corners);

        }

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            print("Start: " + path.corners[i] + " End: " + path.corners[i + 1]);
        }
    }
}