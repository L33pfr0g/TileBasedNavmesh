# TileBasedNavmesh
A quick and dirty example of a way to use NavMeshAgents and AI functionalities in a tile based project.

## Key Components	
### WalkableTile and BlockingTile
Scriptable tiles with the bare minimum implemented. They are used to determine the type of colliders we 
instantiate before building the NavMesh.

### CellToNavMesh.cs
This script creates the colliders for each tile and does the required manipulations to build the NavMesh 
correctly. Must be applied to the Grid object and requires a GameObject with a NavMeshSurface component 
in the scene.

### Other 
For best results, make sure the radius of your agent is half of the cell size.
