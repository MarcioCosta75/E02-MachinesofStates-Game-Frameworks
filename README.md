# Lakitu State Machine Project

This Unity3D project implements a state machine to mimic the behavior of Lakitu from Mario, featuring animations and smooth movement.

## Features

- **State Machine**:
  - `PlayerStopped`: The Lakitu-like character hovers near the player, playing an idle animation.
  - `PlayerMoving`: The Lakitu-like character moves toward the player with inertia, using `Vector3.Lerp` and `Quaternion.Lerp`.

- **Animations**:
  - `Idle Animation`: Character floats up and down while stationary.
  - `Moving Animation`: Character tilts slightly while following the player.

- **Player Controller**:
  - Uses a First Person Controller for movement and player interaction.

## How It Works

1. **State Machine**:
   - Detects player movement and switches between `PlayerStopped` and `PlayerMoving` states.
   - Smooth transitions ensure realistic behavior.

2. **Movement**:
   - Lakitu-like character follows the player without being a child GameObject.
   - Movement incorporates inertia using Lerp for position and rotation.
