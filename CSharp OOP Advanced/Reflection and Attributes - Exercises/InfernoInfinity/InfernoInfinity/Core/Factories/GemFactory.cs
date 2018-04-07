namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Entities.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, string gemQuality)
        {
            Type typeOfGem = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == gemType);

            var qualityLevel = (GemQualityLevel)Enum.Parse(typeof(GemQualityLevel), gemQuality);

            object[] gemParams = new object[] { qualityLevel };

            var gem = (IGem)Activator.CreateInstance(typeOfGem, gemParams);

            return gem;
        }
    }
}
