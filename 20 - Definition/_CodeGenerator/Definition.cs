using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CodeGenerator
{
    class Definition
    {
        public static IEnumerable<Model> Models =>
            new List<Model>
            {
                new Model
                {
                    Name = "User",
                    Members = new List<ModelMember>
                    {
                        new ModelMember
                        {
                            Name = "Name",
                            Type = "string"
                        },

                        new ModelMember
                        {
                            Name = "Posts",
                            Type = "IEnumerable<Post>"
                        }
                    }
                },
                new Model
                {
                    Name = "Post",
                    Members = new List<ModelMember>
                    {
                        new ModelMember
                        {
                            Name = "Owner",
                            Type = "string",
                            Mutable = false
                        },

                        new ModelMember
                        {
                            Name = "Text",
                            Type = "string"
                        },

                        //new ModelMember
                        //{
                        //    Name = "PostedDate",
                        //    Type = "DateTime",
                        //    Mutable = false
                        //}
                    }
                }
            };
    }
}
