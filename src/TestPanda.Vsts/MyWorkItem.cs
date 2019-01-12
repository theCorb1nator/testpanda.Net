using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TestPanda.Core;

namespace TestPanda.Vsts
{
    public class MyWorkItem : WorkItem, IEntity
    {
        int IEntity.Id
        {
            get
            {
                return Id.GetValueOrDefault();
            }
        }
    }
}
