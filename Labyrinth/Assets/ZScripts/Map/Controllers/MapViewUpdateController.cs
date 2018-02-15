using System;
using System.Collections.Generic;
using FeatureDistri;
using UnityEngine;
using Zenject;
using ZScripts.ActionDistributor;
using ZScripts.Map.Info;
using ZScripts.Map.View;

namespace ZScripts.Map.Controllers
{
    public class MapViewUpdateController
    {
        private IMapViewController _mapViewController;
        private List<IntVector2> _initializedIndexes;
        private IHeavyActionDistributor _heavyActionDistributor;
        private DiContainer _container;

        public MapViewUpdateController(
            IMapViewController mapViewController,
            IHeavyActionDistributor heavyActionDistributor,
            DiContainer container
            )
        {
            _container = container;
            _mapViewController = mapViewController;
            _heavyActionDistributor = heavyActionDistributor;
            Initialize();
        }

        public void Initialize()
        {
            _initializedIndexes = new List<IntVector2>();
        }

        public void InitializeTiles<T>(List<T> tileInfos) where T : ITileView
        {
            Action action;
            
            HeavyActionsBunchesExecutor heavyActionsBunchesExecutor = _container.Resolve<HeavyActionsBunchesExecutor>();
            heavyActionsBunchesExecutor.Initialize(3);
            
            foreach (ITileView tileInfo in tileInfos)
            {
                action = () => InitializeTile(tileInfo);
                heavyActionsBunchesExecutor.AddAction(action);
            }  
            
            heavyActionsBunchesExecutor.Execute();
        }

        private void InitializeTile(ITileView tileInfo)
        {
            if (_initializedIndexes.Contains(tileInfo.ViewPosition))
                return;

            switch (tileInfo.Type)
            {
                case MapTileType.Cube:
                {
                    _mapViewController.InitializeCube(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Plane:
                {
                    _mapViewController.InitializePlane(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Square:
                {
                    _mapViewController.InitializeSquare(tileInfo.ViewPosition);
                    break;
                }
                case MapTileType.Empty:
                {
                    _mapViewController.InitializeEmpty(tileInfo.ViewPosition);
                    break;
                }
            }

            _initializedIndexes.Add(new IntVector2(tileInfo.ViewPosition.x, tileInfo.ViewPosition.y));
        }

        public void DestroyTiles<T>(List<T> tileInfos) where T : ITileView
        {
            Action action;
            HeavyActionsBunchesExecutor heavyActionsBunchesExecutor = _container.Resolve<HeavyActionsBunchesExecutor>();
            heavyActionsBunchesExecutor.Initialize(3);
            
            foreach (ITileView tileInfo in tileInfos)
            {
                action = () =>
                {
                    _mapViewController.DestroyTile(tileInfo.ViewPosition);
                    _initializedIndexes.Remove(tileInfo.ViewPosition);
                };
                heavyActionsBunchesExecutor.AddAction(action);
            }
            
            heavyActionsBunchesExecutor.Execute();
        }
    }
}