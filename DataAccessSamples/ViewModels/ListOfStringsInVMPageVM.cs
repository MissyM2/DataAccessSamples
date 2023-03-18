using System;
namespace DataAccessSamples.ViewModels
{
	public class ListOfStringsInVMPageVM : BaseViewModel
    {

        public List<string> Fruits { get; } = new();


        public ListOfStringsInVMPageVM()
        {
            Fruits = CreateFruitCollection();
        }

        public List<string> CreateFruitCollection()
        {
            var myCollection = new List<string>
            {
                "Apple",
                "Orange",
                "Grape",
                "Banana",
                "Blueberry"
            };

            return myCollection;

        }


    }
}

