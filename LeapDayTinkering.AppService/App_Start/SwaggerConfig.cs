using LeapDayTinkering.AppService;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace LeapDayTinkering.AppService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "LeapDayTinkering.AppService");
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
    }
}