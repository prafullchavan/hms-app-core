using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.entity.Models.Master
{
    public class Country
    {
        public string countryId { get; set; }
        public string countryName { get; set; }
    }


    public class CountryResponse: BaseResponse
    {
        public List<Country> countryList { get; set; }
    }
}
