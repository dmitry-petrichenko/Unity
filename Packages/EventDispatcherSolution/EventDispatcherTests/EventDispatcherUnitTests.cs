using System;
using ID5D6AAC.Common.EventDispatcher;
using Xunit;

namespace EventDispatcherTests
{
    public class EventDispatcherUnitTests
    {
        [Fact]
        public void SuccesfullyCallHandler()
        {
            // Arrange
            bool called = false;
            var action = new Action(() => { called = true; });
            var eventDispatcher = new EventDispatcher();
            eventDispatcher.AddEventListener("someEvent", action);
            
            // Act
            eventDispatcher.DispatchEvent("someEvent");
            
            // Assert
            Assert.True(called);
        }
    }
}