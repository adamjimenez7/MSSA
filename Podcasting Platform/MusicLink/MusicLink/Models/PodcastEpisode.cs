using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicLink.Models
{
    public class PodcastEpisode
    {
        [Key]
        public int EpisodeID { get; set; }
        public string Title { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime PodcastDate { get; set; }
        public string Genre { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
        public string Authors { get; set; }
        public bool Explicit { get; set; }
        public int PodcastID { get; set; }
        public Podcast podcast { get; set; }
    }
}
