using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IELENT.User
{
    public class FacebookUserBE
    {

        
            public long id
            { get; set; }

            public string email
            { get; set; }

            public string name
            { get; set; }

            public string first_name
            { get; set; }

            public string last_name
            { get; set; }

            public string gender
            { get; set; }

            public string link
            { get; set; }

            public DateTime updated_time
            { get; set; }

            public DateTime birthday
            { get; set; }

            public string locale
            { get; set; }

            public string picture
            { get; set; }

            public FacebookLocation location
            { get; set; }
       

        public class FacebookLocation
        {
            public string id
            { get; set; }

            public string name
            { get; set; }
        }


    }
}
