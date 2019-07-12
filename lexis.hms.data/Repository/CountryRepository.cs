using lexis.hms.data.Contracts;
using lexis.hms.data.Models;
using lexis.hms.entity.Models.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lexis.hms.data.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private readonly lexis_hmsContext _context;
        private readonly ILoginRepository _loginRepository;

        public CountryRepository(lexis_hmsContext context, ILoginRepository loginRepository)
        {
            _context = context;
            _loginRepository = loginRepository;
        }
        public async Task<CountryResponse> CreateCountry(Country countryModel)
        {
            var userId = await _loginRepository.GetUserIdByAuthToken("");

            var countryExisting = GetCountryByName(countryModel.countryName);
            if (countryExisting != null)
            {
                var response = new CountryResponse { status = false, message = "Country already exists", countryList = null };
                return response;
            }
            else
            {
                var country = new MtnCountry()
                {
                    CountryName = countryModel.countryName,
                    CreatedBy = userId
                };
                var loginSessionEntry = _context.MtnCountry.Add(country);
                await _context.SaveChangesAsync();

                var countryList = new List<Country>();
                countryList.Add(new Country { countryId = Convert.ToString(country.CountryId), countryName = country.CountryName });
                var response = new CountryResponse { status = true, countryList = countryList };
                return response;
            }
        }

        public MtnCountry GetCountryByName(string name)
        {
            var country = _context.MtnCountry.Where(x => x.CountryName == name).FirstOrDefault();
            return country;
        }

        public CountryResponse GetAllCountries()
        {
            var countries = _context.MtnCountry;
            IEnumerable<Country> countryList = countries.ToList().Select(
                cr => new Country()
                    {
                    countryId = Convert.ToString(cr.CountryId),
                    countryName = cr.CountryName
                });
            var countryResponse = new CountryResponse()
            {
                status = true,
                countryList = countryList.ToList()
            };
            return countryResponse;
        }
    }
}
