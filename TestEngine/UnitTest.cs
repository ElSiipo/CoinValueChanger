using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinValueChanger;
using System.Collections.Generic;
using System.Linq;

namespace TestEngine
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_Stage1_UnableToInsertNull()
        {
            var valueHandler = new ValueChangeHander(null);
            valueHandler.GetValueCombinations(1);
        }

        [TestMethod]
        public void TestMethod_Stage1_IsAbleToInsertValue()
        {
            var _listOfValidChange = CreateListOfValidChange();
            _listOfValidChange = _listOfValidChange.OrderByDescending(x => x.Value).ToList();

            var valueHandler = new ValueChangeHander(_listOfValidChange);
            var valueToConvert = 123;

            valueHandler.GetValueCombinations(valueToConvert);
        }

        [TestMethod]
        public void TestMethod_Stage1_GetLowestComboInReturn()
        {
            var _listOfValidChange = CreateListOfValidChange();
            _listOfValidChange = _listOfValidChange.OrderByDescending(x => x.Value).ToList();

            var valueHandler = new ValueChangeHander(_listOfValidChange);
            var valueToConvert = 435872433;

            var _listOfChangeCombinations = valueHandler.GetValueCombinations(valueToConvert);

            Assert.AreEqual(true, _listOfChangeCombinations.Count > 0);
        }



        [TestMethod]
        public void TestMethod_Stage2_GetAllCombos()
        {
            var valueHandler = new ValueChangeHander(CreateListOfValidChange());
            var valueToConvert = 133;

            var _listOfChangeCombinations = valueHandler.GetValuesWithAnyCombinations(valueToConvert);

            Assert.AreEqual(true, _listOfChangeCombinations.Count > 0);
        }


        private List<Change> CreateListOfValidChange()
        {
            var _listOfChange = new List<Change>();

            _listOfChange.Add(new Change() { Value = 1 });
            _listOfChange.Add(new Change() { Value = 2 });
            _listOfChange.Add(new Change() { Value = 5 });
            _listOfChange.Add(new Change() { Value = 10 });
            _listOfChange.Add(new Change() { Value = 20 });
            _listOfChange.Add(new Change() { Value = 50 });
            _listOfChange.Add(new Change() { Value = 100 });
            _listOfChange.Add(new Change() { Value = 200 });
            _listOfChange.Add(new Change() { Value = 500 });
            _listOfChange.Add(new Change() { Value = 1000 });

            return _listOfChange;
        }
    }
}
