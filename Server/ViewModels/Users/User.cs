using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Type_Extensions;

namespace ViewModels.Users
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int SceneID { get; set; }
    }
}
