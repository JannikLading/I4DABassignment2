using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EFCoreModelsAndRelationships.Model;

namespace EFCoreMigration.Model
{
    public class Edition
    {
        public string EditionId { get; set; }
        // There is no EFCore Data Annotation for making a Check Constraint :(
        // It can be done by yourself, by using putting an ExecuteSql() statement in the migration
        // Or by making your own datavalidation data annotation
        // Also this regular expression might work for now, but is now scaleable
        [RegularExpression(@"Hardback|hardback|Paperback|paperback")]
        public string Type { get; set; }

        public Book Book { get; set; }
        public int ISBN10 { get; set; }
    }
}
