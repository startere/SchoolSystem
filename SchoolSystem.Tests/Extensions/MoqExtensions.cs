using Moq;
using System;
using System.Linq.Expressions;

namespace SchoolSystemTests.Extensions
{
    public static class MoqExtensions
    {
        public static void SetupMany<TSvc, TReturn>(this Mock<TSvc> mock,
            Expression<Func<TSvc, TReturn>> expression,
            params TReturn[] args)
            where TSvc : class
        {
            if (args.Length == 0)
            {
                mock.Setup(expression)
                    .Returns(null);

                return;
            }

            var numberOfCalls = 0;

            mock.Setup(expression)
                .Returns(() => numberOfCalls < args.Length ? args[numberOfCalls] : args[args.Length - 1])
                .Callback(() => numberOfCalls++);
        }
    }
}
