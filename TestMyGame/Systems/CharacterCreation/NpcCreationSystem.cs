using CoreLibs.Entities;
using CoreLibs.Events;
using CoreLibs.Systems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using CoreLibs.Utilities;
using TestMyGame.Components;
using TestMyGame.Events;
using TestMyGame.Utility;

namespace TestMyGame.Systems.CharacterCreation
{
    public class NpcCreationSystem : BaseSystem
    {
        private readonly NpcFactory _npcFactory;
        private const string BestiaryFilePath = "./Data/Bestiary.json";
        private const string LocationFilePath = "./Data/Locations.json";

        public NpcCreationSystem(NpcFactory npcFactory, EntityManager entityManager, EventManager eventManager) : base(entityManager, eventManager)
        {
            _npcFactory = npcFactory;

            _eventManager.AddListener<CreateNpcEvent>(CreateNpc);
        }

        private void CreateNpc(CreateNpcEvent createNpcEvent)
        {
            // making a doll-npc
            var npc = _npcFactory.CreateNpc();

            // fetch base NPC data
            var locationId = createNpcEvent.Player.GetComponent<PositionComponent>().CurrentLocationId;
            var locationName = _entityManager.GetEntityById(locationId).GetComponent<LocationComponent>().Name;

            // fetch race weights
            var raceWeights = FetchRaceWeightsByLocation(locationName);

            // roll for race.
            var selectedRace = SelectRaceFromWeights(raceWeights);

            // returns a pool of NPCs suitable for a given race and location
            var npcPool = FetchNpcPoolByRace(selectedRace);

            // NPC from the pool according to some logic (like weight or chance)
            var baseNpcData = SelectNpcFromPool(npcPool);

            // add all logic whatever we want or need to change (race, components, procedural generation, whatever we want with the RAW entity)
            CustomizeNpc(npc, baseNpcData, createNpcEvent.Player);
        }

        private string SelectRaceFromWeights(Dictionary<string, int> raceWeights)
        {
            var totalWeight = raceWeights.Sum(race => race.Value);
            var randomNumber = new Random().Next(totalWeight);

            foreach (var race in raceWeights)
            {
                if (randomNumber < race.Value)
                {
                    return race.Key;
                }
                randomNumber -= race.Value;
            }

            throw new Exception("Could not select a race. Check race weights.");
        }

        private Dictionary<string, int> FetchRaceWeightsByLocation(string locationName)
        {
            var locationJson = File.ReadAllText(LocationFilePath);
            var locations = JsonConvert.DeserializeObject<List<LocationData>>(locationJson);

            var location = locations.First(loc => loc.Name == locationName);
            var raceWeights = new Dictionary<string, int>();

            foreach (var npcPoolItem in location.NpcPool)
            {
                if (npcPoolItem.Type == "race")
                {
                    raceWeights.Add(npcPoolItem.Value, npcPoolItem.Weight);
                }
            }

            return raceWeights;
        }

        private void CustomizeNpc(Entity npc, NpcData baseNpcData, Entity player)
        {   

            // Add new components
            npc.AddComponent(new DescriptionComponent(baseNpcData.Description));
            npc.AddComponent(new CombatPhrasesComponent(baseNpcData.CombatPhrases));
            npc.AddComponent(new NameComponent(baseNpcData.Name));
            
            var random = new Random();
            var gender = (GenderComponent.GenderType)random.Next(0, 2);
            npc.AddComponent(new GenderComponent { Gender = gender });

            // Get and modify existing components

            if (Enum.TryParse(baseNpcData.Race, true, out RaceComponent.RaceType race)) 
            {
                npc.AddComponent(new RaceComponent());
                npc.GetComponent<RaceComponent>().Race = race;
            } 
            else 
            {
                Logger.Debug($"There are no such races in our data base");
            }
            _eventManager.Emit(new StatsUpdatedEvent(npc));
            // Customization logic goes here.
            
            // Emit the event to go to combat system
            _eventManager.Emit(new NpcCreatedEvent(npc, player));
        }

        private NpcData SelectNpcFromPool(List<NpcData> npcPool)
        {
            var totalWeight = npcPool.Sum(npc => npc.Weight);
            var randomNumber = new Random().Next(totalWeight);

            foreach (var npc in npcPool)
            {
                if (randomNumber < npc.Weight)
                {
                    return npc;
                }
                randomNumber -= npc.Weight;
            }

            throw new Exception("Could not select an NPC. Check NPC weights.");
        }

        private List<NpcData> FetchNpcPoolByRace(string race)
        {
            var bestiaryJson = File.ReadAllText(BestiaryFilePath);
            var bestiary = JsonConvert.DeserializeObject<List<NpcData>>(bestiaryJson);

            var suitableNpcs = bestiary.Where(npc => npc.Race == race).ToList();
            return suitableNpcs;
        }

        public override void ProcessEntity(Entity entity, float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
