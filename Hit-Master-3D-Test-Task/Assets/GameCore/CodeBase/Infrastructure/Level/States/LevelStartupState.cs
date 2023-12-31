﻿using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelStartupState : IState
    {
        private readonly Locations _locations;
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly LevelFactory _levelFactory;
        private readonly IDataProvider _dataProvider;

        public LevelStartupState(IDataProvider dataProvider, Locations locations,
            PlayerObjectFactory playerObjectFactory, LevelFactory levelFactory)
        {
            _locations = locations;
            _playerObjectFactory = playerObjectFactory;
            _levelFactory = levelFactory;
            _dataProvider = dataProvider;
        }

        public void Enter()
        {
            var sceneData = _dataProvider.Get<LevelSceneData>();

            _locations.Initialize(sceneData.LocationsData);
            _playerObjectFactory.CreatePlayerObject(sceneData.PlayerPrefab);
            _levelFactory.CreateGameplayStarter();
        }

        public void Exit() => _levelFactory.RemoveGameplayCheck();
    }
}