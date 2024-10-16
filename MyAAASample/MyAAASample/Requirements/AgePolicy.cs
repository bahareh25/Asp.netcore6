using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace MyAAASample.Requirements
{
    public class AgePolicyRequirement:IAuthorizationRequirement
        
    {
        public int Age { get; set; }
        public AgePolicyRequirement(int age)
        {
            Age = age;
        }
    }
    public class AgePolicyRequirementHandler : AuthorizationHandler<AgePolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgePolicyRequirement requirement)
        {
            var random =new Random();
            int userAge = random.Next(15, 20);
            if (userAge>requirement.Age)
            {context.Succeed(requirement);}
            return Task.CompletedTask;

        }
    }

    public class ApplicationFeaturesRequirement : IAuthorizationRequirement

    {
 
    }
    //public class ApplicationFeaturesRequirementHandler : AuthorizationHandler<ApplicationFeaturesRequirement>
    //{
    //    private readonly ApplicationFeatures _applicationFeatures;

    //    public ApplicationFeaturesRequirementHandler(ApplicationFeatures applicationFeatures)
    //    {
    //        _applicationFeatures = applicationFeatures;
        
    //        }
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApplicationFeaturesRequirement requirement)
    //    {
    //        context.User.Claims.Any(c => c.Type == AppfFeature && _applicationFeatures.FeatureList.Any(d => d == c.Value));
    //        return Task.CompletedTask;

    //    }
    //}

    public class ApplicationFeatures
    {
        public List<string> FeatureList { get; set; } = new List<string>
        {
            "CreateUser",
            "EditUser",
        };
    }
}

