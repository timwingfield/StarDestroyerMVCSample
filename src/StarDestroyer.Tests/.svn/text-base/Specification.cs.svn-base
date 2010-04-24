using System;
using System.Diagnostics;
using System.Reflection;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Impl;
using Rhino.Mocks.Interfaces;
using StructureMap.AutoMocking;

namespace StarDestroyer.Tests
{

    public class AutoMockingSpecification<T> : Specification
        where T : class 
    {
        private bool _replayTheClassUnderTest = false;

        public RhinoAutoMocker<T> Mocker { get; set; }

        protected override void Before_each()
        {
            base.Before_each();
            Mocker = new RhinoAutoMocker<T>();
        }

        protected override void ReplayAll()
        {
            base.ReplayAll();
            if (_replayTheClassUnderTest)
                Mocker.ClassUnderTest.Replay();
        }

        public virtual void PartialMockTheClassUnderTest()
        {
            Mocker.PartialMockTheClassUnderTest();
            _replayTheClassUnderTest = true;
        }
    }

    [TestFixture]
    public class Specification
    {
        [SetUp]
        public void Initialize()
        {
            Mocks = new MockRepository();
            Before_each();
            ReplayAll();
            Because();
        }

        [TearDown]
        public void Cleanup()
        {
            After_each();
        }

        protected virtual void Before_each() { }
        protected virtual void After_each() { }
        protected virtual void Because() { }

        public MockRepository Mocks { get; private set; }

        protected T Mock<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        protected T Stub<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        protected T Stub<T>(params object[] args) where T : class
        {
            return MockRepository.GenerateStub<T>(args);
        }

        protected T Partial<T>() where T : class
        {
            return Mocks.PartialMock<T>();
        }

        protected T Partial<T>(params object[] args) where T : class
        {
            return Mocks.PartialMock<T>(args);
        }

        protected void Raise(object mock, string eventName, object sender, EventArgs args)
        {
            new EventRaiser((IMockedObject)mock, eventName).Raise(sender, args);
        }

        protected virtual void ReplayAll()
        {
            Mocks.ReplayAll();
        }

        protected void spec_not_implemented()
        {
            MethodBase caller = new StackTrace().GetFrame(1).GetMethod();

            spec_not_implemented(caller.DeclaringType.Name + "." + caller.Name);
        }

        protected void spec_not_implemented(string specName)
        {
            Console.WriteLine("Specification not implemented : " + specName);
        }

    }
}
