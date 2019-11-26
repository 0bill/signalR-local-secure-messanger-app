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
    /// <summary>
    /// Define builder strategy
    /// </summary>
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
    
    /// <summary>
    /// Extension initialize tracking instance strategy
    /// </summary>
    public class TrackInstantiatedObjectsExtension : UnityContainerExtension
    {
        private readonly ObjectContainer _objectContainer = new ObjectContainer();
        /// <summary>
        /// Initialize strategy
        /// </summary>
        protected override void Initialize()
        {
            Context.Container.RegisterInstance(_objectContainer);
            Context.Strategies.Add(new TrackInstantiatedObjectsStrategy(_objectContainer),
                UnityBuildStage.PostInitialization);
        }
    }
    /// <summary>
    /// Container holds all instances of objects
    /// </summary>
    public class ObjectContainer
    {
        private readonly List<object> _instantiatedObjects = new List<object>();
        /// <summary>
        /// Add object to container
        /// </summary>
        /// <param name="toAdd"></param>
        public void Add(object toAdd)
        {
            _instantiatedObjects.Add(toAdd);
        }
        //Dispose tracked object
        public void DisposeObject(object toRemove)
        {
            _instantiatedObjects.Remove(toRemove);
        }

        /// <summary>
        /// Clear container
        /// </summary>
        public void Clear()
        {
            _instantiatedObjects.Clear();
        }

        /// <summary>
        /// Check is Message controller is instanced with user
        /// </summary>
        /// <param name="user">User to check</param>
        /// <returns></returns>
        public MessageController CheckMessageIsInstanceExit(User user)
        {
            MessageController result = (MessageController) _instantiatedObjects.SingleOrDefault(x => x.GetType()==typeof(MessageController) && ((MessageController)x).TalksWithUser().Id==user.Id);
            return result;
        }
    }
}