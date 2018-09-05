using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

namespace TileBasedNavMesh
{
    public class GameController : MonoBehaviour
    {
        public CellToNavmesh cellToNavmesh;
        public GameObject agent; //The prefab containing the Agent
        public Vector3Int agentStartPos; //Start position of the agent on the grid
        public GameObject targetObject; //The prefab containing the target
        public Vector3Int targetPos; //Position of the target on the grid

        public Grid grid;
        private Tilemap map;
        private NavMeshAgent navMeshAgent; //Reference to the instantiated NavMeshAgent. Useful for debugging
        void Start()
        {
            map = grid.transform.GetComponentInChildren<Tilemap>();
            cellToNavmesh.Init();
            GameObject trgt = Instantiate(targetObject, map.GetCellCenterWorld(map.origin + targetPos), Quaternion.identity);
            SetupAgent(trgt.transform);
        }
        private void SetupAgent(Transform i_Target)
        {
            GameObject go = Instantiate(agent);
            Vector3 sourcePostion = map.GetCellCenterWorld(map.origin + agentStartPos);
            NavMeshHit closestHit;
            if (NavMesh.SamplePosition(sourcePostion, out closestHit, 500, 1))
            {
                go.transform.position = closestHit.position;
                go.GetComponent<NavMeshAgent>().enabled = true;

                go.GetComponent<NavMeshAgent>().SetDestination(i_Target.position);
            }
        }
    }
}
