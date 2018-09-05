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
			GameObject go = Instantiate(targetObject, map.GetCellCenterWorld(targetPos), Quaternion.identity);
			SetupAgent(go.transform);
		}
		void Update()
		{

		}
		private void SetupAgent(Transform i_Target)
		{
			navMeshAgent = agent.GetComponent<NavMeshAgent>();
			navMeshAgent.SetDestination(i_Target.position);
			Instantiate(agent, map.GetCellCenterWorld(agentStartPos), Quaternion.identity);
		}
	}
}
