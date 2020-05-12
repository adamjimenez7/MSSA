CREATE TABLE [dbo].[PodcastEpisodes] (
    [EpisodeID]   INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Season]      INT            NOT NULL,
    [Episode]     INT            NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [PodcastDate] DATETIME2 (7)  NOT NULL,
    [Genre]       NVARCHAR (MAX) NULL,
    [Link]        NVARCHAR (MAX) NOT NULL,
    [Image]       NVARCHAR (MAX) NOT NULL,
    [Language]    NVARCHAR (MAX) NULL,
    [Authors]     NVARCHAR (MAX) NULL,
    [Explicit]    BIT            NOT NULL,
    [PodcastID]   INT            NULL,
    CONSTRAINT [PK_PodcastEpisodes] PRIMARY KEY CLUSTERED ([EpisodeID] ASC),
    CONSTRAINT [FK_PodcastEpisodes_Podcasts_PodcastID] FOREIGN KEY ([PodcastID]) REFERENCES [dbo].[Podcasts] ([PodcastID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PodcastEpisodes_PodcastID]
    ON [dbo].[PodcastEpisodes]([PodcastID] ASC);

