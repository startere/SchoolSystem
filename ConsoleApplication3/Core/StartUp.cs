using System;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new Reader();

            var businessLogicService = new BusinessLogicService();
            businessLogicService.Execute(reader);
        }
    }
}
