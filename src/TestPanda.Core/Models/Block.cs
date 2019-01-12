using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPanda.Core
{
    public class Block
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }
        public DateTime DateBlocked { get; private set; }
        public TestUser BlockedBy { get; private set; }

        
    }
}