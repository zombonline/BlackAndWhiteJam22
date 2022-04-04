using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    private Mesh viewMesh;
    public MeshFilter viewMeshFilter;

    private float startingAngle;
    private float fov = 90;
    private float viewDistance = 5f;
    private float wallVisonDistance = 0.5f;
    private Vector3 origin = Vector3.zero;

    private float edgeDistanceThreshold = 0.5f;
    private int edgeResolveIterations = 20;

    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private bool seeThroughWalls;

    // Start is called before the first frame update
    void Start()
    {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

    }

    // Update is called once per frame
    void Update()
    {
        int rayCount = 40;

        float currAngle = startingAngle;

        float angleIncrease = fov / rayCount;

        List<Vector3> viewPoints = new List<Vector3>();


        ViewCastInfo oldViewCast = new ViewCastInfo();

        for (int i = 0; i <= rayCount; i++)
        {
            ViewCastInfo newViewCast = ViewCast(currAngle);

            if (i > 0)
            {
                //check inbetween view casts
                bool edgeDistThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDistanceThreshold;

                if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDistThresholdExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }

                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }
                
            }

            viewPoints.Add(newViewCast.point);
            
            oldViewCast = newViewCast;
            
            currAngle -= angleIncrease;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = origin;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = viewPoints[i];

            if (i < vertexCount -2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
           
        }

        viewMesh.Clear();

        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();

        viewMesh.RecalculateBounds();
    }

    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = GetVectorFromAngle(globalAngle);
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, viewDistance, mask);

        if (hit)
        {
            if (seeThroughWalls)
            {
                //find the distance vision travels through wall
                float minWallDistance = viewDistance < hit.distance + wallVisonDistance ? viewDistance : hit.distance + wallVisonDistance;
                return new ViewCastInfo(true, origin + dir * minWallDistance, hit.distance, globalAngle);
            }
            else
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
            }
        }
        else
        {
            return new ViewCastInfo(false, origin + dir * viewDistance, viewDistance, globalAngle);
        }
    }

    public void SetFOVDirection(Vector3 aimDirection)
    {
        
        startingAngle = GetAngleFromVec3(aimDirection) + 90 - fov / 2f;
    }

    public void SetOrigin(Vector3 newOrigin)
    {
        origin = newOrigin;
    }

    private EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDistThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDistanceThreshold;

            if (newViewCast.hit == minViewCast.hit && !edgeDistThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVec3(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }

        return n;
    }

    public void IncreaseViewDistance(float amount)
    {
        viewDistance += amount;
    }


    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }

    public struct ViewCastInfo{
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    
    }
}
