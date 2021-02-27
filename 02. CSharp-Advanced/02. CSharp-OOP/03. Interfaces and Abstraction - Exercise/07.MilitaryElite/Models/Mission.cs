using System;

using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName , string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            else
            {
                this.State = State.Finished;
            }
        }

        private State TryParseState(string strState)
        {
            bool parsed = Enum.TryParse<State>(strState, out State state);

            if (!parsed)
            {
                throw new InvalidMissionException();
            }
            else
            {
                return state;
            }
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
