using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicLink.Models
{
    public class Podcast
    {
        public int PodcastID { get; set; }
        public string Title { get; set; }
        public int NumSeasons { get; set; }
        public int NumEpisodes { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime FirstPodcast { get; set; }
        public DateTime MostRecentPodcast { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
        public virtual ICollection<PodcastEpisode> PodcastEpisodes { get; set; }
    }
}
