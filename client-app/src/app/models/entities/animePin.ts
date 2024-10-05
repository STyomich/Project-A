import { Anime } from "./anime"

export interface AnimePin {
    userId: string
    animeId: string
    pinType: string
    grade: number
    isFavorite: boolean
    addDate: string
    anime: Anime
  }

export interface AnimePinCreateValues {
  animeId: string
  pinType: string
  grade: number
  isFavorite: boolean
}
  