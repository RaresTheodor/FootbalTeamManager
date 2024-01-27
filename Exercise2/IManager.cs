using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal interface IManager
    {
        public abstract void InputPList();
        public abstract void InputCList();
        public abstract void ShowPList();
        public abstract void ShowCList();

        public abstract void UpdatePlayersList();
        public abstract void UpdateCoachesList();


        public abstract void ChangePlayerInformation(Player player);

        public abstract void ChangeCoachInformation(Coach coach);
        public abstract void ChangeInformation();

        public abstract void ShowMenu();

        public abstract void StartingProgram();


        public abstract void Sort();





    }
}
