using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Quote : CommonBase
    {
        public long Id { get; set; }

        public string Reference { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime QuoteDate { get; set; }

        public long ProjectManagerId { get; set; }

        public int QuoteStatusId { get; set; }

        public long CustomerId { get; set; }

        public long PlaceConfigurationId { get; set; }

    }
}
