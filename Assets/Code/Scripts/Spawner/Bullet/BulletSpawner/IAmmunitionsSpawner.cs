using System;

public interface IAmmunitionsSpawner
{
    void Spawn();

    event Action Spawned;
}