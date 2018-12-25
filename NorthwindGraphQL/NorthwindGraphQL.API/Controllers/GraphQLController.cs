using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindGraphQL.API.Queries;

namespace NorthwindGraphQL.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class GraphQLController : ControllerBase
    //{
    //}

    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        private readonly IDocumentWriter _writer;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema, IDocumentWriter writer)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
            _writer = writer;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;


            var executionOptions = new ExecutionOptions { Schema = _schema, Query = queryToExecute, Inputs = inputs, OperationName = query.OperationName };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);


            if (result.Errors?.Count > 0)
                return BadRequest(result);
            else
                return Ok(result);

        }
    }
}