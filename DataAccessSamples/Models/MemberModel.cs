using System;
using SQLite;

namespace DataAccessSamples.Models
{
	public class MemberModel
	{
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public bool Subscribed { get; set; }
            public string HairColor { get; set; }
            public string Height { get; set; }
            public string FavoriteColor { get; set; }
            public string FavoriteHobby { get; set; }
            public string MothersName { get; set; }
            public string FathersName { get; set; }

    }
}

