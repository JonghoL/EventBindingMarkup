using System;
using Xunit;

namespace EventBinding.Tests
{
    public class EventBindingExtensionTests
    {
        public class FollowPropertyPathMethod
        {
            [Fact]
            public void TargetNull_Should_ThrowsException()
            {
                var ex = Assert.Throws<ArgumentNullException>(() => EventBindingExtension.FollowPropertyPath(null, null));
                Assert.Equal("target null", ex.ParamName);
            }

            [Fact]
            public void PathNull_Should_ThrowsException()
            {
                var ex = Assert.Throws<ArgumentNullException>(() => EventBindingExtension.FollowPropertyPath(new DummyTarget(), null));
                Assert.Equal("path null", ex.ParamName);
            }

            [Fact]
            public void PathEmpty_Should_ThrowsException2()
            {
                var ex = Assert.Throws<NullReferenceException>(() => EventBindingExtension.FollowPropertyPath(new DummyTarget(), ""));
                Assert.Equal("property null", ex.Message);
            }

            [Fact]
            public void InvalidPath_Should_ThrowsException2()
            {
                var ex = Assert.Throws<NullReferenceException>(() => EventBindingExtension.FollowPropertyPath(new DummyTarget(), "IsVisible"));
                Assert.Equal("property null", ex.Message);
            }

            [Fact]
            public void Verify()
            {
                var ret = EventBindingExtension.FollowPropertyPath(new DummyTarget { IsEnabled = true }, "IsEnabled");
                Assert.NotNull(ret);
                Assert.Equal("True", ret.ToString());
            }

            [Fact]
            public void Verify_FollowProperty()
            {
                var ret = EventBindingExtension.FollowPropertyPath(new DummyTarget { Source = new DummySource { Id = 2}}, "Source.Id");
                Assert.NotNull(ret);
                Assert.Equal("2", ret.ToString());
            }
        }
    }

    public class DummyTarget
    {
        public bool IsEnabled { get; set; }
        public DummySource Source { get; set; }
    }

    public class DummySource
    {
        public int Id { get; set; }
    }
}
