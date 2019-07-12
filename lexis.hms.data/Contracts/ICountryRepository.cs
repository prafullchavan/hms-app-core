using lexis.hms.data.Models;
using lexis.hms.entity.Models.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lexis.hms.data.Contracts
{
    public interface ICountryRepository
    {
        Task<CountryResponse> CreateCountry(Country country);
        CountryResponse GetAllCountries();
        MtnCountry GetCountryByName(string name);

    }
}
