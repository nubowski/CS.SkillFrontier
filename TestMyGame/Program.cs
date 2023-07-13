using System.Diagnostics;
using CoreLibs;
using TestMyGame.Systems;

// create an instance of the World
var world = new World();

// add systems to the World
// substitute the actual types of systems here
world.AddSystem(new PlayerCharacterCreationRequestSystem());
world.AddSystem(new LocationCreationSystem());
world.AddSystem(new CharacterCreationSystem());

// awake the systems in the World
world.AwakeSystems();

// create a Stopwatch to measure time between frames
var stopwatch = new Stopwatch();
stopwatch.Start();

// start the main game loop
while (true)
{
    // calc deltaTime (time in seconds since last frame)
    var deltaTime = (float)stopwatch.Elapsed.TotalSeconds;
    stopwatch.Restart();

    // call the UpdateSystems method with calculated deltaTime
    world.UpdateSystems(deltaTime);
}