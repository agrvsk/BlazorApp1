using System.Text.Json.Serialization;

namespace BlazorApp1.Server.Entities
{
    public class Cat
    {
        [JsonPropertyName("length")]
        public string Length { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("image_link")]
        public string ImageLink { get; set; }




            //public int family_friendly { get; set; }
            //public int shedding { get; set; }
            //public int general_health { get; set; }
            //public int playfulness { get; set; }
            //public int children_friendly { get; set; }
            //public int grooming { get; set; }
            //public int intelligence { get; set; }
            //public int other_pets_friendly { get; set; }
            //public int min_weight { get; set; }
            //public int max_weight { get; set; }
            //public int min_life_expectancy { get; set; }
            //public int max_life_expectancy { get; set; }
            //public string name { get; set; }
        }

    }

