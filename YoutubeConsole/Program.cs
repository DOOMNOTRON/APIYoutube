using APIYoutube;

YoutubeAPIResponse? DoomYoutubeVideo = await DoomnotronYoutubeVideos.GetYoutubeVideos();
Console.WriteLine(DoomYoutubeVideo?.pageInfo.totalResults);