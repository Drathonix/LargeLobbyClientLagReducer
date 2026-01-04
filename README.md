# LargeLobbyClientLagReducer
Reduces PEAK client-side lag when playing in large (and small) lobbies by skipping unnecessary physics calculations which consume a significant amount of the game's runtime.
### Actual Functionality
Player state calculations are only cancelled if all these conditions are met:
1. The player is not the client player.
2. The player is further than 10 meters away.
3. The player is not within visible range.
4. The player is not being carried
# Patch Targets
1. CharacterRagdoll.FixedUpdate - Handles character ragdoll physics calculations, this is the most significant cause of lag during gameplay and seems to hav.
2. CharacterMovement.FixedUpdate - Handles character movement calculation, mid significance (around 1/4th the strain on the CPU)
3. Character.FixedUpdate - Seems irrelevant to cancel but it was my first target so I'm leaving it in.
Notably cancelling all these targets seemingly have no influence on gameplay so it may be worth cancelling them entirely but for now I won't go that far.
# License
MIT license, feel free to use this project anywhere, all I ask for is you linking to my source code.
### Thunderstore Packaging
You don't need to read this, I'm just keeping it here so I have the command ready.

```sh
dotnet build -c Release -target:PackTS -v d
```

> [!NOTE]  
> You can learn about different build options with `dotnet build --help`.  
> `-c` is short for `--configuration` and `-v d` is `--verbosity detailed`.

The built package will be found at `artifacts/thunderstore/`.
