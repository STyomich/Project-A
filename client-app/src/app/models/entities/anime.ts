import { Episode } from "./episode"
import { Genre } from "./genre"
import { Studio } from "./studio"
import { Comment } from "./comment"

export interface Anime {
    id: string
    studioId: string
    picture: string
    titleInEnglish: string
    titleInJapanese: string
    titleInUkrainian: string
    titleInRussian: string
    type: string
    animeState: string
    startDate: string
    endDate: string
    releasedEpisodes: number
    expectedEpisodes: number
    originalSource: string
    description: string
    adminsNote: string
    studio: Studio
    episodes: Episode[]
    genres: Genre[]
    comments: Comment[]
  }