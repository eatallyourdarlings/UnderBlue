

# UnderBlue

## Import Scene Process...

- Export fbx from Blender with the "Unity Scene" 
  - Visible objects only
  -
- Set the transform origins of the scene to 0,0
- c
- 

## Lighting inside of the sphere...

- Flipped faces of sphere.


The problem: light reaching the interior sphere (with flipped faces), lighting the bottom, whereas light reaches 

- Made a totally black skybox
- Set material to render both faces
- Scaled sphere down to 1/10th size, like 65m across 
- Shadows Settings of PC_RPAsset
  - 130 seems to be the threshold (so scaled back up, that would be 1300. good to know!)
- Unity uses distance-based light clipping, so it will only do e.g. 1000 metres of real-time light **for all light types**
- Adjusting the slits in the Shadows settings

Another potential solution: collider that decreases the Shadow distance once you drop into the Bomb.

## Spawnpoints...
1331,1331,0
0,90,0