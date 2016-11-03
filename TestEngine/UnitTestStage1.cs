using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinValueChanger;
using System.Collections.Generic;
using System.Linq;

namespace TestEngine
{
    [TestClass]
    public class UnitTestStage1
    {
        [TestMethod]
        public void TestMethod_IsAbleToInsertValue()
        {
            var valueHandler = new ValueChangeHander(CreateListOfAccessableChange());
            var valueToConvert = 123;
            
            valueHandler.GetValueCombinations(valueToConvert);
        }

        [TestMethod]
        public void TestMethod_GetAnyCombinationInReturn()
        {
            var _listOfAccessableChange = CreateListOfAccessableChange();
            _listOfAccessableChange = _listOfAccessableChange.OrderByDescending(x => x.Value).ToList();

            var _listOfChangeCombinations = new List<Change>();
            var valueHandler = new ValueChangeHander(_listOfAccessableChange);
            var valueToConvert = 435872433;

            _listOfChangeCombinations = valueHandler.GetValueCombinations(valueToConvert);

            Assert.AreEqual(true, _listOfChangeCombinations.Count > 0);
        }



        private List<Change> CreateListOfAccessableChange()
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
