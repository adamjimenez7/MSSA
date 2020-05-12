using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicLink.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    PodcastID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    NumSeasons = table.Column<int>(nullable: false),
                    NumEpisodes = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FirstPodcast = table.Column<DateTime>(nullable: false),
                    MostRecentPodcast = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Explicit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.PodcastID);
                });

            migrationBuilder.CreateTable(
                name: "PodcastEpisodes",
                columns: table => new
                {
                    EpisodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Season = table.Column<int>(nullable: false),
                    Episode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PodcastDate = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    Explicit = table.Column<bool>(nullable: false),
                    PodcastID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastEpisodes", x => x.EpisodeID);
                    table.ForeignKey(
                        name: "FK_PodcastEpisodes_Podcasts_PodcastID",
                        column: x => x.PodcastID,
                        principalTable: "Podcasts",
                        principalColumn: "PodcastID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisodes_PodcastID",
                table: "PodcastEpisodes",
                column: "PodcastID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastEpisodes");

            migrationBuilder.DropTable(
                name: "Podcasts");
        }
    }
}
