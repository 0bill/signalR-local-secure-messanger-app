using System;
using System.Collections.Generic;
using System.Linq;
using Client.Controllers;
using Domain;
using Unity;
using Unity.Builder;
using Unity.Extension;
using Unity.Strategies;

namespace Client.Helpers
{
   

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
    
    public class ObjectContainer
    {
        private readonly List<object> _instantiatedObjects = new List<object>();
        public void Add(object toAdd)
        {
            _instantiatedObjects.Add(toAdd);
        }

        public void DisposeObject(object toRemove)
        {
            _instantiatedObjects.Remove(toRemove);
        }

        public void Clear()
        {
            _instantiatedObjects.Clear();
        }

        public MessageController CheckMessageIsInstanceExit(User user)
        {
            MessageController result = (MessageController) _instantiatedObjects.SingleOrDefault(x => x.GetType()==typeof(MessageController) && ((MessageController)x).TalksWithUser().Id==user.Id);
            return result;
        }
    }
}