import { VoiceCastPin } from "./voiceCastPin"

export interface Episode {
    id: string
    animeId: string
    number: number
    description: string
    duration: number
    voiceCastPins: VoiceCastPin[]
  }