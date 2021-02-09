using EfCore.Data;
using EfCore.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Manage manage = new Manage();

            //manage.AddNewTeamMember("Karol", "Mors", Role.Developer);
            //manage.AddNewTeamMember("Jacek", "Ryzen", Role.ScrumMuster);
            //manage.AddNewTeamMember("Wiktoria", "North", Role.ProjectOwner);

            //manage.AddNewTeam("Team B");

            //manage.AddNewTeamAssignments(1, 1);
            //manage.AddNewTeamAssignments(1, 3);
            //manage.AddNewTeamAssignments(1, 5);
            //manage.AddNewTeamAssignments(2, 2);
            //manage.AddNewTeamAssignments(2, 4);
            //manage.AddNewTeamAssignments(2, 6);

            manage.DeleteTeamMember(1);

            //manage.TeamsProperty.ForEach(x => Console.WriteLine($"{x.id} {x.Name}"));
            //manage.TeamsMemberProperty.ForEach(x => Console.WriteLine($"{x.Id} {x.FirstName} {x.LastName} {x.Title}"));
            manage.TeamsAssignmentsProperty.ForEach(x => Console.WriteLine($"Id:{x.id} TeamId:{x.teamId} MemberId:{x.memberId}\nTEAM: {x.Team.Name}\tFIRST NAME: {x.TeamMember.FirstName}" +
                $"\tLAST NAME: {x.TeamMember.LastName}\t TITLE: {x.TeamMember.Title}"));

            Console.ReadKey();
            
        }
    }
}
