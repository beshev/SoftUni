using System;
using System.Collections.Generic;

using System.Linq;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.Core
{
    public class Engine
    {
        public void Run()
        {
            string input = string.Empty;
            List<Soldier> soldiers = new List<Soldier>();
            while ((input = Console.ReadLine()) != "End")
            {
                AddSoldiers(input, soldiers);
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static void AddSoldiers(string input, List<Soldier> soldiers)
        {
            string[] soldierInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = soldierInfo[0];
            string id = soldierInfo[1];
            string firstName = soldierInfo[2];
            string lastName = soldierInfo[3];
            decimal salary = decimal.Parse(soldierInfo[4]);

            if (type == "Private")
            {
                soldiers.Add(new Private(id, firstName, lastName, salary));
            }
            else if (type == "LieutenantGeneral")
            {
                AddLieutenantGeneral(soldiers, soldierInfo, id, firstName, lastName, salary);
            }
            else if (type == "Engineer")
            {
                AddEngineer(soldiers, soldierInfo, id, firstName, lastName, salary);
            }
            else if (type == "Commando")
            {
                AddCommando(soldiers, soldierInfo, id, firstName, lastName, salary);
            }
            else if (type == "Spy")
            {
                Spy spy = new Spy(id, firstName, lastName, int.Parse(soldierInfo[4]));
                soldiers.Add(spy);
            }
        }

        private static void AddCommando
            (List<Soldier> soldiers, string[] soldierInfo, string id, string firstName, string lastName, decimal salary)
        {
            string corps = soldierInfo[5];
            if (corps == "Airforces" || corps == "Marines")
            {
                Commando commando = new Commando(id, firstName, lastName, salary, corps);
                soldiers.Add(commando);
                for (int i = 6; i < soldierInfo.Length; i += 2)
                {
                    string missionName = soldierInfo[i];
                    string missionState = soldierInfo[i + 1];
                    if (missionState == "inProgress" || missionState == "Finished")
                    {
                        commando.Missions.Add(new Mission(missionName, missionState));
                    }
                }
            }
        }

        private static void AddEngineer
            (List<Soldier> soldiers, string[] soldierInfo, string id, string firstName, string lastName, decimal salary)
        {
            string corps = soldierInfo[5];
            if (corps == "Airforces" || corps == "Marines")
            {
                Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                soldiers.Add(engineer);
                for (int i = 6; i < soldierInfo.Length; i += 2)
                {
                    string repairPart = soldierInfo[i];
                    int repairHours = int.Parse(soldierInfo[i + 1]);
                    Repair repair = new Repair(repairPart, repairHours);
                    engineer.Repairs.Add(repair);
                }

            }
        }

        private static void AddLieutenantGeneral
            (List<Soldier> soldiers, string[] soldierInfo, string id, string firstName, string lastName, decimal salary)
        {
            LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
            soldiers.Add(lieutenantGeneral);
            for (int i = 5; i < soldierInfo.Length; i++)
            {
                Private @private = (Private)soldiers.FirstOrDefault(x => x.Id == soldierInfo[i]);
                lieutenantGeneral.Privates.Add(@private);
            }
        }
    }
}
