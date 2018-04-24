using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace CrowdSourcing.Application.Web.Extension
{
    public class ImportFileParamType : IOperationFilter
    {
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class SwaggerFormAttribute : Attribute
        {
            public SwaggerFormAttribute(string name, string description)
            {
                Name = name;
                Description = description;
            }
            public string Name { get; private set; }

            public string Description { get; private set; }
        }
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerFormAttribute>();
            foreach (var attr in requestAttributes)
            {
                operation.parameters = new List<Parameter>
                {   new Parameter
                    {
                        description = "taskId",
                        name = "taskId",
                        @in = "formData",
                        required = true,
                        type = "integer",
                    },
                    new Parameter
                    {
                        description = attr.Description,
                        name ="file1",
                        @in = "formData",
                        required = true,
                        type = "file",
                    },

                     new Parameter
                    {
                        description = attr.Description,
                        name = "file2",
                        @in = "formData",
                        required = false,
                        type = "file",
                    }
                };
                operation.consumes.Add("multipart/form-data");
            }
        }
    }
}
