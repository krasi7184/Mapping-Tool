using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MappingTool.Models
{
    public class AllElementsViewModel
    {
        private List<UserInputViewModel> elementsToBeMatched;
        private List<UserInputViewModel> elementsToBeMatchedAgainst;
        private List<List<UserInputViewModel>> elementsToBeMatchedAgainstOrdered;


        public AllElementsViewModel()
        {
        }
        public AllElementsViewModel(List<UserInputViewModel> elementsToBeMatched, List<UserInputViewModel> elementsToBeMatchedAgainst)
        {
            this.elementsToBeMatched = elementsToBeMatched;
            this.elementsToBeMatchedAgainst = elementsToBeMatchedAgainst;
        }
        public List<UserInputViewModel> ElementsToBeMatched
        {
            get
            {
                return this.elementsToBeMatched;
            }
            set
            {
                this.elementsToBeMatched = value;
            }
        }
        public List<UserInputViewModel> ElementsToBeMatchedAgainst
        {
            get
            {
                return this.elementsToBeMatchedAgainst;
            }
            set
            {
                this.elementsToBeMatchedAgainst = value;
            }
        }
        public List<List<UserInputViewModel>> ElementsToBeMatchedAgainstOrdered
        {
            get
            {
                return this.elementsToBeMatchedAgainstOrdered;
            }
            set
            {
                this.elementsToBeMatchedAgainstOrdered = value;
            }
        }
        public List<UserInputViewModel> UnmappedElements { get; set; } = new List<UserInputViewModel>();

    }
}
