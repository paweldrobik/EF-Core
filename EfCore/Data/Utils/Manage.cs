using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCore.Data.Utils
{
    public class Manage
    {
		MyDbContext context;
		private Lazy<List<Team>> Teams { get; set; }
		private Lazy<List<TeamAssignments>> TeamAssignments  { get; set; }
		private Lazy<List<TeamMember>> TeamMembers { get; set; }
		public Manage()
		{
			context = new MyDbContext();
			Teams = new Lazy<List<Team>>(() => LoadTeams());
			TeamAssignments = new Lazy<List<TeamAssignments>>(() => LoadTeamsAssignments());
			TeamMembers = new Lazy<List<TeamMember>>(() => LoadTeamsMember());
		}

		public void AddNewTeam(string firstName)
		{
			Team teams = new Team { Name = firstName };
			context.Teams.Add(teams);
			context.SaveChanges();

		}
		public void DeleteTeam(int id)
		{
			Team teams = new Team();

			teams = context.Teams.Where(m => m.id == id).FirstOrDefault();
			context.Teams.Remove(teams);
			context.SaveChanges();

		}
		private List<Team> LoadTeams()
		{
			List<Team> teams = new List<Team>();
			teams = context.Teams.ToList();
			return teams;
		}
		public List<Team> TeamsProperty
		{
			get
			{
				return Teams.Value;
			}
		}


		public void AddNewTeamMember(string firstName, string lastName, Role title)
		{
			TeamMember teamMember = new TeamMember { FirstName = firstName, LastName = lastName, Title = title };
			context.TeamMembers.Add(teamMember);
			context.SaveChanges();

		}
		public void DeleteTeamMember(int id)
		{
			TeamMember teamMember = new TeamMember();

			teamMember = context.TeamMembers.Where(m => m.Id == id).FirstOrDefault();
			context.TeamMembers.Remove(teamMember);
			context.SaveChanges();

		}
		private List<TeamMember> LoadTeamsMember()
		{
			List<TeamMember> teamMember = new List<TeamMember>();
			teamMember = context.TeamMembers.ToList();
			return teamMember;
		}
		public List<TeamMember> TeamsMemberProperty
		{
			get
			{
				return TeamMembers.Value;
			}
		}


		public void AddNewTeamAssignments(int tId, int mId)
		{
			TeamAssignments teamAssignments = new TeamAssignments { teamId = tId, memberId = mId };
			context.TeamAssignments.Add(teamAssignments);
			context.SaveChanges();

		}
		public void DeleteTeamAssignments(int id)
		{
			TeamAssignments teamAssignments = new TeamAssignments();

			teamAssignments = context.TeamAssignments.Where(m => m.id == id).FirstOrDefault();
			context.TeamAssignments.Remove(teamAssignments);
			context.SaveChanges();

		}
		private List<TeamAssignments> LoadTeamsAssignments()
		{
			List<TeamAssignments> teamAssignments = new List<TeamAssignments>();
			teamAssignments = context.TeamAssignments.Include(x => x.Team).Include(x => x.TeamMember).ToList();
			return teamAssignments;
		}
		public List<TeamAssignments> TeamsAssignmentsProperty
		{
			get
			{
				return TeamAssignments.Value;
			}
		}

	}
}
