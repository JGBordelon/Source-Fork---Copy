using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psych1 {
    public class EfficacyEvaluation {
        public string trialType;
        public string evaluationNumber; // some trial phases have more than one evaluation
        public string evaluationResponse;
        List<EfficacyChoice> preSubmitChoices;
        
        public EfficacyEvaluation()
        {
            preSubmitChoices = new List<EfficacyChoice>();
        }

        public void AddChoice(string choice, double time){
            preSubmitChoices.Add(new EfficacyChoice(choice, time));
        }

        public void AddChoice(string choice)
        {
            evaluationResponse = choice;
        }

        public List<EfficacyChoice> GetChoices()
        {
            return preSubmitChoices;
        }
    }
}
