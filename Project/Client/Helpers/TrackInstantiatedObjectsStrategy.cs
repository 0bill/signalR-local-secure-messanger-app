using System;
using System.Collections.Generic;
using System.Linq;
using Client.Controllers;
using Unity;
using Unity.Builder;
using Unity.Extension;
using Unity.Strategies;

namespace Client.Helpers
{
    public class ObjectContainer
    {
        private readonly List<object> _instantiatedObjects = new List<object>();
        public void Add(object toAdd)
        {
            _instantiatedObjects.Add(toAdd);
        }
        public IEnumerable<object> GetInstantiatedObjects()
        {
            return _instantiatedObjects;
        }
        public IEnumerable<T> GetInstantiatedObjects<T>()
        {
            return GetInstantiatedObjects().OfType<T>();
        }

        public void DisposeObject(object toRemove)
        {
            _instantiatedObjects.Remove(toRemove);
        }

        public MessageController CheckMessageIsInstanceExit(string user)
        {
            //var list = GetInstantiatedObjects<MessageController>();
            
            MessageController result = (MessageController) _instantiatedObjects.SingleOrDefault(x => x.GetType()==typeof(MessageController) && ((MessageController)x).TalksWithUser()==user);
            return result;
        }
    }

    public class TrackInstantiatedObjectsStrategy : BuilderStrategy
    {
        private readonly ObjectContainer _objectContainer;
        public TrackInstantiatedObjectsStrategy(ObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        public override void PostBuildUp(ref BuilderContext builderContext)
        {
            _objectContainer.Add(builderContext.Existing);
        }
    }

    public class TrackInstantiatedObjectsExtension : UnityContainerExtension
    {
        private readonly ObjectContainer _objectContainer = new ObjectContainer();
        protected override void Initialize()
        {
            Context.Container.RegisterInstance(_objectContainer);
            Context.Strategies.Add(new TrackInstantiatedObjectsStrategy(_objectContainer),
                UnityBuildStage.PostInitialization);
        }
    }
}