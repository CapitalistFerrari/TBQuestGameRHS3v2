using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGameRH.PresentationLayer;
using TBQuestGameRH.DataLayer;
using TBQuestGameRH.Models;
using System.Collections.ObjectModel;

namespace TBQuestGameRH.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        bool _newPlayer = false;
        Player _player = new Player();
        Map _gameMap;
        GameMapCoordinates _initialLocationCoordinates;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _gameMap = GameData.GameMap();
            _initialLocationCoordinates = GameData.InitialGameMapLocation();
        }

        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _player.Level = 1;
                _player.HP = 100;
                _player.CurrentStatus = 0;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _gameMap,
                _initialLocationCoordinates
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();


        }
    }
}
