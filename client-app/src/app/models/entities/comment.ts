import { User } from "./user"

export interface Comment {
    id: string
    userId: string
    animeId: string
    content: string
    user: User
  }