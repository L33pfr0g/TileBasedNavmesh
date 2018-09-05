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

### GameController
This script is garbage. Literally thrown together to make everything work. I recommend actually reading
the doc on NavMeshes and NavMeshAgents. It works though so ¯\_(ツ)_/¯

### Other 
For best results, make sure the radius of your agent is half of the cell size.
The "surfaces" game object is rotated -90 degrees to align with the tilemap. This is required or it won't
work.

