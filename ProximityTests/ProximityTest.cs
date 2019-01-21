using CodingExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProximityTests
{
    [TestClass]
    public class ProximityTest
    {
        ProximitySearch proximitySearch;

        [TestInitialize]
        public void Intialize()
        {
            proximitySearch = new ProximitySearch();
        }

        [TestMethod]
        public void CalculateOccurences()
        {
            string input = "the man the plan the canal panama panama canal the plan the man the the man the plan the canal panama";
            string key1 = "the";
            string key2 = "canal";
            int range = 6;
            int result = proximitySearch.CalculateOccurences(input, key1, key2, range);
            Assert.IsTrue(result == 11);
            input = "the man the plan the canal panama";
            result = proximitySearch.CalculateOccurences(input, key1, key2, range);
            Assert.IsTrue(result == 3);
            range = 3;
            result = proximitySearch.CalculateOccurences(input, key1, key2, range);
            Assert.IsTrue(result == 1);
            input = "Hello world hello world";
            key1 = "hello";
            key2 = "world";
            range = 6;
            result = proximitySearch.CalculateOccurences(input, key1, key2, range);
            Assert.IsTrue(result == 4);
        }
        [TestMethod]
        public void CalculateOccurences_KeyNotFound()
        {
            string input = "the man the plan the canal panama panama canal the plan the man the the man the plan the canal panama";
            string key1 = "hello";
            string key2 = "world";
            int range = 6;
            int result = proximitySearch.CalculateOccurences(input, key1, key2, range);
            Assert.IsTrue(result == 0);
        }
    }
}
