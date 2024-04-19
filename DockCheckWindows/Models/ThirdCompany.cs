using Newtonsoft.Json;

namespace DockCheckWindows.Models
{
    public class ThirdCompany
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("is_vessel_company")]
        public bool IsVesselCompany { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // Constructor
        public ThirdCompany(string id, string name, string logo, string razaoSocial, string cnpj, string address, bool isVesselCompany, string telephone, string email, string status)
        {
            Id = id;
            Name = name;
            Logo = logo;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Address = address;
            IsVesselCompany = isVesselCompany;
            Telephone = telephone;
            Email = email;
            Status = status;
        }

        // Default constructor for JSON deserialization
        public ThirdCompany() { }

        // Method to deserialize JSON string to ThirdCompany object
        public static ThirdCompany FromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<ThirdCompany>(jsonData);
        }

        // Method to serialize ThirdCompany object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to create a new ThirdCompany object with updated properties
        public ThirdCompany CopyWith(string id = null, string name = null, string logo = null, string razaoSocial = null, string cnpj = null, string address = null, bool? isVesselCompany = null, string telephone = null, string email = null, string status = null)
        {
            return new ThirdCompany(
                id ?? Id,
                name ?? Name,
                logo ?? Logo,
                razaoSocial ?? RazaoSocial,
                cnpj ?? Cnpj,
                address ?? Address,
                isVesselCompany ?? IsVesselCompany,
                telephone ?? Telephone,
                email ?? Email,
                status ?? Status
            );
        }
    }
}
