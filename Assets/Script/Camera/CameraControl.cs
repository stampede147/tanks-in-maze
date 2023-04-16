using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    [HideInInspector] public GameObject[] m_Targets; 


    private Camera m_Camera;                        
    private Vector3 m_MoveVelocity;                 

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        m_Targets = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FixedUpdate()
    {
        Move();
        
    }


    private void Move()
    {
        getAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, getAveragePosition(), ref m_MoveVelocity, m_DampTime);

    }


    private Vector3 getAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].activeSelf)
                continue;

            averagePos += m_Targets[i].transform.position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

         averagePos.y = this.transform.position.y;
        return averagePos;
    }


    public void SetStartPositionAndSize()
    {
        getAveragePosition();

        transform.position = getAveragePosition();
     
    }
}