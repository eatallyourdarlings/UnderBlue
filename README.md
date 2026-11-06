# UnderBlue

- Using Unity 6000.3.5.f2
- Targeting Web Export.
- Blender 3.6

Remember to take screen recordings and screenshots, keeping em at /Screenshots/ and on Youtube:
- [DataDesert BlockOut](https://www.youtube.com/watch?v=TyK27t1xsFs) 
- [GeneBomb SpeedRun](https://www.youtube.com/watch?v=zasvFmSZvT4)


«a mnemohazardous disasterscape in the outer reaches of the DataDeserts»
Olive R.F. Sept-Nov 2026
for RMIT Game Design Studio final project - Interactive Environment

This was [lovingly overscoped](https://kinopio.club/underblue-ZQtZwKDj6ty4V22MM2fqY) to be a game about falling through megastructures that I could make if I had worked 3 days a week on it for a couple months, but that turned out to be unrealistic, and not accounting for the amount of tedious fiddling I'd have to do in Unity (i feel so bitrotten). So I scoped it down and focused on the "intro" and the result is this strange little oneiric scene.


things i am proud of!!
  - all the Blender technical art tricks and shortcuts I learnt and practiced...
  - modelling with curves and array modifier (for the hooks, the barbed wire, the chains)
  - collaborating with a friend on sound design for the first time! Josie Halfsunk brought so much to the atmosphere (and my mum with the eery humming)
  - making the most of the tricks I learnt in this one [foggy ShaderGraph tutorial](https://paulinavfx.com/how-to-create-a-low-lying-fog-effect-with-unitys-shadergraph/)
  - manually messing with Level of Detail of the imported meshes; I'd been wanting to figure out how to do that for a while [:
  - the PrefabArrayQuadrant script that makes the big grid of meshes, basically replicating the effect of 2 x Blender Array modifier.
  - doing a bare-minimum prototype of a bunch of the little details I'd planned, like the umbilical cord using the [Wiring System package](https://ciihuycom.itch.io/ciihuy-power-pole-wiring-system).
  - practicing more photo-collage textures (although leaving it a bit too late and working on them in the last week)

## Audio

Note for halfsunk: There's an Audio Source at (0,0) in the DataDesert. You can duplicate this to add more sound sources to the mix. It's non-directional (the slider is all the way to 2D), and we will likely not do much directional sound because it would create so many duplicate Audio Sources in each scene. Rather fade in sounds based on your proximity to Prefabs, because there will be so many repetitions of the same sound source (aerials, electrical pylons etc.). So consider a max volume and a minimum ambient volume for each sound source that should otherwise be directional, and we can probably fake it pretty well.

- [Audio Assets Spreadsheet](https://drive.proton.me/urls/Q41W5Z9FPG#MRHPAmrbQEdB)
- [Music Inspo](https://www.youtube.com/playlist?list=PLBi5dMy5mvJ4)

### Assets Used
- [Freesound - Infrasound - 18hz - Sine wave.wav by Headphaze](https://freesound.org/people/Headphaze/sounds/235214/)

## Dev notes


### Blenber

I guess there's no fuggin hierarchies allowed in the Blender scene because it keeps fwuckin with the rotation when exporting to FBX... game engines r so cursed...

Wire Bezier settings:
- 3D shape
  - Resolution Preview: 3
  - Twist Method: Minimum
  - Fill Mode: Half
  - Curve Deform: Radius
- Bevel: Round
  - Resolution: 1

### Import Scene Process

- Export fbx from Blender with the "Unity Scene" 
  - Visible objects only
  - Set the transform origins of the scene to 0,0
  - c

### Controlling lighting inside of a mesh...

The problem: light reaching the interior sphere (with flipped faces), lighting the bottom, whereas light reaches 


- Flipped faces of sphere.
- Made a totally black skybox
- Set material to render both faces
- Scaled sphere down to 1/10th size, like 65m across 
- Shadows Settings of PC_RPAsset
  - 130 seems to be the threshold (so scaled back up, that would be 1300. good to know!)
- Unity uses distance-based light clipping, so it will only do e.g. 1000 metres of real-time light **for all light types**
- Adjusting the slits in the Shadows settings

Another potential solution: collider that decreases the Shadow distance once you drop into the Bomb.
