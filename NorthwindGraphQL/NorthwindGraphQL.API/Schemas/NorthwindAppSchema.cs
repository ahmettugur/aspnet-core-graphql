using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.API.Schemas
{
    public class NorthwindAppSchema:Schema
    {
        public NorthwindAppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NorthwindAppQuery>();
            //Mutation = resolver.Resolve<NorthwindAppMutation>();

        }
    }
}
