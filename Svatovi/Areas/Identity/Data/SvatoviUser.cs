using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Svatovi.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SvatoviUser class
public class SvatoviUser
{
    public string id { get; set; }
    public string? name { get; set; }
    public string? role { get; set; }
}

