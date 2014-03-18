using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    //[TestClass]
    public class TestGroupOperations
    {
        [TestMethod]
        public void InviteMember_Should_Return_Invitation()
        {
            var groupOperations = new GroupOperations();
            Player inviter = new Player();
            Player invitee = new Player();
            Group group = new Group();
            Invitation invitation = groupOperations.InviteMember(inviter, invitee, group);
            Assert.AreEqual(inviter, invitation.Inviter); 
            Assert.AreEqual(invitee, invitation.Invitee); 
            Assert.AreEqual(group, invitation.Group);
        }
        [TestMethod]
        public void InviteMember_When_Have_No_Permission_Should_Return_Null()
        {
            var groupOperations = new GroupOperations();
            Player inviter = new Player();
            Player invitee = new Player();
            Group group = new Group();
            Invitation invitation = groupOperations.InviteMember(inviter, invitee, group);
            Assert.IsNull(invitation);
        }
    }
    public class GroupOperations
    {
        public Group CreateGroupAndPlayer(string playerName)
        {
            Group group = new Group();
            var player = new Player();
            player.Name = playerName;
            player.Groups = new List<Group> { group };
            group.Members = new List<Player> { player };
            group.PlayerPermissions = new List<PlayerPermission> 
            {
                new PlayerPermission 
                {
                    Group = group, 
                    Permission = new Permission
                    {
                        Name = "InviteMembers",                        
                    }, 
                    Player = player
                } 
            };
            return group;
        }

        public Invitation InviteMember(Player inviter, Player invitee, Group group)
        {
            group.PlayerPermissions = new List<PlayerPermission> { };
            if (group.PlayerPermissions.Any(playerPermission
                => (playerPermission.Player == inviter)
                && (playerPermission.Group == group)
                && (playerPermission.Permission.Name == "InviteMembers")))
            {
                Invitation invitation = new Invitation();
                invitation.Inviter = inviter;
                invitation.Invitee = invitee;
                invitation.Group = group;
                return invitation;
            }
            else return null;
        }
    }
    public class Player
    {
        public string Name;
        public List<Group> Groups;
        public List<Invitation> ReceivedInvitations;
        public List<Invitation> SentInvitations;
    }
    public class Invitation
    {
        public Player Inviter;
        public Player Invitee;
        public Group Group;
    }
    public class Permission
    {
        public string Name;
        public List<Player> PlayersThatHaveThisPermission;
    }
    public class Group
    {
        public bool IsPersistent;
        public List<Player> Members;
        public List<Invitation> Invitations;
        public List<PlayerPermission> PlayerPermissions;
    }
    public class PlayerPermission
    {
        public Player Player;
        public Permission Permission;
        public Group Group;
    }
}
