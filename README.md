

# UnderBlue

- Using Unity 6000.3.5.f2
- Targeting Web Export.
- Blender 3.6

Remember to take screen recordings and screenshots, keeping em at /Screenshots/ and on Youtube:
- [DataDesert BlockOut](https://www.youtube.com/watch?v=TyK27t1xsFs) 
- [GeneBomb SpeedRun](https://www.youtube.com/watch?v=zasvFmSZvT4)

## Audio

Note for halfsunk: There's an Audio Source at (0,0) in the DataDesert. You can duplicate this to add more sound sources to the mix. It's non-directional (the slider is all the way to 2D), and we will likely not do much directional sound because it would create so many duplicate Audio Sources in each scene. Rather fade in sounds based on your proximity to Prefabs, because there will be so many repetitions of the same sound source (aerials, electrical pylons etc.). So consider a max volume and a minimum ambient volume for each sound source that should otherwise be directional, and we can probably fake it pretty well.

- [Audio Assets Spreadsheet](https://drive.proton.me/urls/Q41W5Z9FPG#MRHPAmrbQEdB)
- [Music Inspo](https://www.youtube.com/playlist?list=PLBi5dMy5mvJ4)

### Assets Used
- [Freesound - Infrasound - 18hz - Sine wave.wav by Headphaze](https://freesound.org/people/Headphaze/sounds/235214/)

## Dev notes
### Import Scene Process

- Export fbx from Blender with the "Unity Scene" 
  - Visible objects only
  - Set the transform origins of the scene to 0,0
  - c

### Controlling lighting inside of the sphere...

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

## Spawnpoints...
1331,1331,0
0,90,0