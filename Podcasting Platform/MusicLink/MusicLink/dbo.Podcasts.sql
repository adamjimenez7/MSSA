CREATE TABLE [dbo].[Podcasts] (
    [PodcastID]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (MAX) NOT NULL,
    [NumSeasons]        INT            NOT NULL,
    [NumEpisodes]       INT            NOT NULL,
    [Description]       NVARCHAR (MAX) NOT NULL,
    [FirstPodcast]      DATETIME2 (7)  NOT NULL,
    [MostRecentPodcast] DATETIME2 (7)  NOT NULL,
    [Genre]             NVARCHAR (MAX) NULL,
    [Type]              NVARCHAR (MAX) NOT NULL,
    [Link]              NVARCHAR (MAX) NULL,
    [Image]             NVARCHAR (MAX) NULL,
    [Language]          NVARCHAR (MAX) NOT NULL,
    [Author]            NVARCHAR (MAX) NULL,
    [Duration]          INT            NOT NULL,
    [Explicit]          BIT            NULL,
    CONSTRAINT [PK_Podcasts] PRIMARY KEY CLUSTERED ([PodcastID] ASC)
);

