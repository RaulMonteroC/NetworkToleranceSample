using System.Collections.Generic;
using System.Linq;
using NetworkTolerance.Framework.Keys;
using Newtonsoft.Json;

namespace NetworkTolerance.Models
{
    public class Developer
    {
        public string Name { get; set; }
        public string Initials { get; set; }

        [JsonProperty("image")]
        public string RelativeImageUrl { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }
        public string Webpage { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }

        public string AbsoluteImageUrl => GetImageUrl(RelativeImageUrl);

        public List<string> DisplaySkills => GetSkillsToDisplay(Skills);

        private string GetImageUrl(string relativeimageUrl)
        {
            return relativeimageUrl.Contains("http") ?
                relativeimageUrl :
                $"{AppConstants.BaseImageUrl}{relativeimageUrl}";
        }
 
        private List<string> GetSkillsToDisplay(string skills)
        {
            return skills.Split(',').Select(t => t).ToList();
        }
    }
}